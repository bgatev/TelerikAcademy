using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarMachines.Interfaces;

namespace WarMachines.Machines
{
    public class Pilot:IPilot
    {
        private string name;
        private IList<IMachine> machines;

        public Pilot(string pilotName)
        {
            this.name = pilotName;
            machines = new List<IMachine>();
        }
        
        public string Name
        {
            get { return this.name; }
        }

        public void AddMachine(IMachine machine)
        {
            machines.Add(machine);
            machines.OrderBy(h => h.HealthPoints).ThenBy(n => n.Name);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            int machinesCount = machines.Count();

            sb.Append(string.Format("{0} ",this.Name));
            switch (machinesCount)
            {
                case 0:
                    {
                        sb.Append(string.Format("- no machines"));
                        return sb.ToString();
                    }
                case 1:
                    {
                        sb.Append(string.Format("- 1 machine"));
                        break;
                    }
                default:
                    {
                        sb.Append(string.Format("- {0} machines", machinesCount));
                        break;
                    }
            }

            foreach (var machine in machines)
            {
                sb.AppendLine();
                sb.Append(string.Format("{0}",machine));
            }

            return sb.ToString();
        }
    }
}
