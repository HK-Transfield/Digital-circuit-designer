using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Diagnostics;

namespace Circuits
{
    /// <summary>
    /// This class implements an input Source with one output.
    /// </summary>
    class InputSource : Gate
    {
        //####################################################################
        //# Instance Variables
        /// <summary>
        /// A bool that toggles on and off
        /// </summary>
        private bool _inputVoltage;

        /// <summary>
        /// The brush to draw the Input Source
        /// </summary>
        private Brush _brush;

        //####################################################################
        //# Constructor
        /// <summary>
        /// Initialises a new Input source object.
        /// </summary>
        /// <param name="x">x-Position of the gate</param>
        /// <param name="y">y-Position of the gate</param>
        public InputSource(int x, int y)
        {
            _inputVoltage = false;
            pins.Add(new Pin(this, false, 20));
            MoveTo(x, y); // move the gate and position the pins
        }

        public override void MoveTo(int x, int y)
        {
            Debug.WriteLine("pins = " + pins.Count);
            left = x;
            top = y;

            pins[0].X = x + IO_SIZE + IO_SIZE / 2;
            pins[0].Y = y + IO_SIZE / 2;
        }

        #region Public Methods

        /// <summary>
        /// True if the given (x,y) position is roughly
        /// on top of this gate.
        /// Uses the new size of the input.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public override bool IsMouseOn(int x, int y)
        {
            if (left <= x && x < left + IO_SIZE && top <= y && y < top + IO_SIZE)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Toggles the input when users click on the input source.
        /// </summary>
        public void ToggleInput()
        {
            if(selected && _inputVoltage == false || !selected && _inputVoltage == true)//If the input has been selected and currently toggled off
            {
                _brush = Brushes.LightGreen;
                _inputVoltage = true;
            }
            else //If the input has been selected and is currently toggled on
            {
                _brush = normalBrush;
                _inputVoltage = false;
            }
        }

        /// <summary>
        /// Draws an Input Source Gate onto the ciruit.
        /// </summary>
        /// <param name="paper">The graphics object to display the gate on</param>
        public override void Draw(Graphics paper)
        {   
            if (selected)
            {
                ToggleInput();
                paper.DrawRectangle(selectedPen, left, top, IO_SIZE, IO_SIZE);          
            }
            else
            {
                ToggleInput();            
            }
            foreach (Pin p in pins)
                p.Draw(paper);

            paper.FillRectangle(_brush, left, top, IO_SIZE, IO_SIZE);
        }

        /// <summary>
        /// Evaluates the value of the input source.
        /// </summary>
        /// <returns>The logical result of the gate</returns>
        public override bool Evaluate()
        {
            return _inputVoltage;
        }

        /// <summary>
        /// Makes a copy of the selected Input Source.
        /// </summary>
        /// <returns>A new Input Source Gate</returns>
        public override Gate Clone()
        {
            Gate inputSourceClone = new InputSource(0, 0);

            return inputSourceClone;
        }

        #endregion
    }
}
