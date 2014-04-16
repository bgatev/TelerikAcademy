using System;
using System.Collections.Generic;
using System.Linq;

namespace HTMLRenderer
{
    public interface ISimpleElement
    {
        string TextContent { get; set; }
        IEnumerable<IElement> ChildElements { get; }
        void AddElement(IElement element);
    }
}
