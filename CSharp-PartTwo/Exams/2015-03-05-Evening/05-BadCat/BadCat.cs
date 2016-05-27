using System;
using System.Linq;

namespace _05_BadCat
{
    internal class BadCat
    {
        private static readonly bool[] NumbersToUse = new bool[10];
        private static readonly bool[,] Rules = new bool[10, 10];

        private static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            for (var i = 0; i < n; i++)
            {
                var line = Console.ReadLine();
                var firstNumber = line[0] - '0';
                var secondNumber = line[line.Length - 1] - '0';

                if (line.Contains("before"))
                {
                    AddRule(firstNumber, secondNumber);
                }
                else
                {
                    AddRule(secondNumber, firstNumber);
                }
            }
            Console.WriteLine(GetResult());
        }

        private static void AddRule(int n, int m)
        {
            NumbersToUse[n] = true;
            NumbersToUse[m] = true;
            Rules[n, m] = true;
        }

        private static long GetResult()
        {
            var toBeUsedCount = NumbersToUse.Count(n => n);

            long finalNumber = 0;
            for (var i = 0; i < toBeUsedCount; i++)
            {
                for (var candidate = 0; candidate <= 9; candidate++)
                {
                    if (candidate == 0 && finalNumber == 0)
                    {
                        continue;
                    }
                    if (NumbersToUse[candidate] && !HasParent(candidate))
                    {
                        finalNumber *= 10;
                        finalNumber += candidate;

                        NumbersToUse[candidate] = false;
                        RemoveAllDescendents(candidate);
                        break;
                    }
                }
            }
            return finalNumber;
        }

        private static void RemoveAllDescendents(int node)
        {
            for (var i = 0; i <= 9; i++)
            {
                Rules[node, i] = false;
            }
        }

        private static bool HasParent(int node)
        {
            for (var i = 0; i <= 9; i++)
            {
                if (Rules[i, node])
                {
                    return true;
                }
            }
            return false;
        }
    }
}