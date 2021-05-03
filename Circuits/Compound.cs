using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Diagnostics;

namespace Circuits
{
    /// <summary>
    /// This class implements a Compound Gate
    /// based on the gates in it.
    /// </summary>
    public class Compound : Gate
    {
        //####################################################################
        //# Instance Variables
        /// <summary>
        /// List of all gates in a Compound Gate.
        /// </summary>
        protected List<Gate> _gateList;

        /// <summary>
        /// The coordinates of all the gates to determin the 
        /// </summary>
        protected int _maxX, _maxY;


        //####################################################################
        //# Constructor
        /// <summary>
        /// Initialise a new Compoound Gate object.
        /// </summary>
        public Compound(int x, int y)
        {
            _gateList = new List<Gate>();
            
            MoveTo(x, y);
        }

        #region Read / Write Properties

        /// <summary>
        /// Gets the list of Gates in a Compound Gate.
        /// </summary>
        public List<Gate> GateList
        {
            get { return _gateList; }
        }

        /// <summary>
        /// Get the width of the Compound Gate.
        /// </summary>
        public int CompoundWidth
        {
            get
            {
                return _maxX + WIDTH;             
            }
        }
        
        /// <summary>
        /// Get the height of the Compound Gate.
        /// </summary>
        public int CompoundHeight
        {
            get
            {
                return _maxY + HEIGHT;
            }
        }

        /// <summary>
        /// Gets and Sets whether the Compound Gate is selected,
        /// if one gate is selected, then ALL gates will be selected.
        /// </summary>
        public override bool Selected
        {
            get
            {
                return selected;
            }
            set
            {
                selected = value;

                //If the Compound is selected then all gates will have the same value
                if (selected == true)
                {
                    foreach (Gate g in GateList)
                    {
                        g.Selected = true;
                    }
                }
                else
                {
                    foreach (Gate g in GateList)
                    {
                        g.Selected = false;
                    }
                }
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Add a gate in the circuit to the list.
        /// </summary>
        /// <param name="gate">The gate to be added to the list</param>
        public void AddGate(Gate gate)
        {
            GateList.Add(gate);
        }

        /// <summary>
        /// Checks if the mouse is on the area of the Compound Gate.
        /// </summary>
        /// <param name="x">x-Position of the mouse</param>
        /// <param name="y">y-Position of the mouse</param>
        /// <returns>Whether or not the mouse is over the Compound Gate</returns>
        public override bool IsMouseOn(int x, int y)
        {
            if (left <= x && x < left + CompoundWidth 
                && top <= y && y < top + CompoundHeight)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Moves all the gates in the compound around their relative position
        /// from where they were inserted.
        /// </summary>
        /// <param name="x">x-Position of the Gate</param>
        /// <param name="y">y-Position of the Gate</param>
        public override void MoveTo(int x, int y)
        {
            left = x;
            top = y;

            //Give the max variables to compare the values of the gates to
            _maxX = 10000;
            _maxY = 10000;
            
            foreach(Gate g in GateList)
            {
                if (g.Left < _maxX)
                    _maxX = g.Left;
                if (g.Top < _maxY)
                    _maxY = g.Top;
            }         

            //Move each gate in the compound
            foreach (Gate g in GateList)
            {    
                g.MoveTo(x + (g.Left - _maxX), y + (g.Top - _maxY));                
            }
        }

        /// <summary>
        /// Draws the Compound Gate in the Circuit.
        /// </summary>
        /// <param name="paper"></param>
        public override void Draw(Graphics paper)
        {
            //Draw each gate in the compound
            foreach (Gate g in GateList)
            {
                g.Draw(paper);
            }                 
        }

        /// <summary>
        /// Computes the logical result of the Compound Gate
        /// based on the gates in the list.
        /// </summary>
        /// <returns>The logical result of the Gate</returns>
        public override bool Evaluate()
        {
            foreach(Gate g in GateList)
            {
             return g.Evaluate();
            }
            return false;
        }

        /// <summary>
        /// Creates a copy of a selected Compound Gate.
        /// </summary>
        /// <returns>A new Compound Gate</returns>
        public override Gate Clone()
        {
            Compound compoundClone = new Compound(0, 0);

            //Add each gate in the compound into the clone
            foreach (Gate g in GateList)
            {
                compoundClone.AddGate(g);
                return g;
            }
            return compoundClone;
        }

        #endregion
    }
}
