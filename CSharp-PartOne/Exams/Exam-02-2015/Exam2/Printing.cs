using System;
//using System.Globalization;


namespace Problem1
{
    class Problem1
    {
        static void Main()
        {
            int n, s;
            double p, realm = 500;
            //CultureInfo culture = CultureInfo.InvariantCulture;

            n = Convert.ToInt32(Console.ReadLine());
            s = Convert.ToInt32(Console.ReadLine());
            p = double.Parse(Console.ReadLine());

            double result = n*s / realm;
            double totalPrice = result * p;
            totalPrice = Math.Round(totalPrice, 2);

            Console.WriteLine("{0:F2}", totalPrice);

            Console.ReadKey();
        }
    }
}
