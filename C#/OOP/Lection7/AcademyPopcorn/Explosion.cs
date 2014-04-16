using System;
using System.Collections.Generic;
using System.Linq;

namespace AcademyPopcorn
{
    public class Explosion:MovingObject
    {
        private bool runOnce;

        public Explosion(MatrixCoords topLeft, MatrixCoords speed) : base(topLeft, new char[,] { { '+' } }, speed)
        {
            this.IsDestroyed = true;
            this.runOnce = true;
        }

        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return otherCollisionGroupString == "block" || otherCollisionGroupString == "explodingBlock";
        }
        
        public override void Update()
        {
            if (this.runOnce)
            {
                this.IsDestroyed = true;
                this.runOnce = false;
            }
        }
    }
}
