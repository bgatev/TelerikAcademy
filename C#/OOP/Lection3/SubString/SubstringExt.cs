using System;
using System.Linq;
using System.Text;

namespace SubString
{
    public static class SubstringExtension
    {
        public static StringBuilder Substring(this StringBuilder sb, int index, int length)
        {
            StringBuilder result = new StringBuilder();

            for (int i = index; i < index + length; i++) result.Append(sb[i]);
            
            return result;
        }
    }
}
