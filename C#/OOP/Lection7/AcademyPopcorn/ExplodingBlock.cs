using System;
using System.Collections.Generic;
using System.Linq;

namespace AcademyPopcorn
{
    public class ExplodingBlock:Block
    {
        public new const string CollisionGroupString = "explodingBlock";

        public ExplodingBlock(MatrixCoords topLeft):base(topLeft)
        {
        }

        public override string GetCollisionGroupString()
        {
            return ExplodingBlock.CollisionGroupString;
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            this.IsDestroyed = true;
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            List<GameObject> explodedObjects = new List<GameObject>();

            if (this.IsDestroyed)
            {
                explodedObjects.Add(new Explosion(this.topLeft,new MatrixCoords(-1, -1)));
                explodedObjects.Add(new Explosion(this.topLeft, new MatrixCoords(-1, 0)));
                explodedObjects.Add(new Explosion(this.topLeft, new MatrixCoords(-1, 1)));
            }

            return explodedObjects;
        }
    }
}
