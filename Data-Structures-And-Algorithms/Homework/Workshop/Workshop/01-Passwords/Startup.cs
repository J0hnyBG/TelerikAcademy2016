using System;
using System.Collections.Generic;
using System.Text;

namespace _01_Passwords
{
    public class Startup
    {
        private const char EqualsChar = '=';
        private const char LessThan = '<';
        private const char GreaterThan = '>';

        private static readonly Stack<char> FingerMoves = new Stack<char>();
        private static readonly Stack<char> CurrentSequence = new Stack<char>();
        private static readonly char[] Digits = "1234567890".ToCharArray();

        private static int targetPasswordIndex;
        private static int currentFoundPasswordsCount = 0;

        public static void Main()
        {
            var sequenceLength = int.Parse(Console.ReadLine());
            var movementPattern = Console.ReadLine();
            foreach (var ch in movementPattern)
            {
                FingerMoves.Push(ch);
            }

            targetPasswordIndex = int.Parse(Console.ReadLine());

            GeneratePassword(Digits.Length - 1);

            CurrentSequence.Pop();
            for (var i = 0; i < Digits.Length - 1; i++)
            {
                GeneratePassword(i);
                CurrentSequence.Pop();
            }
        }

        private static void GeneratePassword(int currentIndex)
        {
            CurrentSequence.Push(Digits[currentIndex]);

            if (FingerMoves.Count == 0)
            {
                currentFoundPasswordsCount++;
                return;
            }

            var nextOperation = FingerMoves.Pop();
            switch (nextOperation)
            {
                case EqualsChar:
                    GeneratePassword(currentIndex);
                    if (currentFoundPasswordsCount != targetPasswordIndex)
                    {
                        CurrentSequence.Pop();
                    }
                    else
                    {
                        End();
                    }
                    break;
                case LessThan:
                    for (var i = 0; i < currentIndex; i++)
                    {
                        GeneratePassword(i);
                        if (currentFoundPasswordsCount == targetPasswordIndex)
                        {
                            End();
                        }

                        CurrentSequence.Pop();
                    }

                    break;
                case GreaterThan:
                    if (currentIndex != Digits.Length - 1)
                    {
                        GeneratePassword(Digits.Length - 1);

                        if (currentFoundPasswordsCount == targetPasswordIndex)
                        {
                            End();
                        }

                        CurrentSequence.Pop();
                    }

                    if (currentFoundPasswordsCount != targetPasswordIndex)
                    {
                        for (var i = currentIndex + 1; i < Digits.Length - 1; i++)
                        {
                            GeneratePassword(i);

                            if (currentFoundPasswordsCount == targetPasswordIndex)
                            {
                                End();
                            }

                            CurrentSequence.Pop();
                        }
                    }

                    break;
                default:
                    throw new ArgumentException("Invalid movement char");
            }

            FingerMoves.Push(nextOperation);
        }

        private static void End()
        {
            var result = new StringBuilder();
            var len = CurrentSequence.Count;
            for (var i = 0; i < len; i++)
            {
                result = result.Insert(0, CurrentSequence.Pop());
            }

            Console.WriteLine(result.ToString());
            Environment.Exit(0);
        }
    }
}
