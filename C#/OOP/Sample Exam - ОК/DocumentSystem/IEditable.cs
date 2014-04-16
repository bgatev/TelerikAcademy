using System;
using System.Linq;

namespace DocumentSystem
{
    public interface IEditable
    {
        void ChangeContent(string newContent);
    }
}
