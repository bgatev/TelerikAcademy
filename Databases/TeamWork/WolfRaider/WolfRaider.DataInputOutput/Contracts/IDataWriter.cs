namespace WolfRaider.DataInputOutput.Contracts
{
    using System.Text;
    using NPOI.SS.UserModel;

    public interface IDataWriter
    {
        void Write(string path, string text);

        void Write(string path, StringBuilder stringBuilder);

        void Write(string path, IWorkbook workbook);
    }
}
