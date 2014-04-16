using System;
using System.Collections.Generic;
using System.Linq;

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
}
