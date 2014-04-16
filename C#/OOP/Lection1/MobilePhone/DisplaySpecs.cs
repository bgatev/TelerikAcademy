using System;
using System.Linq;
using System.Text;

namespace MobilePhone
{
    public class DisplaySpecs
    {
        private double? size;
        private int? numberOfColors;

        //full constructor
        public DisplaySpecs(double? size = null, int? numberOfColors = null)
        {
            this.Size = size;
            this.NumberOfColors = numberOfColors;
        }

        public double? Size 
        { 
            get
            {
                return this.size;  
            }
            set
            {
                if ((value > 0) || (value == null)) this.size = value;
                else throw new ArgumentException(); 
            } 
        }

        public int? NumberOfColors
        {
            get
            {
                return this.numberOfColors;
            }
            set
            {
                if ((value > 0) || (value == null)) this.numberOfColors = value;
                else throw new ArgumentException();
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Display:");
            sb.AppendLine(this.size.ToString() + "inch");
            sb.AppendLine(this.numberOfColors + "colors");

            return sb.ToString();
        }

    }
}
