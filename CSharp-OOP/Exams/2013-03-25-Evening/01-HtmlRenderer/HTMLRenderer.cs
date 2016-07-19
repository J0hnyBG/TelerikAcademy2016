using System;
using System.Linq;
using System.Text;
using System.CodeDom.Compiler;
using Microsoft.CSharp;
using System.Reflection;
using System.Collections.Generic;

namespace HTMLRenderer
{
    public interface IElement
    {
        string Name { get; }
        string TextContent { get; set; }
        IEnumerable<IElement> ChildElements { get; }
        void AddElement(IElement element);
        void Render(StringBuilder output);
        string ToString();
    }

    public interface ITable : IElement
    {
        int Rows { get; }
        int Cols { get; }
        IElement this[int row, int col] { get; set; }
    }

    public interface IElementFactory
    {
        IElement CreateElement(string name);
        IElement CreateElement(string name, string content);
        ITable CreateTable(int rows, int cols);
    }

    public class HTMLElementFactory : IElementFactory
    {
        public IElement CreateElement(string name)
        {
            return new Element(name);
        }

        public IElement CreateElement(string name, string content)
        {
            return new Element(name, content);
        }

        public ITable CreateTable(int rows, int cols)
        {
            return new Table(rows, cols);
        }
    }

    public class Element : IElement
    {
        public string Name { get; private set; }
        public string TextContent { get; set; }
        public IEnumerable<IElement> ChildElements { get; private set; }

        public Element(string name = null, string textContent = null)
        {
            this.Name = name;
            if (textContent != null)
            {
                this.TextContent = SanitizeTextContent(textContent);
            }
            this.ChildElements = new IElement[] {};
        }

        public Element(string name = null)
        {
            this.Name = name;
            this.TextContent = null;
            this.ChildElements = new IElement[] { };
        }

        public void AddElement(IElement element)
        {
            this.ChildElements = this.ChildElements.Concat(new[] {element});
        }

        private string SanitizeTextContent(string content)
        {
            var sb = new StringBuilder();
            foreach (var ch in content)
            {
                switch (ch)
                {
                    case '<':
                        sb.Append("&lt;");
                        break;
                    case '>':
                        sb.Append("&gt;");
                        break;
                    case '&':
                        sb.Append("&amp;");
                        break;
                    default:
                        sb.Append(ch);
                        break;
                }
            }
            return sb.ToString();
        }

        public void Render(StringBuilder output)
        {
            Console.WriteLine(output.ToString());
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            if ( this.Name != null )
            {
                output.Append("<" + this.Name + ">");
            }
            if ( this.TextContent != null )
            {
                output.Append(this.TextContent);
            }
            foreach ( var elem in this.ChildElements )
            {
                output.Append(elem.ToString());
            }
            if ( this.Name != null )
            {
                output.Append("</" + this.Name + ">");
            }
            return output.ToString();
        }
    }

    public class Table : Element, ITable
    {
        private const string TableName = "table";
        private IElement[,] table;

        public Table(int rows, int cols)
            : base(Table.TableName)
        {
            this.Rows = rows;
            this.Cols = cols;
            this.table = new IElement[Rows, Cols];
        }

        public int Rows { get; private set; }
        public int Cols { get; private set; }

        public IElement this[int row, int col]
        {
            get { return this.table[row, col]; }
            set { this.table[row, col] = value; }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("<" + this.Name + ">");
            for (var i = 0; i < table.GetLength(0); i++)
            {
                sb.Append("<tr>");
                for (var j = 0; j < table.GetLength(1); j++)
                {
                    var elem = table[i, j];
                    sb.Append("<td>");
                    sb.Append(elem.ToString());
                    sb.Append("</td>");
                }
                sb.Append("</tr>");
            }
            sb.Append("</" + this.Name + ">");
            return sb.ToString();
        }
    }

    public class HTMLRendererCommandExecutor
    {
        static void Main()
        {
            string csharpCode = ReadInputCSharpCode();
            CompileAndRun(csharpCode);
        }

        private static string ReadInputCSharpCode()
        {
            StringBuilder result = new StringBuilder();
            string line;
            while ((line = Console.ReadLine()) != "")
            {
                result.AppendLine(line);
            }
            return result.ToString();
        }

        static void CompileAndRun(string csharpCode)
        {
            // Prepare a C# program for compilation
            string[] csharpClass =
            {
                @"using System;
                  using HTMLRenderer;

                  public class RuntimeCompiledClass
                  {
                     public static void Main()
                     {"
                + csharpCode + @"
                     }
                  }"
            };

            // Compile the C# program
            CompilerParameters compilerParams = new CompilerParameters();
            compilerParams.GenerateInMemory = true;
            compilerParams.TempFiles = new TempFileCollection(".");
            compilerParams.ReferencedAssemblies.Add("System.dll");
            compilerParams.ReferencedAssemblies.Add(Assembly.GetExecutingAssembly().Location);
            CSharpCodeProvider csharpProvider = new CSharpCodeProvider();
            CompilerResults compile = csharpProvider.CompileAssemblyFromSource(
                compilerParams, csharpClass);

            // Check for compilation errors
            if (compile.Errors.HasErrors)
            {
                string errorMsg = "Compilation error: ";
                foreach (CompilerError ce in compile.Errors)
                {
                    errorMsg += "\r\n" + ce.ToString();
                }
                throw new Exception(errorMsg);
            }

            // Invoke the Main() method of the compiled class
            Assembly assembly = compile.CompiledAssembly;
            Module module = assembly.GetModules()[0];
            Type type = module.GetType("RuntimeCompiledClass");
            MethodInfo methInfo = type.GetMethod("Main");
            methInfo.Invoke(null, null);
        }
    }
}