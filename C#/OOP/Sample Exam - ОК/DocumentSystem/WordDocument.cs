using System;
using System.Collections.Generic;
using System.Linq;

namespace DocumentSystem
{
    public class WordDocument : OfficeDocument, IEditable
    {
        private long chars;

        public long Chars
        {
            get
            {
                return this.chars;
            }
            set
            {
                this.chars = value;
            }
        }

        public override void LoadProperty(string key, string value)
        {
            if (key == "chars") this.Chars = long.Parse(value);
            else base.LoadProperty(key, value);
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            base.SaveAllProperties(output);
            if (this.Chars > 0) output.Add(new KeyValuePair<string, object>("chars", this.Chars));
        }

        public void ChangeContent(string newContent)
        {
            this.Content = newContent;
        }
    }
}
