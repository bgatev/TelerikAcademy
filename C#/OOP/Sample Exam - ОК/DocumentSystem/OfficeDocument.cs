using System;
using System.Collections.Generic;
using System.Linq;

namespace DocumentSystem
{
    public abstract class OfficeDocument:BinaryDocument,IEncryptable
    {
        private bool isEncrypted;
        private string version;

        public string Version
        {
            get
            {
                return this.version;
            }
            set
            {
                this.version = value;
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
            if (key == "version") this.Version = value;
            else base.LoadProperty(key, value);
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            base.SaveAllProperties(output);
            if (!string.IsNullOrEmpty(this.Version)) output.Add(new KeyValuePair<string, object>("version", this.Version));
        }

        public override string ToString()
        {
            if (this.isEncrypted) return String.Format("{0}[encrypted]", this.GetType().Name);
            else return base.ToString();
        }
    }
}
