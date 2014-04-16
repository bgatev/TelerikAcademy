using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentSystem
{
    public class Document:IDocument
    {
        private string name, content;

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

        public string Content
        {
            get
            {
                return this.content;
            }
            set
            {
                this.content = value;
            }
        }

        public virtual void LoadProperty(string key, string value)
        {
            if (key == "name") this.Name = value;
            else if (key == "content") this.Content = value;
            else throw new ArgumentException("Key '" + key + "' not found");
        }

        public virtual void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            if (!string.IsNullOrEmpty(this.Name)) output.Add(new KeyValuePair<string, object>("name", this.Name));
            if (!string.IsNullOrEmpty(this.Content)) output.Add(new KeyValuePair<string, object>("content", this.Content));
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            List<KeyValuePair<string, object>> properties = new List<KeyValuePair<string, object>>();
            
            this.SaveAllProperties(properties);
            properties.Sort((a, b) => a.Key.CompareTo(b.Key));

            sb.AppendFormat("{0}[",this.GetType().Name);

            foreach (var singleProperty in properties)
            {
                if (singleProperty.Value != null) sb.AppendFormat("{0}={1};", singleProperty.Key, singleProperty.Value);
            }

            if (sb[sb.Length - 2] != '[') sb.Remove(sb.Length - 1, 1);
            sb.Append("]");
            
            return sb.ToString();
        }
    }
}
