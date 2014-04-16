using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HTMLRenderer
{
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
