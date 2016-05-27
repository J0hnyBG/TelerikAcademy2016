using System;
using System.Collections.Generic;
using System.Linq;

namespace _04_Konspiration
{
    internal class Konspiration
    {

        static string ExtractMethodName(string codePiece)
        {
            var beforeBracket = codePiece.Split(new[] { ' ', '.' }, StringSplitOptions.RemoveEmptyEntries);

            var methodName = beforeBracket[beforeBracket.Length - 1].TrimStart("<>!=-*/%^~".ToCharArray());

            if ( methodName.Length == 0 || !char.IsUpper(methodName[0]) && beforeBracket.Contains("new"))
            {
                return null;
            }
            return methodName;
        }
        private static void Main()
        {
            
            //TODO: 30/100
            int n = int.Parse(Console.ReadLine());

            var lines = new string[n];

            for (int i = 0; i < n; i++)
            {
                lines[i] = Console.ReadLine();
            }

            for (int i = 0; i < n; i++)
            {
                if (lines[i].Contains(" static "))
                {
                    var name = lines[i].Split(new[] {' ', '('}, StringSplitOptions.RemoveEmptyEntries)[2];

                    i+=2;

                    var openBrackets = 1;
                    var methodCalls = new List<string>();
                    while (openBrackets > 0 && i < n )
                    {
                        var splitByRoundBracket = lines[i].Split('(');

                        if (splitByRoundBracket.Length > 1)
                        {
                            for (int k = 0; k < splitByRoundBracket.Length -1; k++)
                            {
                                var methodName = ExtractMethodName(splitByRoundBracket[k]);
                                if ( methodName != null )
                                {
                                    methodCalls.Add(methodName);
                                }
                            }
                        }
                        foreach (var symbol in lines[i])
                        {
                            if (symbol == '{')
                            {
                                openBrackets++;
                            }
                            else if (symbol =='}')
                            {
                                openBrackets--;
                            }   
                        }

                        i++;
                    }
                    if (methodCalls.Count > 0)
                    {
                        Console.WriteLine(name + " -> "+ methodCalls.Count + " -> " + string.Join(", ", methodCalls));

                    }
                    else
                    {
                        Console.WriteLine(name + " -> None");
                    }
                }
                
            }
            
        }
    }
}
#region old
            //    //(?<!\bnew \b) check for new keyword
            //    const string regexPattern = @"(?<!\bnew \b)(?!\bif\b|\bfor\b|\bwhile\b|\bswitch\b|\btry\b|\bcatch\b)(\b[\w]+\b)[\s\n\r]*(?=\(.*\))";
            //    const RegexOptions regexOptions = RegexOptions.Singleline;

            //    int n = int.Parse(Console.ReadLine());

            //    string methodBody = string.Empty;
            //    int openingBrackets = 0;
            //    int closingBrackets = 0;
            //    bool inMethod = false;
            //    for (int i = 0; i < n; i++)
            //    {
            //        var line = Console.ReadLine().Trim();

            //        methodBody = methodBody + line;
            //        if (line =="{" && inMethod)
            //        {
            //            openingBrackets++;
            //        }
            //        else if (line.StartsWith("}") && inMethod)
            //        {
            //            closingBrackets++;
            //        }
            //        if (line.Contains("static"))
            //        {
            //            string methodDeclaration = Regex.Match(line, regexPattern).Value;
            //            _output = methodDeclaration + " -> ";
            //            methodBody = string.Empty;
            //            openingBrackets = 0;
            //            closingBrackets = 0;
            //            inMethod = true;
            //        }

            //        if (AreEqualAndModified(openingBrackets, closingBrackets))
            //        {
            //            var listOfMethods = Regex.Matches(methodBody, regexPattern, regexOptions);
            //            var listOfMethodsCount = listOfMethods.Count;
            //            if (listOfMethodsCount == 0)
            //            {
            //                _output = _output + "None";
            //                Console.WriteLine(_output);
            //                _output = string.Empty;
            //            }
            //            else
            //            {
            //                _output = _output + listOfMethodsCount + " -> ";

            //                for (int j = 0; j < listOfMethodsCount; j++)
            //                {
            //                    string comma = ", ";
            //                    if (j == listOfMethodsCount - 1)
            //                    {
            //                        comma = string.Empty;
            //                    }
            //                    _output = _output + listOfMethods[j].Value + comma;
            //                }
            //                Console.WriteLine(_output);
            //                _output = string.Empty;
            //            }
            //            openingBrackets = 0;
            //            closingBrackets = 0;
            //            methodBody = string.Empty;
            //            inMethod = false;
            //        }
            //    }
            //    //Delete before submitting
            //    //Console.ReadLine();
            //    //Console.Clear();
            //    //Main();
            //}

            //private static bool AreEqualAndModified(int first, int second)
            //{
            //    return first == second && first > 0 && second > 0;
            //}
            #endregion