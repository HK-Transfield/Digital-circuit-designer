using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;

namespace Circuits
{
    /// <summary>
    /// This class implements an AND gate with two inputs
    /// and one output.
    /// </summary>
    class AndGate : Gate
    {
        //####################################################################
        //# Constructor                         
        /// <summary>
        /// Initialises a new AND gate object.
        /// </summary>
        /// <param name="x">x-position of the gate</param>
        /// <param name="y">y-position of the gate</param>
        public AndGate(int x, int y)
        {
            pins.Add(new Pin(this, true, 20));
            pins.Add(new Pin(this, true, 20));
            pins.Add(new Pin(this, false, 20));
            MoveTo(x, y); // move the gate and position the pins
            
        }

        #region Public Methods

        /// <summary>
        /// Draws a new And Gate onto the circuit.
        /// </summary>
        /// <param name="paper">The object to display the And Gate on</param>
        public override void Draw(Graphics paper)
        {
            point = new Point(Left, Top);
            if (selected)
            {
                gate = Properties.Resources.AndGateAllRed;
            }
            else
            {               
                gate = Properties.Resources.AndGate;
            }
            foreach (Pin p in pins)
                p.Draw(paper);

            // Solution from https://stackoverflow.com/questions/5687867/c-sharp-graphics-displays-the-image-larger-than-normal
            paper.DrawImage(gate, new Rectangle(point, new Size(WIDTH, HEIGHT)));
        }

        /// <summary>
        /// Computes the logical result of the And Gate.
        /// If both pins evaluate to true, then the whole 
        /// gate is true.
        /// </summary>
        /// <returns>The logical result</returns>
        public override bool Evaluate()
        {
            try
            {
                //Set the Gates for the two input pins
                Gate gateA = pins[0].InputWire.FromPin.Owner;
                Gate gateB = pins[1].InputWire.FromPin.Owner;

                //Both gates must return a true value for the AND Gate to return true
                return gateA.Evaluate() && gateB.Evaluate();
            }
            catch
            {
                //Program catches if there is no wire connected to the pin, returning false and throwing an exception
                MessageBox.Show("There are no wires connected to the input pin(s).");
                return false;              
            }      
        }

        /// <summary>
        /// Creates a new copy of an AND Gate.
        /// </summary>
        /// <returns>A new And Gate</returns>
        public override Gate Clone()
        {
            Gate andGateCopy = new AndGate(0, 0);

            return andGateCopy;
        }

        #endregion
    }
}
