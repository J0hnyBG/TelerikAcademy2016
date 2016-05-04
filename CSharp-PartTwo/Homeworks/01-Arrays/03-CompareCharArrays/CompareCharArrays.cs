using System;

namespace _03_CompareCharArrays
{
    internal class CompareCharArrays
    {
        private static void Main()
        {
            string first = Console.ReadLine().ToLower();
            string second = Console.ReadLine().ToLower();

            int result = first.CompareTo(second);

            switch (result)
            {
                case 1:
                    Console.WriteLine(">");
                    break;
                case -1:
                    Console.WriteLine("<");
                    break;
                case 0:
                    Console.WriteLine("=");
                    break;
            }

            //Buggy
            //int minLength = Math.Min(first.Length, second.Length);
            //int firstLength = first.Length;
            //int secondLength = second.Length;

            //for (int i = 0; i < minLength; i++)
            //{
            //    if (first[i] > second[i])
            //    {
            //        Console.WriteLine(">");
            //        break;
            //    }
            //    if (first[i] < second[i])
            //    {
            //        Console.WriteLine("<");
            //        break;
            //    }
            //    if (i == firstLength - 1 || i == secondLength - 1)
            //    {
            //        if (firstLength == secondLength)
            //        {
            //            Console.WriteLine("=");
            //            break;
            //        }
            //        if (firstLength > secondLength)
            //        {
            //            Console.WriteLine(">");
            //            break;
            //        }
            //        if (firstLength < secondLength)
            //        {
            //            Console.WriteLine("<");
            //            break;
            //        }
            //    }
            //}

            //for (int i = 0; i < first.Length; i++)
            //{
            //    firstSum += first[i];
            //}
            //for (int i = 0; i < second.Length; i++)
            //{
            //    secondSum += second[i];
            //}
            //if (firstSum == secondSum)
            //{
            //    Console.WriteLine("=");
            //}
            //else if (firstSum > secondSum)
            //{
            //    Console.WriteLine(">");
            //}
            //else
            //{
            //    Console.WriteLine("<");
            //}
        }
    }
}