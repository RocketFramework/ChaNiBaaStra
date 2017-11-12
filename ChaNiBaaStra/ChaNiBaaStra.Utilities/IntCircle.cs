using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChaNiBaaStra.Utilities
{
    public class IntCircle
    {
        private int current;
        public int Current
        {
            get
            {
                return current;
            }
            set {
                current = value; }
        }
        int start;
        int max;
        /// <summary>
        /// Move around a circle of integers starting from 1 to the max number
        /// </summary>
        /// <param name="maxNumber">maximum number of intergers to be considered for this circle</param>
        /// <param name="startNumber">point to start the circular movement of counting</param>
        public IntCircle(int maxNumber, int startNumber)
        {
            max = maxNumber;
            start = startNumber;
            Current = start;
        }

        /// <summary>
        /// Move forward firmly
        /// </summary>
        /// <returns>next values </returns>
        public int GoForward()
        {
            Current++;
            if (Current > max)
                Current = Current % max;
            return Current;
        }

        /// <summary>
        /// Move backward firmly
        /// </summary>
        /// <returns>previous value</returns>
        public int GoBackward()
        {
            Current--;
            if (Current <= 0)
                Current = max;
            return Current;
        }

        public int Minus(int value)
        {
            return Math.Abs(Current - value) % max;
        }

        public int Add(int value)
        {
            return (Current + value) % max;
        }
        public int ValueMinusCurrent(int value)
        {
            int i = Math.Abs(value - current);
            return (i % max != 0) ? i % max : i;
        }

        public int ValueAddCurrent(int value)
        {
            int i = Math.Abs(value + current);
            return (i % max != 0) ? i % max : i;
        }
        /// <summary>
        /// get the next value softly
        /// </summary>
        public int Next
        {
            get
            {
                int i = GoForward();
                GoBackward();
                return i;
            }
        }

        /// <summary>
        /// get the previously softly
        /// </summary>
        public int Previous
        {
            get
            {
                int i = GoBackward();
                GoForward();
                return i;
            }
        }
    }
}
