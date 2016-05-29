using System;
using System.Collections.Generic;

namespace _04_CATastrophe
{
    class CATastrophe
    {
        private static string[] dataTypesToFind =
        {
            " sbyte ", " byte ", " short ", " ushort ", " int ", " uint ", " long ", " ulong ", " float ", " double ", " decimal ", " bool ", " char ", " string "
        };
        private static readonly string[] Loops = { " while ", " for ", " foreach "};
        private static readonly string[] ConditionalStatements = { " else if ", " if ", " else "};
        static void Main()
        {
            int totalLines = int.Parse(Console.ReadLine());

            bool inMethod = false;
            bool inCondition = false;
            bool inLoop = false;

            List<string> variablesInMethods = new List<string>();
            List<string> variablesInLoops = new List<string>();
            List<string> variablesInConditionals = new List<string>();

            for (int i = 0; i < totalLines; i++)
            {
                string line = Console.ReadLine();
                string[] words = line.Split(new[] { " ", "(", ")", "," }, StringSplitOptions.RemoveEmptyEntries);

                if ( line.Contains(" static "))
                {
                    inMethod = true;
                    inLoop = false;
                    inCondition = false;
                    //TODO: Extract vars
                    continue;
                }
                foreach (var loop in Loops)
                {
                    if (line.Contains(loop) )
                    {
                        inLoop = true;
                        inMethod = false;
                        inCondition = false;
                        //TODO: Extract vars
                        break;
                    }
                }
                foreach (var statement in ConditionalStatements)
                {
                    if ( line.Contains(statement) )
                    {
                        inLoop = false;
                        inMethod = false;
                        inCondition = true;
                        //TODO: Extract vars
                        break;
                    }
                }
            }
        }
    }
}
