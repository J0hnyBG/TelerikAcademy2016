using System;
using System.Collections.Generic;
using System.Linq;

namespace FindNumber
{
    internal class Startup
    {
        private static void Main(string[] args)
        {
            var nk = Console.ReadLine().Split(' ')
                            .Select(int.Parse)
                            .ToArray();
            var k = nk[1];

            var stringsToSort = Console.ReadLine().Split(' ')
                                       .ToList();

            var result = BucketSort(stringsToSort, k);

            Console.WriteLine(result[0]);
        }

        private static IList<string> BucketSort(IList<string> strings, int k)
        {
            for (var i = 0; i < 10 && strings.Count > 1; ++i)
            {
                var buckets = new List<string>[128];

                foreach (var s in strings)
                {
                    var bucketIdx = 0;
                    if (i < s.Length)
                    {
                        bucketIdx = s[i];
                    }

                    if (buckets[bucketIdx] == null)
                    {
                        buckets[bucketIdx] = new List<string>();
                    }

                    buckets[bucketIdx].Add(s);
                }

                foreach (var bucket in buckets)
                {
                    if (bucket == null)
                    {
                        continue;
                    }

                    if (k < bucket.Count)
                    {
                        strings = bucket;
                        break;
                    }

                    k -= bucket.Count;
                }
            }

            return strings;
        }
    }
}
