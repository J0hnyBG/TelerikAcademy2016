namespace WalkInMatrix
{
    using System;

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

            for (var r = 0; r < matrixSize; r++)
            {
                for (var c = 0; c < matrixSize; c++)
                {
                    Console.Write("{0,3}", matrix[r, c]);
                }

                Console.WriteLine();
            }
        }
    }
}
