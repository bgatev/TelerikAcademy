namespace Computers
{
    using System;
    using System.Linq;
    
    public class InvalidArgumentException : ArgumentException
    {
        public InvalidArgumentException(string message) : base(message) 
        {
        }
    }
}
