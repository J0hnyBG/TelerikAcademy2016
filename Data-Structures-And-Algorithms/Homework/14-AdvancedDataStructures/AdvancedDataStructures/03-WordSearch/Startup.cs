using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace _03_WordSearch
{
    internal class Startup
    {
        private const string FilePath = "../../asd.txt";
        private const int NumberOfSearchWords = 1000;
        private static readonly Random random = new Random();
        private static readonly IDictionary<string, int> wordCounts = new Dictionary<string, int>();

        private static void Main(string[] args)
        {
            // May take a while to read and prepare file depending on its size
            var lines = File.ReadAllLines(FilePath);
            var wordTrie = new Trie();
            PrepareWordTrie(wordTrie, lines);

            Console.WriteLine($"Trie initialized. Begin searching.");

            var searchWords = wordCounts.Keys.ToList();

            var st = new Stopwatch();
            st.Start();
            foreach (var word in searchWords)
            {
                wordCounts[word] = wordTrie.CountWord(word);
            }

            st.Stop();

            foreach (var word in searchWords)
            {
                Console.WriteLine($"\"{word}\" appears {wordCounts[word]} times.");
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Counted {NumberOfSearchWords} words in {st.ElapsedMilliseconds}ms.");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        private static void PrepareWordTrie(Trie wordTrie, IEnumerable<string> lines)
        {
            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }

                var wordsInLine = new string(line.Where(c => !char.IsPunctuation(c) && c != '$')
                                                 .ToArray())
                    .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                if (wordsInLine.Length <= 0)
                {
                    continue;
                }

                var wordIndex = random.Next(0, wordsInLine.Length);
                var word = wordsInLine[wordIndex];
                if (wordCounts.Count < NumberOfSearchWords && !wordCounts.ContainsKey(word))
                {
                    wordCounts.Add(word, 0);
                }

                wordTrie.InsertRange(wordsInLine);
            }
        }
    }
}
