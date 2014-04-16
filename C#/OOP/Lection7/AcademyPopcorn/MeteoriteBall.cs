using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    public class MeteoriteBall:Ball
    {
        public MeteoriteBall(MatrixCoords topLeft, MatrixCoords speed):base(topLeft,speed)
        {
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            List<GameObject> trailObjects = new List<GameObject>();
            
            trailObjects.Add(new TrailObject(base.topLeft, new char[,] { { '.' } }, 3));
            
            return trailObjects;
        }

        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return otherCollisionGroupString == "racket" || otherCollisionGroupString == "block"
                || otherCollisionGroupString == "unpassableBlock" || otherCollisionGroupString == "indestructibleBlock"
                || otherCollisionGroupString == "explodingBlock";
        }
    }
}
