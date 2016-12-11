using System;
using System.Text;

namespace _02_Pattern
{
    internal class MainClass
    {
        public static void Main()
        {
            var figure = "urd";
            // Your solution goes here
            var n = int.Parse(Console.ReadLine());

            var iterations = n;
            while (iterations > 1)
            {
                var nextFigure = new StringBuilder();

                for (var i = figure.Length - 1; i >= 0; i--)
                {
                    var letter = figure[i];
                    nextFigure.Append(RotateAnticlockwise(letter));
                }

                nextFigure.Append('u');
                nextFigure.Append(figure);
                nextFigure.Append('r');
                nextFigure.Append(figure);
                nextFigure.Append('d');

                for (var i = figure.Length - 1; i >= 0; i--)
                {
                    var letter = figure[i];
                    nextFigure.Append(RotateClockwise(letter));
                }

                figure = nextFigure.ToString();

                iterations = iterations - 1;
            }

            Console.WriteLine(figure);
        }

        private static char RotateClockwise(char letter)
        {
            switch (letter)
            {
                case 'u':
                    return 'r';
                case 'r':
                    return 'd';
                case 'd':
                    return 'l';
                case 'l':
                    return 'u';
                default:
                    throw new ArgumentException("Letter must be a valid direction!");
            }
        }

        private static char RotateAnticlockwise(char letter)
        {
            switch (letter)
            {
                case 'u':
                    return 'l';
                case 'r':
                    return 'u';
                case 'd':
                    return 'r';
                case 'l':
                    return 'd';
                default:
                    throw new ArgumentException("Letter must be a valid direction!");
            }
        }
    }
}
