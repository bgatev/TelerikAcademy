using System;
using System.Linq;

namespace Events
{
    public class MyEventArgs : EventArgs
    {
        private string message;

        public MyEventArgs(string s)
        {
            message = s;
        }
        
        public string Message
        {
            get 
            { 
                return this.message; 
            }
            set
            { 
                this.message = value;
            }
        }
    }
}
