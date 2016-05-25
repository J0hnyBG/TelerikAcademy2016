using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_MagicWords
{
    class MagicWords
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            var words = new string[n + 1];
            List<string> list = new List<string>();

            list.Insert();
            for (int i = 0; i < n; i++)
            {
                var word = Console.ReadLine();
                int position = (word.Length - 1) % (n + 1);
                words[position] = word;
                
            }
            //words = words.Where(x => !string.IsNullOrEmpty(x)).ToArray();

            for (int i = 0; i < words.Length; i++)
            {
               // Console.Write(words[i][0]);
            }
        }

        private static void Swap(IList<int> list, int indexA, int indexB)
        {
            int tmp = list[indexA];
            list[indexA] = list[indexB];
            list[indexB] = tmp;
        }
    }
}
