using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyRPG
{
    public class Ninja:Character,IFighter,IGatherer
    {
        private int attackPoints;

        public Ninja(string name, Point position, int owner) : base(name, position, owner)
        {
            this.HitPoints = 1;
            this.attackPoints = 0;
        }

        public int AttackPoints
        {
            get { return this.attackPoints; }
        }

        public int DefensePoints
        {
            get { return int.MaxValue; }
        }

        public int GetTargetIndex(List<WorldObject> availableTargets)
        {
            /*Solution wit Linq and Lambda expression
            WorldObject target = availableTargets.OrderByDescending(p=>p.HitPoints).FirstOrDefault(t => t.Owner != this.Owner && t.Owner != 0);
            return availableTargets.IndexOf(target);*/
            
            int maxHitPoints = 0;
            int targetToAttack = -1;

            for (int i = 0; i < availableTargets.Count; i++)
            {
                if (availableTargets[i].Owner != 0 && availableTargets[i].Owner != this.Owner)
                {
                    if (availableTargets[i].HitPoints > maxHitPoints)
                    {
                        maxHitPoints = availableTargets[i].HitPoints;
                        targetToAttack = i;
                    }
                }
            }

            return targetToAttack;
        }

        public bool TryGather(IResource resource)
        {
            if (resource.Type == ResourceType.Lumber)
            {
                this.attackPoints += resource.Quantity;
                return true;
            }
            else if (resource.Type == ResourceType.Stone)
            {
                this.attackPoints += resource.Quantity * 2;
                return true;
            }

            return false;
        }
    }
}
