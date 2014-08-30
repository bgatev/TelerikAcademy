using System.Text;

namespace WolfRaider.DataWriter
{
    public interface IDataWriter
    {
        void Write(string path, string data);

        void Write(string path, StringBuilder data);
    }
}
