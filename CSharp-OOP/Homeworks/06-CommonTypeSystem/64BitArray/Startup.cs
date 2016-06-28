namespace _64BitArray
{
    using System;

    internal class Startup
    {
        private static void Main()
        {
            var bitArray = new BitArray64(4611686018427387904);

            Console.WriteLine("Original bitarray:");

            Console.WriteLine(bitArray);

            Console.WriteLine("Changed first bit to 1:");
            bitArray[0] = 1;
            Console.WriteLine(bitArray);

            Console.WriteLine("Summing the bits in the bitarray with foreach:");

            int sum = 0;
            foreach ( var bit in bitArray)
            {
                sum += bit;
            }
            Console.WriteLine(sum);

            var bitArray2 = new BitArray64(4611686018427387904);

            Console.WriteLine("Comparing the original bitarray with the modified one: ");
            Console.WriteLine("Are they equal? " + (bitArray2 == bitArray));

           
        }
    }
}