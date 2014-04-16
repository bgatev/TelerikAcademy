using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarMachines.Interfaces;

namespace WarMachines.Machines
{
    public abstract class Machine:IMachine
    {
        private string name;
        private IPilot pilot;
        private double healthPoints;
        protected double attackPoints;
        protected double defensePoints;
        private IList<string> targets;

        public Machine(string machineName, double machineAttackPoints, double machineDefensePoints,double machineHealthPoints)
        {
            this.Name = machineName;
            this.attackPoints = machineAttackPoints;
            this.defensePoints = machineDefensePoints;
            this.HealthPoints = machineHealthPoints;
            targets = new List<string>();
        }
        
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        public IPilot Pilot
        {
            get
            {
                return this.pilot;
            }
            set
            {
                this.pilot = value;
            }
        }

        public double HealthPoints
        {
            get
            {
                return this.healthPoints;
            }
            set
            {
                this.healthPoints = value;
            }
        }

        public double AttackPoints
        {
            get { return this.attackPoints; }
        }

        public double DefensePoints
        {
            get { return this.defensePoints; }
        }

        public IList<string> Targets
        {
            get { return this.targets; }
        }

        public void Attack(string target)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            int targetCount = this.Targets.Count();
            string machineType = this.GetType().Name;

            sb.AppendLine(string.Format("- {0}", this.Name));
            sb.AppendLine(string.Format(" *Type: {0}", machineType));
            sb.AppendLine(string.Format(" *Health: {0}", this.HealthPoints));
            sb.AppendLine(string.Format(" *Attack: {0}", this.AttackPoints));
            sb.AppendLine(string.Format(" *Defense: {0}", this.DefensePoints));

            if (targetCount == 0) sb.AppendLine(string.Format(" *Targets: None"));
            else
            {
                sb.Append(string.Format(" *Targets: "));
                foreach (var target in this.Targets)
                {
                    sb.Append(string.Format("{0}, ", target));
                }
                sb.Remove(sb.Length - 2, 2);
                sb.AppendLine();
            }

            if (machineType == "Tank")
            {
                sb.Append(string.Format(" *Defense: {0}", ((this as Tank).DefenseMode == true) ? "ON" : "OFF"));
            }
            else
            {
                sb.Append(string.Format(" *Stealth: {0}", ((this as Fighter).StealthMode == true) ? "ON" : "OFF"));
            }

            return sb.ToString();
        }
    }
}
