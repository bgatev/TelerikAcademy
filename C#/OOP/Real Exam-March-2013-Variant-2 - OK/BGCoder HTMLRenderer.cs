using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.CodeDom.Compiler;
using Microsoft.CSharp;
using System.Reflection;

namespace HTMLRenderer
{
    public interface IElement
    {
        string Name { get; }
        void Render(StringBuilder output);
        string ToString();
        string TextContent { get; set; }
        IEnumerable<IElement> ChildElements { get; }
        void AddElement(IElement element);
    }
	public interface IElementFactory
    {
        IElement CreateElement(string name);
        IElement CreateElement(string name, string content);
        ITable CreateTable(int rows, int cols);
    }
	public interface ISimpleElement:IElement
    {
        string TextContent { get; set; }
        IEnumerable<IElement> ChildElements { get; }
        void AddElement(IElement element);
    }
	public interface ITable : IElement
    {
        int Rows { get; }
        int Cols { get; }
        IElement this[int row, int col] { get; set; }
    }
	public class HTMLRendererCommandExecutor
    {
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

        static void Main()
        {
            string csharpCode = ReadInputCSharpCode();
            CompileAndRun(csharpCode);
        }
    }
	public class HTMLElementFactory : IElementFactory
    {
        public IElement CreateElement(string name)
        {
            return new HTMLElement(name);
        }

        public IElement CreateElement(string name, string content)
        {
            return new HTMLElement(name, content);
        }

        public ITable CreateTable(int rows, int cols)
        {
            return new HTMLTable(rows, cols);
        }
    }
	public class HTMLElement:IElement
    {
        private string name, textContent;
        private IList<IElement> childElements;

        public HTMLElement(string elementName) : this(elementName, null)
        {
        }

        public HTMLElement(string elementName, string content)
        {
            this.Name = elementName;
            if (content != null) this.TextContent = content;
            this.childElements = new List<IElement>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            { 
                this.name = value;
            }
        }

        public string TextContent
        {
            get
            {
                return this.textContent;
            }
            set
            {
                this.textContent = value;
            }
        }

        public IEnumerable<IElement> ChildElements
        {
            get 
            {
                return this.childElements;
            }
        }

        public void AddElement(IElement element)
        {
            this.childElements.Add(element);
        }      

        public void Render(StringBuilder output)
        {
            if (!string.IsNullOrEmpty(this.Name)) output.Append(string.Format("<{0}>",this.Name));
            if (!string.IsNullOrEmpty(this.TextContent)) output.Append(ReplaceStringChars(this.TextContent));
            
            if (this.childElements.Count() > 0)
            {
                for (int i = 0; i < childElements.Count(); i++) output.Append((childElements as List<IElement>)[i]);
            }
            if (!string.IsNullOrEmpty(this.Name)) output.Append(string.Format("</{0}>", this.Name));
        }

        private string ReplaceStringChars(string inputString)
        {
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < inputString.Length; i++)
            {
                if (inputString[i] == '<') result.Append("&lt;");
                else if (inputString[i] == '>') result.Append("&gt;");
                else if (inputString[i] == '&') result.Append("&amp;");
                else result.Append(inputString[i]);
            }

            return result.ToString();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            
            this.Render(sb);

            return sb.ToString();
        }
    }
	public class HTMLTable:ITable
    {
        private const string name = "table";
        private int rows, cols;
        private IElement[,] table;

        public HTMLTable(int rows,int cols)
        {
            this.Rows = rows;
            this.Cols = cols;
            this.table = new IElement[rows, cols];
        }

        public int Rows
        {
            get
            {
                return this.rows;
            }
            set
            {
                if (value >= 0) this.rows = value;
            }
        }

        public int Cols
        {
            get
            { 
                return this.cols;
            }
            set
            {
                if (value >= 0) this.cols = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
        }

        public string TextContent
        {
            get
            {
                return null;
            }
            set
            {
                throw new InvalidOperationException("Tables do not have text content");
            }
        }

        public IElement this[int row, int col]
        {
            get
            {
                if (row >= 0 && row < this.Rows && col >= 0 && col < this.Cols) return this.table[row, col];
                else throw new IndexOutOfRangeException(String.Format("Cell ({0}, {1}) is invalid.", row, col));
            }
            set
            {
                if (row >= 0 && row < this.Rows && col >= 0 && col < this.Cols) this.table[row, col] = value;
                else throw new IndexOutOfRangeException(String.Format("Cell ({0}, {1}) is invalid.", row, col));
            }
        }

        public void Render(StringBuilder output)
        {
            output.Append("<table>");
            
            for (int row = 0; row < this.Rows; row++)
            {
                output.Append("<tr>");

                for (int col = 0; col < this.Cols; col++)
                {
                    output.Append("<td>");
                    output.Append(this.table[row,col]);
                    output.Append("</td>");
                }

                output.Append("</tr>");
            }

            output.Append("</table>");
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            this.Render(sb);

            return sb.ToString();
        }
        
        //not needed
        public IEnumerable<IElement> ChildElements
        {
            get 
            { 
                return null; 
            }
        }

        public void AddElement(IElement element)
        {
        }
    }
}
