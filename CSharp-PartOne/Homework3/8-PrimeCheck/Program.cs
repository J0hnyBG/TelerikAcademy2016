using System;

namespace _8_PrimeCheck
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine(isPrime(n).ToString().ToLower());
            
        }

        static bool isPrime(int n)
        {

            if (n == 1 || n <= 0) return false;
            if (n == 2) return true;

            for (int i = 2; i <= Math.Ceiling(Math.Sqrt(n)); ++i)
            {
                if (n % i == 0) return false;
            }

            return true;

        }
    }
}
