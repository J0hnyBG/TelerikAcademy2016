using System;

namespace _02_Speeds
{
    class Program
    {
        static void Main()
        {
            int numberOfCars = int.Parse(Console.ReadLine());
            double lastNumber = 0;
            //int currentSpeed = 0;

            double currentGroupLength = 0;
            double currentGroupSum = 0;

            double maxGroupLength = 0;
            double maxGroupSum = 0;

            for (int i = 0; i < numberOfCars; i++)
            {
                double currentNumber = double.Parse(Console.ReadLine());

                if (currentNumber > lastNumber) //if true they make a group
                {
                    //Calculate group speed and increment group count
                    currentGroupSum += currentNumber;
                    currentGroupLength++;
                }
                else //if current number is not part of last group
                {   
                    //reset group speed and count
                    currentGroupSum = currentNumber;
                    currentGroupLength = 1;
                }
                //if currentGroup count > maxGroupCount - new max
                if (maxGroupLength < currentGroupLength)
                {
                    //set max count to current count and max group speed
                    maxGroupLength = currentGroupLength;
                    maxGroupSum = currentGroupSum;
                }
                else if (maxGroupLength == currentGroupLength)
                { //if counts are == get the higher speed
                    maxGroupSum = Math.Max(maxGroupSum, currentGroupSum);
                }
                if (currentGroupLength==numberOfCars)
                {
                    maxGroupSum = currentGroupSum;
                }
                lastNumber = currentNumber;
            }
            Console.WriteLine(maxGroupSum);
        }
    }
}
