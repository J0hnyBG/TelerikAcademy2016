using System;

namespace _05_BitsToBits
{
    internal class BitsToBits
    {
        private static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            int maxZeroCount = 0;
            int currentZeroCount = 0;

            int maxOneCount = 0;
            int currentOneCount = 0;

            int lastbit = 2;

            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());

                for (int j = 29; j >= 0; j--)
                {
                    int bit = ((1 << j) & number) >> j;

                    if (bit == 1)
                    {
                        if (lastbit == 1)
                        {
                            currentOneCount++;
                            maxOneCount = Math.Max(currentOneCount, maxOneCount);
                        }
                        else
                        {
                            currentZeroCount = 0;
                            currentOneCount = 1;
                        }
                    }
                    else //bit==0
                    {
                        if (lastbit == 0)
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
                    lastbit = bit;
                }

            }
            Console.WriteLine(maxZeroCount);
            Console.WriteLine(maxOneCount);

            #region comment

            //var n = int.Parse(Console.ReadLine());

            //int maxZeroCount = 0;
            //int currentZeroCount = 0;

            //int maxOneCount = 0;
            //int currentOneCount = 0;

            //int lastBit = 5;


            //for (int i = 0; i < n; i++)
            //{
            //    int num = int.Parse(Console.ReadLine());
            //    for (int j = 29; j >= 0; j--)
            //    {
            //        int bit = ((1 << j) & num) >> j;

            //        if (bit == 1)
            //        {
            //            if (lastBit == 1)
            //            {
            //                currentOneCount++;
            //                maxOneCount = Math.Max(maxOneCount, currentOneCount);
            //            }
            //            else
            //            {
            //                currentZeroCount = 0;
            //                currentOneCount = 1;
            //            }
            //        } // bit == 0
            //        else
            //        {
            //            if (lastBit == 0)
            //            {
            //                currentZeroCount++;
            //                maxZeroCount = Math.Max(maxZeroCount, currentZeroCount);
            //            }
            //            else
            //            {
            //                currentOneCount = 0;
            //                currentZeroCount = 1;
            //            }
            //        }
            //        lastBit = bit;
            //    }
            //}
            //maxOneCount = Math.Max(maxOneCount, currentOneCount);
            //maxZeroCount = Math.Max(maxZeroCount, currentZeroCount);

            //Console.WriteLine(maxZeroCount);
            //Console.WriteLine(maxOneCount);

            #endregion
        }
    }
}