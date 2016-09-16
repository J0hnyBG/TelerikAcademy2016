using System;
using System.Collections.Generic;
using System.Text;

class ExceptionsHomework
{
    public static T[] Subsequence<T>(T[] arr, int startIndex, int count)
    {
        if (arr == null)
        {
            throw new ArgumentNullException(nameof(arr));
        }

        if (arr.Length <= startIndex)
        {
            throw new IndexOutOfRangeException("startIndex cannot be larger than the size of the array!");
        }

        if (arr.Length < startIndex + count)
        {
            throw new IndexOutOfRangeException("The sum of startIndex and count cannot be larger than the size of the array!");
        }

        List<T> result = new List<T>();
        for (var i = startIndex; i < startIndex + count; i++)
        {
            result.Add(arr[i]);
        }

        return result.ToArray();
    }

    public static string ExtractEnding(string str, int count)
    {
        if (count >= str.Length)
        {
            return str;
            //throw new ArgumentOutOfRangeException(nameof(count));
        }

        var result = new StringBuilder();
        for (var i = str.Length - count; i < str.Length; i++)
        {
            result.Append(str[i]);
        }

        return result.ToString();
    }

    public static bool IsPrime(int number)
    {
        var squareRootOfNumber = Math.Sqrt(number);
        for (var divisor = 2; divisor <= squareRootOfNumber; divisor++)
        {
            if (number % divisor == 0)
            {
                return false;
            }
        }

        return true;
    }

    private static void Main()
    {
        var substr = Subsequence("Hello!".ToCharArray(), 2, 3);
        Console.WriteLine(substr);

        var subarr = Subsequence(new int[] {-1, 3, 2, 1}, 0, 2);
        Console.WriteLine(String.Join(" ", subarr));

        var allarr = Subsequence(new int[] {-1, 3, 2, 1}, 0, 4);
        Console.WriteLine(String.Join(" ", allarr));

        var emptyarr = Subsequence(new int[] {-1, 3, 2, 1}, 0, 0);
        Console.WriteLine(String.Join(" ", emptyarr));

        Console.WriteLine(ExtractEnding("I love C#", 2));
        Console.WriteLine(ExtractEnding("Nakov", 4));
        Console.WriteLine(ExtractEnding("beer", 4));
        Console.WriteLine(ExtractEnding("Hi", 100));

        Console.WriteLine(
            IsPrime(23) 
            ? "23 is prime." 
            : "23 is not prime");

        Console.WriteLine(
            IsPrime(33) 
            ? "33 is prime." 
            : "33 is not prime");

        List<Exam> peterExams = new List<Exam>()
                                {
                                    new SimpleMathExam(2),
                                    new CSharpExam(55),
                                    new CSharpExam(100),
                                    new SimpleMathExam(1),
                                    new CSharpExam(0),
                                };
        Student peter = new Student("Peter", "Petrov", peterExams);
        double peterAverageResult = peter.CalcAverageExamResultInPercents();
        Console.WriteLine("Average results = {0:p0}", peterAverageResult);
    }
}
