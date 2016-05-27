using System;
using System.Collections.Generic;
using System.Text;

namespace _04_ConsoleJustification
{
    internal class ConsoleJustification
    {
        private static List<string> _allWords = new List<string>();
        private static int _totalWidth;
        private static StringBuilder _output = new StringBuilder();


        private static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            _totalWidth = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] words = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                _allWords.AddRange(words);
            }

            var numOfChars = 0;
            var wordsInLine = 0;
            
            //var spacesInLine = 0;
            for (int i = 0; i < _allWords.Count; i++)
            {
                numOfChars += _allWords[i].Length;
                wordsInLine++;

                #region buggy
                //if ( numOfChars > _totalWidth - wordsInLine || i == _allWords.Count - 1 )
                //{

                //    numOfChars -= _allWords[i].Length;
                //    var spacesInLine = _totalWidth - numOfChars;
                //    //do something
                //    if ( wordsInLine == 1 && i != _allWords.Count - 1 )
                //    {
                //        _output.Append(_allWords[i - 1] + "\n");
                //    }
                //    else
                //    {
                //        if ( i == _allWords.Count - 1 )
                //        {
                //            InsertRow(spacesInLine, i + 1, wordsInLine);

                //        }
                //        else
                //        {
                //            InsertRow(spacesInLine, i, wordsInLine);

                //        }
                //    }

                //    wordsInLine = 1;
                //    numOfChars = _allWords[i].Length;
                //}
                #endregion
            }
            Console.Write(_output.ToString());
        }

        private static void InsertRow(int spacesInLine, int i, int wordsInLine)
        {
            var startIndex = i - wordsInLine;
            for (int j = startIndex; j < i; j++)
            {
                _output.Append(_allWords[j] + " ");
            }
            _output.Append("\n");

        }

        //public static List<string> Wrap(string text, int maxLength)
        //{

        //    // Return empty list of strings if the text was empty
        //    if ( text.Length == 0 ) return new List<string>();

        //    var words = text.Split(' ');
        //    var lines = new List<string>();
        //    var currentLine = "";

        //    foreach ( var currentWord in words )
        //    {

        //        if ( ( currentLine.Length > maxLength ) ||
        //            ( ( currentLine.Length + currentWord.Length ) > maxLength ) )
        //        {
        //            lines.Add(currentLine);
        //            currentLine = "";
        //        }

        //        if ( currentLine.Length > 0 )
        //            currentLine += " " + currentWord;
        //        else
        //            currentLine += currentWord;

        //    }

        //    if ( currentLine.Length > 0 )
        //        lines.Add(currentLine);


        //    return lines;
        //}
    }
}