using System;

namespace _04_Documentation
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var input = Console.ReadLine().Replace(" ", "").ToLower();
            Console.WriteLine(input);
            var firstHalf = input.Substring(0, input.Length / 2);
            var secondHalf = input.Substring(input.Length / 2);

            Console.WriteLine(firstHalf);
            Console.WriteLine(secondHalf);

            var result = EditDistDp(firstHalf, secondHalf, firstHalf.Length, secondHalf.Length);
            Console.WriteLine(result);
        }

        private static int EditDistDp(string str1, string str2, int m, int n)
        {
            // Create a table to store results of subproblems
            var dp = new int[m + 1][];

            // Fill d[][] in bottom up manner
            for (var i = 0; i <= m; i++)
            {
                dp[i] = new int[n + 1];
                for (var j = 0; j <= n; j++)
                {
                    // If first string is empty, only option is to
                    // isnert all characters of second string
                    if (i == 0)
                    {
                        dp[i][j] = j; // Min. operations = j
                    }

                    // If second string is empty, only option is to
                    // remove all characters of second string
                    else if (j == 0)
                    {
                        dp[i][j] = i; // Min. operations = i
                    }

                    // If last characters are same, ignore last char
                    // and recur for remaining string
                    else if (str1[i - 1] == str2[j - 1])
                    {
                        dp[i][j] = dp[i - 1][j - 1];
                    }

                    // If last character are different, consider all
                    // possibilities and find minimum
                    else
                    {
                        dp[i][j] = 1 + Math.Min(dp[i][j - 1], dp[i - 1][j - 1]);
                    }
                }
            }

            return dp[m][n];
        }
    }
}
