using System;
using System.Collections.Generic;
using System.Linq;

namespace DocumentSystem
{
    public class ExcelDocument : OfficeDocument
    {
        private int rows, cols;

        public int Rows
        {
            get
            {
                return this.rows;
            }
            set
            {
                this.rows = value;
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
                this.cols = value;
            }
        }

        public override void LoadProperty(string key, string value)
        {
            if (key == "rows") this.Rows = int.Parse(value);
            else if (key == "cols") this.Cols = int.Parse(value);
            else base.LoadProperty(key, value);
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            base.SaveAllProperties(output);
            if (this.Rows > 0) output.Add(new KeyValuePair<string, object>("rows", this.Rows));
            if (this.Cols > 0) output.Add(new KeyValuePair<string, object>("cols", this.Cols));
        }
    }
}
