using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class AcademyPopcornMain
    {
        const int WorldRows = 23;
        const int WorldCols = 40;
        const int RacketLength = 6;

        static void Initialize(Engine engine)
        {
            int startRow = 3;
            int startCol = 2;
            int endCol = WorldCols - 2;

            for (int i = startRow; i < startRow + 2; i++)
            {
                for (int j = startCol; j < endCol; j++)
                {
                    Block currBlock;
                    IndestructibleBlock ceilingWall = new IndestructibleBlock(new MatrixCoords(startRow - 1, j - 1));

                    if (j % 3 == 0) currBlock = new ExplodingBlock(new MatrixCoords(i, j));
                    else if (j % 4 == 0) currBlock = new GiftBlock(new MatrixCoords(i, j));
                    else currBlock = new Block(new MatrixCoords(i, j));

                    engine.AddObject(currBlock);
                    engine.AddObject(ceilingWall);
                }
            }
            engine.AddObject(new IndestructibleBlock(new MatrixCoords(startRow - 1, endCol - 1)));
            engine.AddObject(new IndestructibleBlock(new MatrixCoords(startRow - 1, endCol)));

            for (int i = startRow; i < WorldRows; i++)
            {
                IndestructibleBlock leftWall = new IndestructibleBlock(new MatrixCoords(i, startCol - 1));
                IndestructibleBlock rightWall = new IndestructibleBlock(new MatrixCoords(i, endCol));
                
                engine.AddObject(leftWall);
                engine.AddObject(rightWall);
            }

            //Ball theBall = new Ball(new MatrixCoords(WorldRows / 2, 0), new MatrixCoords(-1, 1)); //original ball
            //MeteoriteBall theBall = new MeteoriteBall(new MatrixCoords(WorldRows / 2, 0), new MatrixCoords(-1, 1)); //MeteoriteBall
            UnstoppableBall theBall = new UnstoppableBall(new MatrixCoords(WorldRows / 2, 0), new MatrixCoords(-1, 1));

            engine.AddObject(theBall);

            Racket theRacket = new Racket(new MatrixCoords(WorldRows - 1, WorldCols / 2), RacketLength);
            engine.AddObject(theRacket);
        }

        static void Main(string[] args)
        {
            IRenderer renderer = new ConsoleRenderer(WorldRows, WorldCols);
            IUserInterface keyboard = new KeyboardInterface();

            Engine gameEngine = new Engine(renderer, keyboard, 300);

            //shooting Racket
            //RacketShooter gameEngine = new RacketShooter(renderer, keyboard, 300);          
            //gameEngine.AddObject(gameEngine.ShootPlayerRacket(new MatrixCoords(WorldRows - 1, WorldCols / 2), RacketLength));
            
            keyboard.OnLeftPressed += (sender, eventInfo) =>
            {
                gameEngine.MovePlayerRacketLeft();
            };

            keyboard.OnRightPressed += (sender, eventInfo) =>
            {
                gameEngine.MovePlayerRacketRight();
            };

            Initialize(gameEngine);

            //add new TrailObject living 30 updates
            TrailObject myTrail = new TrailObject(new MatrixCoords(5, 2), new char[1, 1] { {'%'} }, 30);
            gameEngine.AddObject(myTrail);

            //add 5 Random Unpassable Blocks
            Random rnd = new Random();
            for (int i = 0; i < 5; i++)
            {
                UnpassableBlock myUnpassBlock = new UnpassableBlock(new MatrixCoords(rnd.Next(3, WorldRows - 1), rnd.Next(2, WorldCols - 1)));
                gameEngine.AddObject(myUnpassBlock);    
            }

            gameEngine.Run();
        }
    }
}
