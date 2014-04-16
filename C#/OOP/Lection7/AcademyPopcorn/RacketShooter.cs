using System;
using System.Linq;

namespace AcademyPopcorn
{
    public class RacketShooter:Engine
    {
        public RacketShooter(IRenderer renderer, IUserInterface userInterface, int sleepTime) : base(renderer, userInterface,sleepTime)
        {
        }

        public GameObject ShootPlayerRacket(MatrixCoords topLeft, int width)
        {
            ShootingRacket shootingRacket = new ShootingRacket(topLeft,width);

            return shootingRacket;
        }
    }
}
