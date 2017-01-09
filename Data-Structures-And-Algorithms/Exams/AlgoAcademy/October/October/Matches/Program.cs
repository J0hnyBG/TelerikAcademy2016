using System;
using System.IO;
using System.Text;

namespace Matches
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            byte[] inputBuffer = new byte[262144];
            Stream inputStream = Console.OpenStandardInput(inputBuffer.Length);
            Console.SetIn(new StreamReader(inputStream, Console.InputEncoding, false, inputBuffer.Length));

            var first = Console.ReadLine().ToCharArray();
            var second = Console.ReadLine().ToCharArray();

            var result = LCS(first, second);
            Console.WriteLine(result);
        }

        public static int LCS(char[] str1, char[] str2)
        {
            var l = new int[str1.Length, str2.Length];
            var lcs = 0;

            for (var i = 0; i < str1.Length; i++)
            {
                for (var j = 0; j < str2.Length; j++)
                {
                    if (str1[i] == str2[j])
                    {
                        if (i == 0 || j == 0)
                        {
                            l[i, j] = 1;
                        }
                        else
                        {
                            l[i, j] = l[i - 1, j - 1] + 1;
                        }

                        if (l[i, j] > lcs)
                        {
                            lcs = l[i, j];
                        }
                    }
                    else
                    {
                        l[i, j] = 0;
                    }
                }
            }

            return lcs;
        }
    }
}
