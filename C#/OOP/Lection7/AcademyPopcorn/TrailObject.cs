using System;
using System.Linq;

namespace AcademyPopcorn
{
    public class TrailObject:GameObject
    {
        private long lifeTime;

        public TrailObject(MatrixCoords topLeft, char[,] body, long lifeTimeCounter):base(topLeft,body)
        {
            this.lifeTime = lifeTimeCounter;    
        }

        public override void Update()
        {
            this.lifeTime--;
            if (this.lifeTime <= 0) this.IsDestroyed = true;     
        }
    }
}
