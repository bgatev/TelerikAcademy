﻿namespace DirectoryTraverser
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Program
    {
        public static void Main()
        {
            ExeFinder finder = new ExeFinder();
            finder.GetSubDirectories(@"D:\Install");
        }
    }
}