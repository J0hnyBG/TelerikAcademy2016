using System;

namespace _05_SearchInBits
{
    class Program
    {
        static void Main()
        {
            uint pattern = uint.Parse(Console.ReadLine());

            uint mask = ~(1 << 31);

            int n = int.Parse(Console.ReadLine());

            int occurences = 0;

            for (int i = 0; i < n; i++)
            {
                uint numberToCompare = uint.Parse(Console.ReadLine());
                //Console.WriteLine("mask: " + Convert.ToString(pattern, 2));
                numberToCompare = ((numberToCompare << 2) & mask) >> 2;
                 //TODO:
                for (int j = 0; j <= 27; j++)
                {
                    uint tempNumber = numberToCompare;
                    tempNumber = ((tempNumber << 28 - j) & mask) >> 28;

                    //uint tempNumber = (numberToCompare << 28 - j) >> 28;
                    //Console.WriteLine("j: " + j);
                    //Console.WriteLine("TempNumber: " + Convert.ToString(tempNumber, 2));
                    //Console.WriteLine("Equal: " + (tempNumber == pattern));

                    if (tempNumber ==pattern)
                    {
                        occurences++;
                    }

                }
            }
            Console.WriteLine("Occurences: " + occurences);
        }
    }
}
//40/100
//using System;

//namespace _05_SearchInBits
//{
//    class Program
//    {
//        static void Main()
//        {
//            uint mask = uint.Parse(Console.ReadLine());

//            mask = mask << 27;
//            mask = mask >> 27;

//            int n = int.Parse(Console.ReadLine());

//            int occurences = 0;

//            for (int i = 0; i < n; i++)
//            {
//                uint numberToCompare = uint.Parse(Console.ReadLine());

//                for (int j = 0; j <= 29; j++)
//                {
//                    uint tempNumber = numberToCompare << 28 - j;
//                    tempNumber = tempNumber >> 28;

//                    if ((tempNumber ^ mask) == 0)
//                    {
//                        occurences++;
//                    }

//                }
//            }
//            Console.WriteLine(occurences);
//        }
//    }
//}
