using System;
using System.Linq;

namespace DocumentSystem
{
    public interface IEncryptable
    {
        bool IsEncrypted { get; }
        void Encrypt();
        void Decrypt();
    }
}
