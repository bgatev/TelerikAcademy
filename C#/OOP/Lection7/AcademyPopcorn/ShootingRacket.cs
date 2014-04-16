using System;
using System.Collections.Generic;
using System.Linq;

namespace AcademyPopcorn
{
    public class ShootingRacket:Racket
    {
        public ShootingRacket(MatrixCoords topLeft, int width):base(topLeft,width)
        {
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            List<GameObject> racketObjects = new List<GameObject>();

            racketObjects.Add(new Bullet(this.topLeft));

            return racketObjects;
        }

    }
}
