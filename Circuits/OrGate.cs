using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Text;

namespace Circuits
{
    /// <summary>
    /// This class implements an OR Gate with two inputs
    /// and one output.
    /// </summary>
    class OrGate : Gate
    {
        //####################################################################
        //# Constructor
        /// <summary>
        /// Initialises a new OR Gate object.
        /// </summary>
        /// <param name="x">x-Position of the Or Gate</param>
        /// <param name="y">y-Positino of the Or Gate</param>
        public OrGate(int x, int y)
        {
            pins.Add(new Pin(this, true, 20));
            pins.Add(new Pin(this, true, 20));
            pins.Add(new Pin(this, false, 20));
            MoveTo(x, y); // move the gate and position the pins
        }

        #region Public Methods

        /// <summary>
        /// Draws a new Or Gate onto the circuit. 
        /// </summary>
        /// <param name="paper">The graphics object to display it on</param>
        public override void Draw(Graphics paper)
        {
            point = new Point(Left, Top);
            if (selected)
            {
                gate = Properties.Resources.OrGateAllRed;
            }
            else
            {
                gate = Properties.Resources.OrGate;
            }
            foreach (Pin p in pins)
                p.Draw(paper);

            // Answer from https://stackoverflow.com/questions/5687867/c-sharp-graphics-displays-the-image-larger-than-normal
            paper.DrawImage(gate, new Rectangle(point, new Size(WIDTH, HEIGHT)));
        }

        /// <summary>
        /// Computes the logical result of the Or Gate.
        /// If either pins evaluate true then the 
        /// gate is true.
        /// </summary>
        /// <returns>The logical result</returns>
        public override bool Evaluate()
        {
            try
            {
                Gate gateA = pins[0].InputWire.FromPin.Owner;
                Gate gateB = pins[1].InputWire.FromPin.Owner;

                //One of the gates must be true for the OR Gate to return true
                return gateA.Evaluate() || gateB.Evaluate();
            }
            catch
            {
                //Program catches if there is no wire connected to the pin, returning false and throwing an exception
                MessageBox.Show("There are no wires connected to the input pin(s).");
                return false;
            }
        }

        /// <summary>
        /// Creates a new copy of and OR Gate.
        /// </summary>
        /// <returns>A new OR Gate</returns>
        public override Gate Clone()
        {
            Gate orGateCopy = new OrGate(0, 0);

            return orGateCopy;
        }

        #endregion
    }
}
