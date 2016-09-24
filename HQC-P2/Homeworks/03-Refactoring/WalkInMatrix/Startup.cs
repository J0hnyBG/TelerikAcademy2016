namespace WalkInMatrix
{
    using System;

    using Calculator;

    internal class WalkInMatrica
    {
        private const string EnterNumberPrompt = "Enter a positive number ";

        private static void Main()
        {
            Console.WriteLine(EnterNumberPrompt);
            var input = Console.ReadLine();
            var matrixSize = 0;
            while (!int.TryParse(input, out matrixSize)
                   || matrixSize < 0
                   || matrixSize > 100)
            {
                Console.WriteLine(EnterNumberPrompt);
                input = Console.ReadLine();
            }

            var matrix = RotatingWalkInMatrixCalculator.Calculate(matrixSize);

            for (var row = 0; row < matrixSize; row++)
            {
                for (var col = 0; col < matrixSize; col++)
                {
                    Console.Write("{0,3}", matrix[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}
