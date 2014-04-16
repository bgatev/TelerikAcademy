using System;
using System.Collections.Generic;
using System.Linq;

namespace DocumentSystem
{
    public class TextDocument:Document,IEditable
    {
        private string charset;

        public string CharSet
        {
            get
            {
                return this.charset;
            }
            set
            {
                this.charset = value;
            }
        }

        public override void LoadProperty(string key, string value)
        {
            if (key == "charset") this.CharSet = value;
            else base.LoadProperty(key, value);
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            base.SaveAllProperties(output);
            if (!string.IsNullOrEmpty(this.CharSet)) output.Add(new KeyValuePair<string, object>("charset", this.CharSet));
        }

        public void ChangeContent(string newContent)
        {
            this.Content = newContent;
        }
    }
}
