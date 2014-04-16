using System;
using System.Collections.Generic;
using System.Linq;

namespace DocumentSystem
{
    public class BinaryDocument:Document
    {
        private int size;

        public int Size
        {
            get
            {
                return this.size;
            }
            set
            {
                this.size = value;
            }
        }

        public override void LoadProperty(string key, string value)
        {
            if (key == "size") this.Size = int.Parse(value);
            else base.LoadProperty(key, value);          
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            base.SaveAllProperties(output);
            if (this.Size > 0) output.Add(new KeyValuePair<string, object>("size", this.Size));
        }
    }
}
