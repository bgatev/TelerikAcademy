using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MobilePhone
{
    public class GSM
    {
        private string model, manifacturer, owner;
        private int? price;
        private BatterySpecs battery = new BatterySpecs("Nokia",BatteryType.LiIon);
        private DisplaySpecs display = new DisplaySpecs(4.3);
        private static GSM iPhone4S = new GSM("Apple","IPhone4S");

        private List<Call> callHistory = new List<Call>();

        //optional constructor
        public GSM(string manifacturer, string model, string owner, int? price, DisplaySpecs display)
            : this(manifacturer, model, owner, price, null, display)
        {
        }

        //full constructor
        public GSM(string manifacturer, string model, string owner = null, int? price = null, BatterySpecs battery = null, DisplaySpecs display = null)
        {
            this.Manifacturer = manifacturer;
            this.Model = model;
            this.Owner = owner;
            this.Price = price;
            this.battery = battery;
            this.display = display;
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

        public string Manifacturer
        {
            get
            {
                return this.manifacturer;
            }
            set
            {
                if (string.IsNullOrEmpty(value) || value.Length > 0) this.manifacturer = value;
                else throw new ArgumentException();
            }
        }

        public string Owner
        {
            get
            {
                return this.owner;
            }
            set
            {
                if (string.IsNullOrEmpty(value) || value.Length > 0) this.owner = value;
                else throw new ArgumentException();
            }
        }

        public int? Price
        {
            get
            {
                return this.price;
            }
            set
            {
                if ((value > 0) || (value == null)) this.price = value;
                else throw new ArgumentException();
            }
        }

        public static void DisplayGSMInfo(GSM phone)
        {
            Console.WriteLine(phone.ToString());
        }

        public static GSM IPhone4S
        {
            get
            {
                return iPhone4S;
            }
            set
            {
                iPhone4S = value;
            }
        }

        public void AddCall(int currentDuration, DateTime currentCallDateTime, string currentDialedNumbers)
        {
            Call currentCall = new Call(currentDuration, currentCallDateTime, currentDialedNumbers);

            this.callHistory.Add(currentCall);
        }

        public void DeleteCall(int currentDuration, DateTime currentCallDateTime)
        {
            for (int i = 0; i < callHistory.Count; i++)
            {
                if ((callHistory[i].CallDateTime == currentCallDateTime) && (callHistory[i].Duration == currentDuration))
                {
                    callHistory.RemoveAt(i);
                    break;
                }
            }
        }

        public double CalculateCallPrice(double pricePerMin)
        {
            double result = 0;

            foreach (var call in callHistory)
            {
                result += (double) call.Duration * (pricePerMin / 60);       
            }

            return result;
        }

        public void DisplayCallHistory()
        {
            StringBuilder sb = new StringBuilder();

            if (callHistory.Count == 0) Console.WriteLine("Call History is empty");
            else foreach (var call in callHistory)
            {
                sb.AppendLine(call.CallDateTime.ToString() + " " + call.DialedNumbers + "  " + call.Duration.ToString() + "s");
            }

            Console.WriteLine(sb.ToString());
        }

        public Call RemoveLongestCallInHistory()
        {
            Call result = new Call(0);

            if (callHistory.Count == 0) Console.WriteLine("Call History is empty");
            else foreach (var call in callHistory)
            {
                if (call.Duration > result.Duration)
                {
                    result.CallDateTime = call.CallDateTime;
                    result.Duration = call.Duration;
                }
            }

            return result;
        }

        public void ClearCallHistory()
        {
            this.callHistory.Clear();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(this.manifacturer + " " + this.model);

            if (this.price != null) sb.AppendLine(this.price.ToString() + "BGN");
            else sb.AppendLine("The Price is not Set");
            
            if (this.owner != null) sb.AppendLine(this.owner + "\n");
            else sb.AppendLine("The Owner is not Set");
            
            if (this.battery != null) sb.AppendLine(this.battery.ToString());
            else sb.AppendLine("The Battery Specification is not Set");
            
            if (this.display != null) sb.Append(this.display.ToString());
            else sb.AppendLine("The Display Specification is not Set");

            return sb.ToString();
        }

    }
}
