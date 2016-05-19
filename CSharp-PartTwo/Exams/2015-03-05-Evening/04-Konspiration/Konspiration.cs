using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace _04_Konspiration
{
    class Konspiration
    {
        static void Main()
        {
			//Regex to match static method names [Ss]tatic +\w+ +(\w+)
			// Regex to match static method invocation (\w+) *\(.*\)
			//Regex to match method invocation (\.[\s\n\r]*[\w]+)[\s\n\r]*(?=\(.*\))
			//Mother of regexes for methods (?!\bif\b|\bfor\b|\bwhile\b|\bswitch\b|\btry\b|\bcatch\b)(\b[\w]+\b)[\s\n\r]*(?=\(.*\))

            Regex regex = new Regex(@"(?!\bif\b|\bfor\b|\bwhile\b|\bswitch\b|\btry\b|\bcatch\b)(\b[\w]+\b)[\s\n\r]*(?=\(.*\))");
            List<string> listOfMethods = new List<string>();

            int n = int.Parse(Console.ReadLine());
            string line = "";
            for (int i = 0; i < n; i++)
            {
                line = line + Console.ReadLine();
            }

            foreach ( Match match in regex.Matches(line) )
            {
                listOfMethods.Add(match.Value);
            }

            foreach (var methodName in listOfMethods)
            {
                Console.WriteLine(methodName);
            }


        }
    }
}
