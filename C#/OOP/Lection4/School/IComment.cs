using System;
using System.Collections.Generic;
using System.Linq;

public interface IComment
{
    List<string> Comments { get; set; }
    
    void AddComment(string comment);
}

