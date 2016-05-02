using System;

namespace _02_Speeds
{
    class Speeds
    {
        static void Main()
        {
            int numberOfCars = int.Parse(Console.ReadLine());

            int currentGroupLength = 0;
            int currentGroupSum = 0;

            int longestGroupLength = 0;
            int longestGroupSum = 0;

            bool isUpdated = false;

            int[] speed = new int[numberOfCars];

            for (int i = 0; i < numberOfCars; i++)
            {
                speed[i] = int.Parse(Console.ReadLine());
                isUpdated = false;

                if (i==0)
                {
                    currentGroupLength = 1;
                    currentGroupSum = speed[i];
                    continue;
                }
                if (speed[i] > speed[i-1])
                {
                    currentGroupLength++;
                    currentGroupSum += speed[i];
                    speed[i] = speed[i - 1];
                }
                else
                {
                    isUpdated = true;
                    if (currentGroupLength > longestGroupLength)
                    {
                        longestGroupSum = currentGroupSum;
                        longestGroupLength = currentGroupLength;
                    }
                    else if (currentGroupLength == longestGroupLength)
                    {
                        longestGroupSum = Math.Max(currentGroupSum, longestGroupSum);
                    }
                    currentGroupLength = 1;
                    currentGroupSum = speed[i];
                }
            }
            if (!isUpdated)
            {
                if (currentGroupLength > longestGroupLength)
                {
                    longestGroupSum = currentGroupSum;
                }
                else if (currentGroupLength == longestGroupLength)
                {
                    longestGroupSum = Math.Max(longestGroupSum, currentGroupSum);
                }
            }
            Console.WriteLine(longestGroupSum);
        }
    }
}
