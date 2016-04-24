using System;

namespace _05_Neurons
{
    internal class NeuronMapping
    {
        private static void Main()
        {
            const uint bit = (uint)1;

            while (true)
            {
                string inputString = Console.ReadLine();
                if (inputString == "-1")
                {
                    break;
                }
                uint inputNumber = uint.Parse(inputString);

                uint output = 0;
                bool isInside = false;
                int consecutiveBits = 0;

                for (int i = 0; i < 32; ++i)
                {
                    //uint currentBit = (inputNumber & (bit << i)) >> i;
                    uint mask = (bit << i);

                    if ((inputNumber & mask) == 0)
                    {
                        if (isInside)
                        {
                            output = output | mask;
                        }
                        continue;
                    }
                    else
                    {
                        consecutiveBits++;
                        isInside = !isInside;

                        while (i < 32 && (inputNumber & (bit << i)) != 0)
                        {
                            i += 1;
                        }
                        i = i - 1;
                    }

                }
                if (consecutiveBits != 2)
                {
                    output = 0;
                }
                Console.WriteLine(output);
            }
        }
    }
}