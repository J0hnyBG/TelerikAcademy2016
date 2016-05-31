using System;
using System.Collections.Generic;
using System.Linq;

namespace _03_Digits
{
    internal class Digits
    {
        private static int[,] _digits;

        private static void Main()
        {
            ReadInput();
            int sum = 0;
            var patterns = InitializeListsOfPatterns();

            for (int row = 0; row < _digits.GetLength(0) - 4; row++)
            {
                for (int col = 0; col < _digits.GetLength(1) - 2; col++)
                {
                    if (_digits[row + 2, col] == 1)
                    {
                        if ( CheckPattern(patterns[1], 1, row, col) )
                        {
                            sum += 1;
                            continue;
                        }                      
                    }
                    if (_digits[row + 1, col] == 2)
                    {
                        if (CheckPattern(patterns[2], 2, row, col))
                        {
                            sum += 2;
                            continue;
                        }
                    }
                    int currentDigit = _digits[row, col];
                    if (CheckPattern(patterns[currentDigit], currentDigit, row, col))
                    {
                        sum += currentDigit;
                    }
                }
            }

            Console.WriteLine(sum);
        }

        static bool CheckPattern(bool[,] pattern, int digit, int row, int col)
        {
            for (int i = 0; i < pattern.GetLength(0); i++)
            {
                for (int j = 0; j < pattern.GetLength(1); j++)
                {
                    if (pattern[i, j])
                    {
                        if (_digits[row + i, col + j] != digit)
                        {
                            return false;
                        }
                    }

                }
            }
            return true;
        }
        private static List<bool[,]> InitializeListsOfPatterns()
        {
            var list = new List<bool[,]>();
            list.Add(new bool[,]
            {
                //faking zero
            });
            //one
            list.Add(new bool[,]
            {
                { false, false, true},
                { false, true, true },
                { true, false, true },
                { false, false, true},
                { false, false, true}
            });
            //two
            list.Add(new bool[,]
            {
                { false, true, false},
                { true, false, true },
                { false, false, true },
                { false, true, false},
                { true, true, true}
            });
            //three
            list.Add(new bool[,]
            {
                { true, true, true},
                { false, false, true },
                { false, true, true },
                { false, false, true},
                { true, true, true}
            });
            //four
            list.Add(new bool[,]
            {
                { true, false, true},
                { true, false, true },
                { true, true, true },
                { false, false, true},
                { false, false, true}
            });
            //five
            list.Add(new bool[,]
            {
                { true, true, true},
                { true, false, false },
                { true, true, true },
                { false, false, true},
                { true, true, true}
            });
            //six
            list.Add(new bool[,]
            {
                { true, true, true},
                { true, false, false },
                { true, true, true },
                { true, false, true},
                { true, true, true}
            });
            //seven
            list.Add(new bool[,]
            {
                { true, true, true},
                { false, false, true },
                { false, true, false },
                { false, true, false},
                { false, true, false}
            });
            //eight
            list.Add(new bool[,]
            {
                { true, true, true},
                { true, false, true },
                { false, true, false },
                { true, false, true},
                { true, true, true}
            });
            //nine
            list.Add(new bool[,]
            {
                { true, true, true},
                { true, false, true },
                { false, true, true },
                { false, false, true},
                { true, true, true}
            });
            return list;
        }

        private static void ReadInput()
        {
            int n = int.Parse(Console.ReadLine());
            _digits = new int[n, n];

            for (int row = 0; row < n; row++)
            {
                var line = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                for (int col = 0; col < line.Length; col++)
                {
                    _digits[row, col] = line[col];
                }
            }
        }
    }
}