using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HTMLRenderer
{
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
}
