using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentSystem
{
    public interface IDocument
    {
        string Name { get; }
        string Content { get; }
        void LoadProperty(string key, string value);
        void SaveAllProperties(IList<KeyValuePair<string, object>> output);
        string ToString();
    }
	public interface IEditable
    {
        void ChangeContent(string newContent);
    }
	public interface IEncryptable
    {
        bool IsEncrypted { get; }
        void Encrypt();
        void Decrypt();
    }
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
	public class DocumentSystem
    {
        private static IList<IDocument> allDocuments = new List<IDocument>();

        static void Main()
        {
            IList<string> allCommands = ReadAllCommands();
            ExecuteCommands(allCommands);
        }

        private static IList<string> ReadAllCommands()
        {
            List<string> commands = new List<string>();
            while (true)
            {
                string commandLine = Console.ReadLine();
                if (commandLine == "")
                {
                    // End of commands
                    break;
                }
                commands.Add(commandLine);
            }
            return commands;
        }

        private static void ExecuteCommands(IList<string> commands)
        {
            foreach (var commandLine in commands)
            {
                int paramsStartIndex = commandLine.IndexOf("[");
                string cmd = commandLine.Substring(0, paramsStartIndex);
                int paramsEndIndex = commandLine.IndexOf("]");
                string parameters = commandLine.Substring(
                    paramsStartIndex + 1, paramsEndIndex - paramsStartIndex - 1);
                ExecuteCommand(cmd, parameters);
            }
        }

        private static void ExecuteCommand(string cmd, string parameters)
        {
            string[] cmdAttributes = parameters.Split(
                new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            if (cmd == "AddTextDocument")
            {
                AddTextDocument(cmdAttributes);
            }
            else if (cmd == "AddPDFDocument")
            {
                AddPdfDocument(cmdAttributes);
            }
            else if (cmd == "AddWordDocument")
            {
                AddWordDocument(cmdAttributes);
            }
            else if (cmd == "AddExcelDocument")
            {
                AddExcelDocument(cmdAttributes);
            }
            else if (cmd == "AddAudioDocument")
            {
                AddAudioDocument(cmdAttributes);
            }
            else if (cmd == "AddVideoDocument")
            {
                AddVideoDocument(cmdAttributes);
            }
            else if (cmd == "ListDocuments")
            {
                ListDocuments();
            }
            else if (cmd == "EncryptDocument")
            {
                EncryptDocument(parameters);
            }
            else if (cmd == "DecryptDocument")
            {
                DecryptDocument(parameters);
            }
            else if (cmd == "EncryptAllDocuments")
            {
                EncryptAllDocuments();
            }
            else if (cmd == "ChangeContent")
            {
                ChangeContent(cmdAttributes[0], cmdAttributes[1]);
            }
            else
            {
                throw new InvalidOperationException("Invalid command: " + cmd);
            }
        }

        private static void AddTextDocument(string[] attributes)
        {
            AddDocument(new TextDocument(), attributes);           
        }

        private static void AddPdfDocument(string[] attributes)
        {
            AddDocument(new PDFDocument(), attributes); 
        }

        private static void AddWordDocument(string[] attributes)
        {
            AddDocument(new WordDocument(), attributes); 
        }

        private static void AddExcelDocument(string[] attributes)
        {
            AddDocument(new ExcelDocument(), attributes); 
        }

        private static void AddAudioDocument(string[] attributes)
        {
            AddDocument(new AudioDocument(), attributes); 
        }

        private static void AddVideoDocument(string[] attributes)
        {
            AddDocument(new VideoDocument(), attributes); 
        }

        private static void AddDocument(IDocument document, string[] attributes)
        {
            foreach (var singleAttribute in attributes)
            {
                string[] keyAndValue = singleAttribute.Split('=');
                string key = keyAndValue[0];
                string value = keyAndValue[1];
                document.LoadProperty(key, value);
            }

            if (document.Name != null)
            {
                allDocuments.Add(document);
                Console.WriteLine("Document added: {0}", document.Name);
            }
            else Console.WriteLine("Document has no name");
        }

        private static void ListDocuments()
        {
            if (allDocuments.Count > 0)
            {
                foreach (var document in allDocuments)
                {
                    Console.WriteLine(document);
                }
            }
            else Console.WriteLine("No documents found");
        }

        private static void EncryptDocument(string name)
        {
            bool documentFound = false;

            foreach (var document in allDocuments)
            {
                if (document.Name == name)
                {
                    if (document is IEncryptable)
                    {
                        ((IEncryptable)document).Encrypt();
                        Console.WriteLine("Document encrypted: {0}", name);
                    }
                    else Console.WriteLine("Document does not support encryption: {0}", name);
                    documentFound = true;
                }
            }
            if (!documentFound) Console.WriteLine("Document not found: {0}", name);
        }

        private static void DecryptDocument(string name)
        {
            bool documentFound = false;

            foreach (var document in allDocuments)
            {
                if (document.Name == name)
                {
                    if (document is IEncryptable)
                    {
                        ((IEncryptable)document).Decrypt();
                        Console.WriteLine("Document decrypted: {0}", name);
                    }
                    else Console.WriteLine("Document does not support decryption: {0}", name);
                    documentFound = true;
                }
            }
            
            if (!documentFound) Console.WriteLine("Document not found: {0}", name);
        }

        private static void EncryptAllDocuments()
        {
            bool documentFound = false;

            foreach (var document in allDocuments)
            {
                if (document is IEncryptable)
                {
                    ((IEncryptable)document).Encrypt();
                    documentFound = true;
                }
            }
            
            if (documentFound) Console.WriteLine("All documents encrypted");
            else Console.WriteLine("No encryptable documents found");
        }

        private static void ChangeContent(string name, string content)
        {
            bool documentFound = false;

            foreach (var document in allDocuments)
            {
                if (document.Name == name)
                {
                    if (document is IEditable)
                    {
                        ((IEditable)document).ChangeContent(content);
                        Console.WriteLine("Document content changed: {0}", document.Name);
                    }
                    else Console.WriteLine("Document is not editable: {0}", document.Name);
                    documentFound = true;
                }
            }

            if (!documentFound) Console.WriteLine("Document not found: {0}", name);
        } 
    }
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
	public class AudioDocument:MultimediaDocument
    {
        private int sampleRate;

        public int SampleRate
        {
            get
            {
                return this.sampleRate;
            }
            set
            {
                this.sampleRate = value;
            }
        }

        public override void LoadProperty(string key, string value)
        {
            if (key == "samplerate") this.SampleRate = int.Parse(value);
            else base.LoadProperty(key, value);
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            base.SaveAllProperties(output);
            if (this.SampleRate > 0) output.Add(new KeyValuePair<string, object>("samplerate", this.SampleRate));
        }
    }
	public class VideoDocument:MultimediaDocument
    {
        private int frameRate;

        public int FrameRate
        {
            get
            {
                return this.frameRate;
            }
            set
            {
                this.frameRate = value;
            }
        }

        public override void LoadProperty(string key, string value)
        {
            if (key == "framerate") this.FrameRate = int.Parse(value);
            else base.LoadProperty(key, value);
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            base.SaveAllProperties(output);
            if (this.FrameRate > 0) output.Add(new KeyValuePair<string, object>("framerate", this.FrameRate));
        }
    }
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
