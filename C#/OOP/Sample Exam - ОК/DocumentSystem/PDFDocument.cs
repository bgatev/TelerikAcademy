using System;
using System.Collections.Generic;
using System.Linq;

namespace DocumentSystem
{
    public class PDFDocument : BinaryDocument, IEncryptable
    {
        private int pages;
        private bool isEncrypted;

        public int Pages
        {
            get
            {
                return this.pages;
            }
            set
            {
                this.pages = value;
            }
        }

        public bool IsEncrypted
        {
            get
            {
                return this.isEncrypted;
            }
        }

        public void Encrypt()
        {
            this.isEncrypted = true;
        }

        public void Decrypt()
        {
            this.isEncrypted = false;
        }

        public override void LoadProperty(string key, string value)
        {
            if (key == "pages") this.Pages = int.Parse(value);
            else base.LoadProperty(key, value);
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            base.SaveAllProperties(output);
            if (this.Pages > 0) output.Add(new KeyValuePair<string, object>("pages", this.Pages));
        }

        public override string ToString()
        {
            if (this.isEncrypted) return String.Format("{0}[encrypted]", this.GetType().Name);
            else return base.ToString();
        }
    }
}
