using System;
using System.Linq;
using System.Text;

namespace MobilePhone
{
    public enum BatteryType
    {
        LiIon, NiMH, NiCd
    }

    public class BatterySpecs
    {
        private string model;
        private BatteryType type;
        private double? hoursIdle, hoursTalk;

        //full constructor
        public BatterySpecs(string model, BatteryType type, double? hoursIdle = null, double? hoursTalk = null)
        {
            this.Model = model;
            this.type = type;
            this.HoursIdle = hoursIdle;
            this.HoursTalk = hoursTalk;
        }

        public string Model
        {
            get
            {
                return this.model;
            }
            set
            {
                if (string.IsNullOrEmpty(value) || value.Length > 0) this.model = value;
                else throw new ArgumentException();
            }
        }

        public double? HoursIdle
        {
            get
            {
                return this.hoursIdle;
            }
            set
            {
                if ((value > 0) || (value == null)) this.hoursIdle = value;
                else throw new ArgumentException();
            }
        }

        public double? HoursTalk
        {
            get
            {
                return this.hoursTalk;
            }
            set
            {
                if ((value > 0) || (value == null)) this.hoursTalk = value;
                else throw new ArgumentException();
            }
        }

        // only getter, no setter (read only property)
        public BatteryType Type
        {
            get
            {
                return this.type;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Battery:");
            sb.AppendLine(this.model.ToString() + " " + this.type);
            sb.AppendLine(this.hoursIdle.ToString() + "h Idle");
            sb.AppendLine(this.hoursTalk.ToString() + "h Talk");

            return sb.ToString();
        }

    }
}
