//using System;

//namespace _05_SearchInBits
//{
//    class Program
//    {
//        static void Main()
//        {
//            uint pattern = uint.Parse(Console.ReadLine());

//            int mask = ~(1 << 31);

//            int n = int.Parse(Console.ReadLine());

//            int occurences = 0;

//            for (int i = 0; i < n; i++)
//            {
//                int numberToCompare = int.Parse(Console.ReadLine());
//                //Console.WriteLine("mask: " + Convert.ToString(pattern, 2));
//                numberToCompare = ((numberToCompare << 2) & mask) >> 2;
//                 //TODO:
//                for (int j = 0; j <= 25; j++)
//                {
//                    int tempNumber = numberToCompare;
//                    tempNumber = ((tempNumber << 27 - j) & mask) >> 27;

//                    //uint tempNumber = (numberToCompare << 28 - j) >> 28;
//                    //Console.WriteLine("j: " + j);
//                    //Console.WriteLine("TempNumber: " + Convert.ToString(tempNumber, 2));
//                    //Console.WriteLine("Equal: " + (tempNumber == pattern));

//                    if (tempNumber ==pattern)
//                    {
//                        occurences++;
//                    }

//                }
//            }
//            Console.WriteLine(occurences);
//        }
//    }
//}
//40/100
using System;

namespace _05_SearchInBits
{
    class Program
    {
        static void Main()
        {
            uint pattern = uint.Parse(Console.ReadLine());

            //pattern = pattern << 27;
            //pattern = pattern >> 27;

            uint mask = ~(1 << 31);

            int n = int.Parse(Console.ReadLine());

            int occurences = 0;

            for (int i = 0; i < n; i++)
            {
                uint numberToCompare = uint.Parse(Console.ReadLine());
                //numberToCompare = ((numberToCompare << 2) & mask ) >> 2;
               Console.WriteLine("Pattern: " + Convert.ToString(pattern, 2));
                for (int j = 0; j <= 25; j++)
                {
                    uint tempNumber = numberToCompare;
                    tempNumber = ((tempNumber << 27 - j) & mask)>>27;

                    Console.WriteLine("j: " + j);
                    Console.WriteLine("TempNumber: " + Convert.ToString(tempNumber, 2));
                    Console.WriteLine("Equal: " + (tempNumber == pattern));

                    if ((tempNumber ==pattern))
                    {
                        occurences++;
                    }

                }
            }
            Console.WriteLine(occurences);
        }
    }
}
