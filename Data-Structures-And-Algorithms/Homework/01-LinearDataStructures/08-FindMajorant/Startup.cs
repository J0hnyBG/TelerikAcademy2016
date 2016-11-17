using System;
using System.Linq;

namespace _08_FindMajorant
{
    internal class Startup
    {
        private static void Main()
        {
            var numbers = new[] { 2, 2, 3, 3, 2, 3, 4, 3, 3 };
            var distinctNumbers = numbers.Distinct();
            int? majorant = null;

            foreach (var distinctNumber in distinctNumbers)
            {
                var numberCount = numbers.Count(n => n == distinctNumber);

                if (numberCount >= (numbers.Length / 2) + 1)
                {
                    majorant = distinctNumber;
                    break;
                }
            }

            Console.WriteLine(majorant == null
                            ? "No majorant found!"
                            : $"Majorant -> {majorant}");
        }
    }
}
