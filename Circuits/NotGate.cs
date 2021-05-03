using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace Circuits
{
    /// <summary>
    /// This class implements a NOT Gate with one input
    /// and one output.
    /// </summary>
    class NotGate : Gate
    {
        //####################################################################
        //# Constructor
        /// <summary>
        /// Initialises a new AND gate object.
        /// </summary>
        /// <param name="x">x-position of the gate</param>
        /// <param name="y">y-position of the gate</param>
        public NotGate(int x, int y)
        {
            pins.Add(new Pin(this, true, 20));          
            pins.Add(new Pin(this, false, 20));
            MoveTo(x, y); // move the gate and position the pins
        }

        #region Public Methods

        /// <summary>
        /// Draws a new Not Gate onto the circuit
        /// </summary>
        /// <param name="paper">The object to display it on</param>
        public override void Draw(Graphics paper)
        {
            point = new Point(Left, Top);
            if (selected)
            {
                gate = Properties.Resources.NotGateAllRed;
            }
            else
            {
                gate = Properties.Resources.NotGate;
            }
            foreach (Pin p in pins)
                p.Draw(paper);

            // Answer from https://stackoverflow.com/questions/5687867/c-sharp-graphics-displays-the-image-larger-than-normal
            paper.DrawImage(gate, new Rectangle(point, new Size(WIDTH, HEIGHT)));
        }

        public override void MoveTo(int x, int y)
        {
            Debug.WriteLine("pins = " + pins.Count);
            left = x;
            top = y;
            // must move the pins too
            pins[0].X = x - GAP;
            pins[0].Y = y + HEIGHT / 2;
            pins[1].X = x + WIDTH + GAP;
            pins[1].Y = y + HEIGHT / 2;
        }

        /// <summary>
        /// Evaluates the logical result of the NOT Gate.
        /// </summary>
        /// <returns>The NOT result of the gate</returns>
        public override bool Evaluate()
        {
            try
            {
                Gate gate = pins[0].InputWire.FromPin.Owner;

                //Whatever the result of the gate is, return the NOT of it
                return !gate.Evaluate();
            }
            catch
            {
                //Program catches if there is no wire connected to the pin, returning false and throwing an exception
                MessageBox.Show("There are no wires connected to the input pin(s).");
                return false;
            }
        }

        /// <summary>
        /// Creates a new copy of a Not Gate.
        /// </summary>
        /// <returns>A new Not Gate</returns>
        public override Gate Clone()
        {
            Gate notGateClone = new NotGate(0, 0);

            return notGateClone;
        }

        #endregion
    }
}
