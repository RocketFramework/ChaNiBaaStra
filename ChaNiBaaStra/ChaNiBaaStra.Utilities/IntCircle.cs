using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*namespace ChaNiBaaStra.Utilities
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

        public int GoBack(int value)
        {
            if (Current < value)
                return max - (value - Current) + 1;
            else
                return Current - (value - 1);
        }

        public int Minus(int value)
        {
            if (Current <= value)
                return Math.Abs(Current - value - 1) % max;
            else
                return 1+ Math.Abs(12 - (Current - value)) % max;
        }

        public int MinusAbsolute(int value)
        {
            return (Current - value) % max;
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
}*/


namespace ChaNiBaaStra.Utilities
{
    public class IntCircle
    {
        private int current;
        private int max;
        private int min;
        public int Current
        {
            get { return current; }
            set { current = value; }
        }

        /// <summary>
        /// Initializes a new instance of the IntCircle class.
        /// </summary>
        /// <param name="maxNumber">The maximum number of integers to be considered for this circle.</param>
        /// <param name="startNumber">The point to start the circular movement of counting.</param>
        public IntCircle(int maxNumber, int startNumber)
        {
            if (maxNumber <= 0)
                throw new ArgumentException("maxNumber should be greater than 0.");

            max = maxNumber;
            current = startNumber;
            min = startNumber;
        }

        /// <summary>
        /// Moves forward by one position in the circle.
        /// </summary>
        public int GoForward()
        {
            current = (current % max) + 1;
            return current;
        }

        /// <summary>
        /// Moves backward by one position in the circle.
        /// </summary>
        public int GoBackward()
        {
            current = (current == 1) ? max : current - 1;
            return current;
        }

        /// <summary>
        /// Moves backward by a specific number of positions in the circle.
        /// </summary>
        /// <param name="value">The number of positions to move backward.</param>
        public int GoBack(int value)
        {
            current =  ((current - value - 1 + max) % max) + 1;
            return current;
        }

        /// <summary>
        /// Calculates the difference between the current position and the specified value in a circular manner.
        /// </summary>
        /// <param name="value">The value to subtract from the current position.</param>
        /// <returns>The difference in a circular manner.</returns>
        public int Minus(int value)
        {
            return ((current - value - 1 + max) % max) + 1;
        }

        /// <summary>
        /// Adds a specific value to the current position in a circular manner.
        /// </summary>
        /// <param name="value">The value to add to the current position.</param>
        /// <returns>The new position after adding the value in a circular manner.</returns>
        public int Add(int value)
        {
            return ((current + value - 1) % max) + 1;
        }

        /// <summary>
        /// Calculates the difference between the specified value and the current position.
        /// </summary>
        /// <param name="value">The value to subtract from the current position.</param>
        /// <returns>The difference between the specified value and the current position.</returns>
        public int ValueMinusCurrent(int value)
        {
            int difference = value - current;
            if (difference == 0)
                return min; // If value and current are the same, return 1 (assuming 1-based indexing)
            else if (difference < 0)
                return ((Math.Abs(difference) - 1) % max) + 1;
            else
                return (max - ((difference - 1) % max)) % max == 0 ? max : (max - ((difference - 1) % max)) % max;
        }

        /// <summary>
        /// Calculates the sum of the specified value and the current position.
        /// </summary>
        /// <param name="value">The value to add to the current position.</param>
        /// <returns>The sum of the specified value and the current position.</returns>
        public int ValueAddCurrent(int value)
        {
            int sum = current + value;
            if (sum <= 0)
                return (sum % max) + max;
            else
                return (sum - 1) % max + 1;
        }

        /// <summary>
        /// Gets the next value in the circle softly.
        /// </summary>
        public int Next
        {
            get
            {
                int next = (current % max) + 1;
                return next;
            }
        }

        /// <summary>
        /// Gets the previous value in the circle softly.
        /// </summary>
        public int Previous
        {
            get
            {
                int previous = (current == 1) ? max : current - 1;
                return previous;
            }
        }
    }
}

