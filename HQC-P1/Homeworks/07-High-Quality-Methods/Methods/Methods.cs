namespace Methods
{
    using System;

    /// <summary>
    /// A collection of methods for a homework.
    /// </summary>
    public class Methods
    {
        /// <summary>
        /// Calculates the area of a triangle by the given sides.
        /// </summary>
        /// <param name="a">First triangle side.</param>
        /// <param name="b">Second triangle side.</param>
        /// <param name="c">Third triangle side.</param>
        /// <returns>The calculated area.</returns>
        private static double CalcTriangleArea(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
            {
                throw new ArgumentException("All sides should be positive!");
            }

            double s = (a + b + c) / 2;
            double area = Math.Sqrt(s * (s - a) * (s - b) * (s - c));
            return area;
        }

        /// <summary>
        /// Converts a digit to an English string representation.
        /// </summary>
        /// <param name="number">The digit to be converted.</param>
        /// <returns>An English string representation of the digit.</returns>
        private static string DigitToString(int number)
        {
            switch (number)
            {
                case 0:
                    return "zero";
                case 1:
                    return "one";
                case 2:
                    return "two";
                case 3:
                    return "three";
                case 4:
                    return "four";
                case 5:
                    return "five";
                case 6:
                    return "six";
                case 7:
                    return "seven";
                case 8:
                    return "eight";
                case 9:
                    return "nine";
                default:
                    throw new ArgumentException("Invalid number");
            }
        }

        /// <summary>
        /// Finds the maximal value of the passed parameters.
        /// </summary>
        /// <param name="numbers">The variable number of parameters to be processed.</param>
        /// <returns>The max value of the passed parameters.</returns>
        private static int FindMax(params int[] numbers)
        {
            if (numbers == null)
            {
                throw new ArgumentNullException(nameof(numbers));
            }

            if (numbers.Length == 0)
            {
                throw new ArgumentException("No parameters passed!");
            }

            var max = int.MinValue;
            foreach (var number in numbers)
            {
                if (number > max)
                {
                    max = number;
                }
            }

            return max;
        }

        /// <summary>
        /// Prints a number to the console, according to a specified format.
        /// </summary>
        /// <param name="number">The number to be printed.</param>
        /// <param name="format">The format string.</param>
        private static void PrintAsNumber(object number, string format)
        {
            switch (format)
            {
                case "f":
                    Console.WriteLine("{0:f2}", number);
                    break;
                case "%":
                    Console.WriteLine("{0:p0}", number);
                    break;
                case "r":
                    Console.WriteLine("{0,8}", number);
                    break;
                default:
                    throw new ArgumentException("Invalid format provided!");
            }
        }

        /// <summary>
        /// Calculates the distance between two points on a plane.
        /// </summary>
        /// <param name="x1">First point x coordinate.</param>
        /// <param name="y1">First point y coordinate.</param>
        /// <param name="x2">Second point x coordinate.</param>
        /// <param name="y2">Second point y coordinate.</param>
        /// <returns>The distance between the two points.</returns>
        private static double CalcDistance(double x1, double y1, double x2, double y2)
        {
            double distance = Math.Sqrt(((x2 - x1) * (x2 - x1)) + ((y2 - y1) * (y2 - y1)));
            return distance;
        }

        /// <summary>
        /// Converts two points in a plane to two booleans, indicating whether there is a horizontal or vertical distance between them. 
        /// </summary>
        /// <param name="x1">First point x coordinate.</param>
        /// <param name="y1">First point y coordinate.</param>
        /// <param name="x2">Second point x coordinate.</param>
        /// <param name="y2">Second point y coordinate.</param>
        /// <param name="isHorizontal">Out variable indicating whether there is a horizontal distance between the two points.</param>
        /// <param name="isVertical">Out variable indicating whether there is a vertical distance between the two points.</param>
        private static void GetDirections(
            double x1,
            double y1,
            double x2,
            double y2,
            out bool isHorizontal,
            out bool isVertical)
        {
            // Compare the absolute difference between two points with an arbitrary tolerance 
            // to prevent rounding errors.
            const double Tolerance = 0.000000000001;
            isHorizontal = Math.Abs(y1 - y2) < Tolerance;
            isVertical = Math.Abs(x1 - x2) < Tolerance;
        }

        /// <summary>
        /// The startup method where other methods are invoked.
        /// </summary>
        private static void Main()
        {
            Console.WriteLine(CalcTriangleArea(3, 4, 5));

            Console.WriteLine(DigitToString(5));

            Console.WriteLine(FindMax(5, -1, 3, 2, 14, 2, 3));

            PrintAsNumber(1.3, "f");
            PrintAsNumber(0.75, "%");
            PrintAsNumber(2.30, "r");

            bool horizontal, vertical;
            var x1 = 3;
            var x2 = -1;
            var y1 = 3;
            var y2 = 2.5;
            Console.WriteLine(CalcDistance(x1, x2, y1, y2));
            GetDirections(x1, x2, y1, y2, out horizontal, out vertical);
            Console.WriteLine("Horizontal? " + horizontal);
            Console.WriteLine("Vertical? " + vertical);

            Student peter = new Student() { FirstName = "Peter", LastName = "Ivanov" };
            peter.OtherInfo = "From Sofia, born at 17.03.1992";

            Student stella = new Student() { FirstName = "Stella", LastName = "Markova" };
            stella.OtherInfo = "From Vidin, gamer, high results, born at 03.11.1993";

            Console.WriteLine(
                "{0} older than {1} -> {2}",
                peter.FirstName, 
                stella.FirstName, 
                peter.IsOlderThan(stella));
        }
    }
}
