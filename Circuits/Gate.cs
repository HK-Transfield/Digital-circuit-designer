using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Diagnostics;

namespace Circuits
{
    /// <summary>
    /// This class implements a Gate which will have 
    /// inputs and outputs depending on the type of Gate.
    /// </summary>
    public abstract class Gate
    {
        #region Variables

        // left is the left-hand edge of the main part of the gate.
        // So the input pins are further left than left.
        protected int left;

        // top is the top of the whole gate
        protected int top;

        // the image that is used to represent the gate when drawn on the circuit
        protected Image gate;
        protected Point point;

        // Checks whether the gate has been selected or not
        protected bool selected = false;

        // width and height of the main part of the gate
        protected const int WIDTH = 40;
        protected const int HEIGHT = 40;
        protected const int IO_SIZE = 16;//Smaller size for the input and output

        // length of the connector legs sticking out left and right
        protected const int GAP = 10;

        // Brush and pen to determine whether or not a gate has been selected
        protected Brush normalBrush = Brushes.LightGray;
        protected Pen selectedPen = new Pen(Color.Red, 3);

        /// <summary>
        /// This is the list of all the pins of this gate.
        /// An AND gate, and an OR gate always has two input pins (0 and 1)
        /// and one output pin (2).
        /// A NOT gate has only one input (0) and output pin (1).
        /// An Input Source only has an output pin (0).
        /// An Output Lamp only has an input pin(0).
        /// </summary>
        protected List<Pin> pins = new List<Pin>();

        #endregion

        #region Read / Write Properties

        /// <summary>
        /// Indicates whether this gate is the current one selected.
        /// </summary>
        public virtual bool Selected
        {
            get { return selected; }
            set { selected = value; }
        }

        /// <summary>
        /// Get the left-hand edge of the main part of the gate.
        /// </summary>
        public virtual int Left
        {
            get { return left; }
        }

        /// <summary>
        /// Get the top of the whole gate.
        /// </summary>
        public virtual int Top
        {
            get { return top; }
        }

        /// <summary>
        /// Get the list of pins of the gate.
        /// </summary>
        public virtual List<Pin> Pins
        {
            get { return pins; }
        }

        #endregion

        #region Virtual Methods

        /// <summary>
        /// True if the given (x,y) position is roughly
        /// on top of this gate.
        /// </summary>
        /// <param name="x">x-Position of the mouse</param>
        /// <param name="y">y-Position of the mouse</param>
        /// <returns></returns>
        public virtual bool IsMouseOn(int x, int y)
        {
            if (left <= x && x < left + WIDTH && top <= y && y < top + HEIGHT)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Moves Gate around circuit and 
        /// pin(s) to correct position on gate.
        /// </summary>
        /// <param name="x">x-Position of the pin</param>
        /// <param name="y">y-Position of the pin</param>
        public virtual void MoveTo(int x, int y)
        {
            Debug.WriteLine("pins = " + pins.Count);
            left = x;
            top = y;

            // must move the pins too
            pins[0].X = x - GAP;
            pins[0].Y = y + GAP;
            pins[1].X = x - GAP;
            pins[1].Y = y + HEIGHT - GAP;
            pins[2].X = x + WIDTH + GAP;
            pins[2].Y = y + HEIGHT / 2;
        }

        #endregion

        #region Abstract Methods

        /// <summary>
        /// Draws the gate onto the picturebox.
        /// </summary>
        /// <param name="paper">What to display the gate on</param>
        public abstract void Draw(Graphics paper);

        /// <summary>
        /// Computes the logical result of the Gate.
        /// </summary>
        /// <returns>The logical result of the gate</returns>
        public abstract bool Evaluate();
        
        /// <summary>
        /// Creates a new copy of a selected gate.
        /// </summary>
        /// <returns>A new gate</returns>
        public abstract Gate Clone();

        #endregion
    }
}
