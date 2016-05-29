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
            List<string> list = new List<string>(n);

            for (int i = 0; i < n; i++)
            {
                list.Add("");
            }
            for (int i = 0; i < n; i++)
            {
                var word = Console.ReadLine();
                int position = (word.Length ) % ( n + 1 );
                list.Insert(position, word);
            }
            list.RemoveAll(string.IsNullOrEmpty);
            //for (int i = 0; i < list.Count; i++)
            //{
            //    int position = ( list[i].Length ) % ( n + 1 );
            //    Swap(list, position - 1, i);
            //}
        }

        private static void Swap(IList<string> list, int indexA, int indexB)
        {
            string tmp = list[indexA];
            list[indexA] = list[indexB];
            list[indexB] = tmp;
        }
    }
}
