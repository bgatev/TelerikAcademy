using System.IO;
using System.Text;
using NPOI.SS.UserModel;

namespace WolfRaider.DataWriter
{
    public class FileDataWriter : IDataWriter
    {
        /// <summary>
        /// Writes a string to a file.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="data"></param>
        public void Write(string path, string data)
        {
            using (var streamWriter = new StreamWriter(path, false))
            {
                streamWriter.WriteLine(data);
            }
        }

        /// <summary>
        /// Writes a StringBuilder to a file.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="data"></param>
        public void Write(string path, StringBuilder data)
        {
            using (var streamWriter = new StreamWriter(path, false))
            {
                streamWriter.WriteLine(data.ToString());
            }
        }

        /// <summary>
        /// Writes a XLSX workbook to a file.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="workbook"></param>
        public void Write(string path, IWorkbook workbook)
        {
            FileStream fileStream = File.Create(path);
            workbook.Write(fileStream);
            fileStream.Close();
        }
    }
}
