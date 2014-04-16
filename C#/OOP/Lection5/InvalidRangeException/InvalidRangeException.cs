using System;
using System.Collections.Generic;
using System.Linq;

namespace InvalidRangeExceptions
{
    public class InvalidRangeException<T>:ArgumentOutOfRangeException
    {
        private T start, end;
        private string errorMsg;

        public InvalidRangeException():this(default(T), default(T))
        {
        }

        public InvalidRangeException(string msg): base(msg)
        {
            this.errorMsg = msg;
        }

        public InvalidRangeException(string msg, Exception innerEx) : base(msg,innerEx)
        {
            this.errorMsg = msg;
        }

        public InvalidRangeException(T rangeStart, T rangeEnd)
        {
            this.start = rangeStart;
            this.end = rangeEnd;
        }

        public InvalidRangeException(T rangeStart, T rangeEnd, string msg):base(msg)
        {
            this.start = rangeStart;
            this.end = rangeEnd;
        }

        public T Start
        {
            get
            {
                return this.start;
            }
            set
            {
                this.start = value;
            }
        }

        public T End
        {
            get
            {
                return this.end;
            }
            set
            {
                this.end = value;
            }
        }

        public string ErrorMsg
        {
            get
            {
                return this.errorMsg;
            }
            set
            {
                this.errorMsg = value;
            }
        }

    }
}
