using System;
//Write a program that shows the sign (+, - or 0) of the product of three real numbers, without calculating it.
//Use a sequence of if operators.
namespace _04_MultiplicationSign
{
    class Program
    {
        static void Main()
        {
            double[] numbers = new double[3];
            numbers[0] = double.Parse(Console.ReadLine());
            numbers[1] = double.Parse(Console.ReadLine());
            numbers[2] = double.Parse(Console.ReadLine());

            int negativesCount = 0;
            bool isZero = false;
            foreach (var number in numbers)
            {
                if (number < 0)
                {
                    negativesCount++;
                }
                else if (number == 0)
                {
                    isZero = true;
                    break;
                }
            }

            if (isZero)
            {
                Console.WriteLine("0");
            }
            else if (negativesCount%2 == 1)
            {
                Console.WriteLine("-");
            }
            else
            {
                Console.WriteLine("+");
            }
        }
    }
}
