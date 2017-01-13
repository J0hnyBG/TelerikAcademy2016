using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace _07_Conference
{
    internal class Program
    {
        /*
        4 2
        0 1
        2 3
    */

        private static void Main(string[] args)
        {
            var nm = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var n = nm[0];
            var m = nm[1];
            var companies = new List<HashSet<int>>();
            var added = new bool[n];
            for (var i = 0; i < m; i++)
            {
                var developerPair = Console.ReadLine()
                                           .Split(' ')
                                           .Select(int.Parse)
                                           .ToArray();

                var company =
                    companies.FirstOrDefault(hs => hs.Contains(developerPair[0]) || hs.Contains(developerPair[1]));

                if (company == null)
                {
                    var hs = new HashSet<int>() { developerPair[0], developerPair[1] };
                    companies.Add(hs);
                }
                else
                {
                    company.Add(developerPair[0]);
                    company.Add(developerPair[1]);
                }

                added[developerPair[0]] = true;
                added[developerPair[1]] = true;
            }

            for (int i = 0; i < added.Length; i++)
            {
                if (!added[i])
                {
                    companies.Add(new HashSet<int>() { i });
                }
            }

            var remaining = n;
            long total = 0;
            foreach (HashSet<int> company in companies)
            {
                remaining -= company.Count;
                if (remaining <= 0)
                {
                    break;
                }

                total += company.Count * remaining;
            }

            Console.WriteLine(total);
        }
    }
}
