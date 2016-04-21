using System;

namespace _05_SequenceOfBits
{
    class SequenceOfBits
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            int maxZeroCount = 0;
            int currentZeroCount = 0;

            int maxOneCount = 0;
            int currentOneCount = 0;

            int lastBit = 2;

            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());

                for (int j = 29; j >= 0; j--)
                {
                    //Get jth bit value
                    int bit = ((1 << j) & number) >> j;

                    if (bit == 1)
                    {
                        
                        if (lastBit == 1)
                        {
                            currentOneCount++;
                            maxOneCount = Math.Max(currentOneCount, maxOneCount);
                        }
                        else //lastbit == 0
                        {
                            currentOneCount = 1;
                            currentZeroCount = 0;
                        }
                    }
                    else //bit == 0
                    {
                        if (lastBit == 0)
                        {
                            currentZeroCount++;
                            maxZeroCount = Math.Max(currentZeroCount, maxZeroCount);
                        }
                        else
                        {
                            currentOneCount = 0;
                            currentZeroCount = 1;
                        }
                    }
                    lastBit = bit;
                }     
            }
            maxOneCount = Math.Max(currentOneCount, maxOneCount);
            maxZeroCount = Math.Max(currentZeroCount, maxZeroCount);

            Console.WriteLine(maxOneCount);
            Console.WriteLine(maxZeroCount);


        }
    }
}
