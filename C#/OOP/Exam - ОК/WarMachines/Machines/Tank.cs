using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarMachines.Interfaces;

namespace WarMachines.Machines
{
    public class Tank:Machine,ITank
    {
        private const int TankInitialHealthPoints = 100;
        private const bool TankInitialDefenseMode = true;

        private bool defenseMode;

        public Tank(string tankName, double tankAttackPoints, double tankDefensePoints)
            :base(tankName,tankAttackPoints - 40,tankDefensePoints + 30,TankInitialHealthPoints)
        {
            this.defenseMode = TankInitialDefenseMode;
        }

        public bool DefenseMode
        {
            get { return this.defenseMode; }
        }

        public void ToggleDefenseMode()
        {
            if (this.defenseMode)
            {
                this.defensePoints -= 30;
                this.attackPoints += 40;
                this.defenseMode = false;
            }
            else
            {
                this.defensePoints += 30;
                this.attackPoints -= 40;
                this.defenseMode = true;
            }
        }
        
    }
}
