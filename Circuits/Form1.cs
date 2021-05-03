using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace Circuits
{
    /// <summary>
    /// The main GUI for the COMP104 digital circuits editor.
    /// This has a toolbar, containing buttons called buttonAnd, buttonOr, etc.
    /// The contents of the circuit are drawn directly onto the form.
    /// </summary>
    public partial class Form1 : Form
    {
        #region variables

        /// <summary>
        /// The (x,y) mouse position of the last MouseDown event.
        /// </summary>
        protected int startX, startY;

        /// <summary>
        /// If this is non-null, we are inserting a wire by
        /// dragging the mouse from startPin to some output Pin.
        /// </summary>
        protected Pin startPin = null;

        /// <summary>
        /// The (x,y) position of the current gate, just before we started dragging it.
        /// </summary>
        protected int currentX, currentY;

        /// <summary>
        /// The set of gates in the circuit
        /// </summary>
        protected List<Gate> gates = new List<Gate>();

        /// <summary>
        /// The set of connector wires in the circuit
        /// </summary>
        protected List<Wire> wires = new List<Wire>();

        /// <summary>
        /// The currently selected gate, or null if no gate is selected.
        /// </summary>
        protected Gate current = null;

        /// <summary>
        /// The new gate that is about to be inserted into the circuit.
        /// </summary>
        protected Gate newGate = null;

        /// <summary>
        /// The new compound that that is created from the gates selected in the circuit.
        /// </summary>
        protected Compound newCompound = null;

        #endregion

        #region form event-handlers

        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;
        }

        /// <summary>
        /// Finds the pin that is close to (x,y), or returns
        /// null if there are no pins close to the position.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public Pin findPin(int x, int y)
        {
            foreach (Gate g in gates)
            {
                foreach (Pin p in g.Pins)
                {
                    if (p.isMouseOn(x, y))
                        return p;
                }
            }
            return null;
        }

        /// <summary>
        /// Draws the gate onto the circuit, and any
        /// wires that may be connected to them.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            foreach (Gate g in gates)
            {
                g.Draw(e.Graphics);
            } 
            foreach (Wire w in wires)
            {
                w.Draw(e.Graphics);
            }
            if (startPin != null)
            {
                e.Graphics.DrawLine(Pens.White, startPin.X, startPin.Y, currentX, currentY);
            }
            if (newGate != null)
            {
                // show the gate that we are dragging into the circuit
                newGate.MoveTo(currentX, currentY);
                newGate.Draw(e.Graphics);
            }
        }

        #region mouse event-handlers

        /// <summary>
        /// Checks if a Gate has been selected when clicked on.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (current != null)
            {
                current.Selected = false;
                current = null;
                this.Invalidate();                
            }
            // See if we are inserting a new gate
            if (newGate != null)
            {
                newGate.MoveTo(e.X, e.Y);
                gates.Add(newGate);
                newGate = null;
                this.Invalidate();
            }
            else
            {
                // search for the first gate under the mouse position
                foreach (Gate g in gates)
                {
                    if (g.IsMouseOn(e.X, e.Y))
                    {
                        g.Selected = true;
                        current = g;

                       //Will add the current gate to the new compound gate
                        if (newCompound != null)
                        {
                            newCompound.AddGate(g);

                            //Message to indicate the gate that is being added
                            Debug.WriteLine(g.GetType().Name + " Added.");
                        }                                             

                        this.Invalidate();
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Begins wire from output pin from where mouse is.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (current == null)
            {
                // try to start adding a wire
                startPin = findPin(e.X, e.Y);
            }
            else if (current.IsMouseOn(e.X, e.Y))
            {
                // start dragging the current object around
                startX = e.X;
                startY = e.Y;
                currentX = current.Left;
                currentY = current.Top;
            }
        }

        /// <summary>
        /// Draws wire from an outpin pin and moves it to where the mouse is.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (startPin != null)
            {
                Debug.WriteLine("wire from "+ startPin+" to " + e.X + "," + e.Y);
                currentX = e.X;
                currentY = e.Y;
                this.Invalidate();  // this will draw the line
            }
            else if (startX >= 0 && startY >= 0 && current != null)
            {
                Debug.WriteLine("mouse move to " + e.X + "," + e.Y);
                current.MoveTo(currentX + (e.X - startX), currentY + (e.Y - startY));

                this.Invalidate();
            }
            else if (newGate != null || (newGate is Compound && newGate != null))
            {
                currentX = e.X;
                currentY = e.Y;
                this.Invalidate();
            }
        }   

        /// <summary>
        /// Checks if wire is over an input pin to connect to from where the mouse is released.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (startPin != null)
            {
                // see if we can insert a wire
                Pin endPin = findPin(e.X, e.Y);
                if (endPin != null)
                {
                    Debug.WriteLine("Trying to connect " + startPin + " to " + endPin);
                    Pin input, output;
                    if (startPin.IsOutput)
                    {
                        input = endPin;
                        output = startPin;
                    }
                    else
                    {
                        input = startPin;
                        output = endPin;
                    }
                    if (input.IsInput && output.IsOutput)
                    {
                        if (input.InputWire == null)
                        {
                            Wire newWire = new Wire(output, input);
                            input.InputWire = newWire;
                            wires.Add(newWire);
                        }
                        else
                        {
                            MessageBox.Show("That input is already used.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Error: you must connect an output pin to an input pin.");
                    }
                }
                startPin = null;
                this.Invalidate();
            }
            // We have finished moving/dragging
            startX = -1;
            startY = -1;
            currentX = 0;
            currentY = 0;
        }

        #endregion

        #endregion

        #region button event-handlers

        /// <summary>
        /// Adds a new AND Gate to the circuit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAnd_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("And Gate added to the ciruit.");
            newGate = new AndGate(0, 0);
        }

        /// <summary>
        /// Adds a new OR Gate to the circuit.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonOr_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("Or Gate added the to the circuit.");
            newGate = new OrGate(0, 0);
        }

        /// <summary>
        /// Adds a new NOT Gate to the circuit.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonNot_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("Not Gate added to the circuit.");
            newGate = new NotGate(0, 0);
        }      

        /// <summary>
        /// Adds a new Input Source to the circuit.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonInputSource_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("Input Source added to the circuit.");
            newGate = new InputSource(0, 0);
        }     

        /// <summary>
        /// Adds a new Output Source to the circuit.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonOutputLamp_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("Output Lamp added to the circuit.");
            newGate = new OutputLamp(0, 0);
        }

        /// <summary>
        /// Evaluates the circuits logical result.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonEvaluate_Click(object sender, EventArgs e)
        {
            foreach(Gate g in gates)
            {
                if(g is OutputLamp)//We only want the logical result from the output lamp
                {
                    this.Invalidate();

                    //Display the logical result in the console
                    Debug.WriteLine("Circuit evaluates to: " + g.Evaluate().ToString());
                }
            }
        }

        /// <summary>
        /// Copies the selected Gate and creates a new gate.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCopy_Click(object sender, EventArgs e)
        {
            //Clone the selected gate
            if (current != null)
            {
                newGate = current.Clone();
                Debug.WriteLine("Copy of " + newGate.GetType().Name + " added to circuit.");
            }
            //If a gate is not selected
            else if (current == null)
            {
                newGate = null;

                MessageBox.Show("Please select a gate to copy.");
            }               
        }

        /// <summary>
        /// Starts a new Compound Gate.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonStartCompound_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("New Compound Gate started.");
            newCompound = new Compound(0, 0);
        }

        /// <summary>
        /// Ends the compound gate and creates a new gate.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonEndCompound_Click(object sender, EventArgs e)
        {            
            if(newCompound != null)
            {
                Debug.WriteLine("Compound Gate finished.");
                Debug.WriteLine("The gates in this Compound are:");

                //This is used to check all the gates within the compound gate.
                foreach (Gate g in newCompound.GateList)
                {
                    gates.Remove(g);

                    //Message to confirm what Gates are in the Compound Gate
                    Debug.WriteLine(g.GetType().Name);
                }
            }
            else
            {
                MessageBox.Show("Please start a new Compound Gate.");
            }           

            //Move the Compound Gate into New Gate and set the Compound Gate back to null
            newGate = newCompound;
            newCompound = null;
            this.Invalidate();
        }

        #endregion
    }
}