using System;

namespace _02_Products.Collections
{
    public class Range : IComparable<Range>
    {
        private readonly int bottom;
        private readonly int top;

        public Range(int bottom, int top)
        {
            this.bottom = bottom;
            this.top = top;
        }

        public int CompareTo(Range other)
        {
            if (this.bottom < other.bottom && this.top < other.top)
            {
                return -1;
            }
            if (this.bottom > other.bottom && this.top > other.top)
            {
                return 1;
            }
            if (this.bottom == other.bottom && this.top == other.top)
            {
                return 0;
            }

            throw new ArgumentException("Incomparable values (overlapping)");
        }

        /// <summary>
        ///     Returns 0 if value is in the specified range;
        ///     less than 0 if value is above the range;
        ///     greater than 0 if value is below the range.
        /// </summary>
        public int CompareTo(int value)
        {
            if (value < this.bottom)
            {
                return 1;
            }
            if (value > this.top)
            {
                return -1;
            }

            return 0;
        }

        /// <summary>Returns a string that represents the current object.</summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return $"{this.bottom} to {this.top}";
        }
    }
}
