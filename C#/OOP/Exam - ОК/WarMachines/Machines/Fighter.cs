using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarMachines.Interfaces;

namespace WarMachines.Machines
{
    public class Fighter:Machine,IFighter
    {
        private const int FighterInitialHealthPoints = 200;

        private bool stealthMode;

        public Fighter(string fighterName, double fighterAttackPoints, double fighterDefensePoints, bool fighterStealthMode)
            : base(fighterName, fighterAttackPoints, fighterDefensePoints, FighterInitialHealthPoints)
        {
            this.stealthMode = fighterStealthMode;
        }

        public bool StealthMode
        {
            get { return this.stealthMode; }
        }

        public void ToggleStealthMode()
        {
            if (this.stealthMode) this.stealthMode = false;
            else this.stealthMode = true;
        }
    }
}
