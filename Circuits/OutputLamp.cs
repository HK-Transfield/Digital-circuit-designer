using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace Circuits
{
    /// <summary>
    /// This class implements an Output Source with one input.
    /// </summary>
    class OutputLamp : Gate
    {
        //####################################################################
        //# Instance Varibles
        /// <summary>
        /// Bool that determines the logical result of the circuit
        /// </summary>
        private bool _outputVoltage;


        //####################################################################
        //# Constructor
        /// <summary>
        /// Initialise a new output lamp object.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public OutputLamp(int x, int y)
        {
            _outputVoltage = false;          
            pins.Add(new Pin(this, true, 20));
            MoveTo(x, y); // move the gate and position the pins
        }

        #region Public Methods

        public override void MoveTo(int x, int y)
        {
            Debug.WriteLine("pins = " + pins.Count);
            left = x;
            top = y;

            pins[0].X = x - IO_SIZE / 2;
            pins[0].Y = y + IO_SIZE / 2;
        }

        /// <summary>
        /// True if the given (x,y) position is roughly
        /// on top of this gate.
        /// </summary>
        /// <param name="x">x-Position of the mouse</param>
        /// <param name="y">y-Position of the Mouse</param>
        /// <returns></returns>
        public override bool IsMouseOn(int x, int y)
        {
            if (left <= x && x < left + IO_SIZE && top <= y && y < top + IO_SIZE)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Draws a Output Lamp Gate onto the circuit.
        /// </summary>
        /// <param name="paper">The graphics object to display the Gate onto</param>
        public override void Draw(Graphics paper)
        {
            if (selected)
            {
                //Only want an outline around the 
                paper.DrawEllipse(selectedPen, left, top, IO_SIZE, IO_SIZE);
            }

            foreach (Pin p in pins)
                p.Draw(paper);

            //If the voltage is high
            if (_outputVoltage)
            {
                //Yellow brush indicates that the Output lamp is on / high (1)
                paper.FillEllipse(Brushes.Yellow, left, top, IO_SIZE, IO_SIZE);
            }
            else
            {
                //Black brush indicates the Output Lamp is off / low (0)
                paper.FillEllipse(Brushes.Black, left, top, IO_SIZE, IO_SIZE);
            }
        }

        /// <summary>
        /// Evaluates the logical result.
        /// </summary>
        /// <returns>The logical result of the whole circuit</returns>
        public override bool Evaluate()
        {
            try
            {
                Gate gateA = pins[0].InputWire.FromPin.Owner;

                if (gateA.Evaluate() == true)               
                    _outputVoltage = true;                    
                
                else                
                    _outputVoltage = false;                  
                                   
                return gateA.Evaluate();
            }
            catch
            {
                //Program catches if there is no wire connected to the pin, returning false and displaying an error message
                MessageBox.Show("There are no wires connected to the input pin(s).");
                return false;
            }
        }

        /// <summary>
        /// Creates a new copy an Output Source.
        /// </summary>
        /// <returns>A new Output Source Gate</returns>
        public override Gate Clone()
        {
            Gate outputLampClone = new OutputLamp(0, 0);

            return outputLampClone;
        }

        #endregion
    }
}
