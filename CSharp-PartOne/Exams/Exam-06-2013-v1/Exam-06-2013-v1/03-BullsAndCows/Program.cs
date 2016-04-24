using System;
using System.Collections.Generic;

namespace _03_BullsAndCows
{
    class Program
    {
        static void Main()
        {
            //Find possible guess numbers, when given the secret number, the bulls and the cows
            string secretNumber = "2228";
            char[] secretArray = secretNumber.ToCharArray();
            int positionMatches = 2; //bulls - match the position and the number
            int numberMatches = 1; //cows - match the number, but not the position
            
            var allFound = false;

            List<int> guessNumbers = new List<int>();

            while (!allFound)
            {


                for (int i = 0; i < 10; i++)
                {
                    
                }
            }
        }
    }
}
