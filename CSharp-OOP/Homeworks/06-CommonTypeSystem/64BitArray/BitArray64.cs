namespace _64BitArray
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    internal class BitArray64 :IEnumerable<int>
    {
        public BitArray64(ulong number)
        {
            this.Number = number;
        }

        public ulong Number { get; set; }

        public int this[int pos]
        {
            get
            {
                if (pos < 0 || pos > 63)
                {
                    throw new IndexOutOfRangeException();
                }
                return ((int) (this.Number >> pos) & 1);
            }
            set
            {
                if ( pos < 0 || pos > 63 )
                {
                    throw new IndexOutOfRangeException();
                }
                if (value != 1 && value != 0)
                {
                    throw new ArgumentException("Bit value must be 1 or 0!");
                }

                if (((int)(this.Number >> pos) & 1) != value)
                {
                    this.Number ^= (1ul << pos);
                }
            }
        }

        public override string ToString()
        {
            var output = Convert.ToString((long) this.Number, 2);

            return output.PadLeft(64, '0');
        }

        public override bool Equals(object obj)
        {
            if (!(obj is BitArray64))
            {
                return false;
            }
            return this.Number.Equals(((BitArray64) obj).Number);
        }

        public override int GetHashCode()
        {
            return this.Number.GetHashCode();
        }

        public static bool operator ==(BitArray64 arr1, BitArray64 arr2)
        {
            return arr1.Equals(arr2);
        }

        public static bool operator !=(BitArray64 arr1, BitArray64 arr2)
        {

            return !arr1.Equals(arr2);
        }

       
        public IEnumerator<int> GetEnumerator()
        {
            for (var i = 0; i < 64; i++)
            {
                yield return this[i];
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
