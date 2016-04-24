using System;
using System.Threading;
using System.Globalization;

namespace _01_CoffeeMachine
{
    class Program
    {
        static void Main()
        {   
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            int n1 = int.Parse(Console.ReadLine());
            int n2 = int.Parse(Console.ReadLine());
            int n3 = int.Parse(Console.ReadLine());
            int n4 = int.Parse(Console.ReadLine());
            int n5 = int.Parse(Console.ReadLine());

            double givenAmount = double.Parse(Console.ReadLine());
            double drinkPrice = double.Parse(Console.ReadLine());

            if (givenAmount < drinkPrice)
            {
                Console.WriteLine("More {0:F2}",(drinkPrice - givenAmount));
            }
            else
            {
                double moneyInTrays = (0.05 * n1) + (0.1 * n2) + (0.2 * n3) + (0.5 * n4) + (1*n5);
                
                if (givenAmount == drinkPrice)
                {
                    Console.WriteLine("Yes {0:F2}", moneyInTrays);
                }
                else if (givenAmount > drinkPrice)
                {
                    double changeToGive = givenAmount - drinkPrice;
                    if (changeToGive <= moneyInTrays)
                    {
                        Console.WriteLine("Yes {0:F2}", (moneyInTrays - changeToGive));
                    }
                    else
                    {
                        Console.WriteLine("No {0:F2}", (changeToGive - moneyInTrays));
                    }
                    
                }
            }
        }
    }
}
