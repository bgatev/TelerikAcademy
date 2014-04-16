using System;
using System.Linq;

namespace MobilePhone
{
    public class Call
    {
        private DateTime callDateTime;
        private string dialedNumbers;
        private int duration;
        
        // mandatory constructor
        public Call(int duration) : this(duration, DateTime.Now)
        {

        }

        //full constructor
        public Call(int duration, DateTime callDateTime, string dialedNumbers = null)
        {
            this.CallDateTime = callDateTime;
            this.DialedNumbers = dialedNumbers;
            this.Duration = duration;
        }

        public DateTime CallDateTime
        {
            get
            {
                return this.callDateTime;
            }
            set
            {
                if (DateTime.TryParse(value.ToString(),out this.callDateTime)) this.callDateTime = value;
                else throw new ArgumentException();
            }
        }

        public string DialedNumbers
        {
            get
            {
                return this.dialedNumbers;
            }
            set
            {
                if (string.IsNullOrEmpty(value) || value.Length > 0) this.dialedNumbers = value;
                else throw new ArgumentException();
            }
        }

        public int Duration
        {
            get
            {
                return this.duration;
            }
            set
            {
                if (value >= 0) this.duration = value;
                else throw new ArgumentException();
            }
        }
    }
}
