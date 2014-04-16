using System;
using System.Collections.Generic;
using System.Linq;

namespace DocumentSystem
{
    public abstract class MultimediaDocument:BinaryDocument
    {
        private long length;

        public long Length
        {
            get
            {
                return this.length;
            }
            set
            {
                this.length = value;
            }
        }

        public override void LoadProperty(string key, string value)
        {
            if (key == "length") this.Length = int.Parse(value);
            else base.LoadProperty(key, value);
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            base.SaveAllProperties(output);
            if (this.Length > 0) output.Add(new KeyValuePair<string, object>("length", this.Length));
        }
    }
}
