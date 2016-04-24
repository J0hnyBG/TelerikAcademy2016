using System;

namespace _02_DrunkenNumbers
{
    class Program
    {
        static void Main()
        {   
            int n = int.Parse(Console.ReadLine());

            int mitkoTotal = 0;
            
            int vladkoTotal = 0;
            

            for (int i = 0; i < n; i++)
            {
                int mitkoRound = 0;
                int vladkoRound = 0;
                int drunkenNumber = int.Parse(Console.ReadLine());
                drunkenNumber = Math.Abs(drunkenNumber);
                string drunkenString = drunkenNumber.ToString();
                

                if (drunkenString.Length % 2 == 0)
                {
                    for (int j = 0; j < drunkenString.Length / 2; j++)
                    {
                        mitkoRound += drunkenString[j] - '0';

                    }
                    for (int j = drunkenString.Length / 2; j < drunkenString.Length; j++)
                    {
                        vladkoRound += drunkenString[j] - '0';
                    }
                }
                else
                {
                    for (int j = 0; j < drunkenString.Length / 2 + 1; j++)
                    {
                        mitkoRound += drunkenString[j] - '0';
                    }
                    for (int j = drunkenString.Length / 2 ; j < drunkenString.Length; j++)
                    {
                        vladkoRound += drunkenString[j] - '0';
                    }
                }
                mitkoTotal += mitkoRound;
                vladkoTotal += vladkoRound;
            }
            if (mitkoTotal > vladkoTotal)
            {
                Console.WriteLine("M " + (mitkoTotal - vladkoTotal));
            }
            else if (vladkoTotal > mitkoTotal)
            {
                Console.WriteLine("V " + (vladkoTotal - mitkoTotal));
            }
            else
            {
                Console.WriteLine("No " + (mitkoTotal + vladkoTotal));
            }

        }
    }
}
