using System;
using System.Linq;

class Slides
{
    static void SlideParse(string[, ,] cuboid,ref int currentH, ref int currentD, ref int currentW)
    {
        string pattern = cuboid[currentH, currentD, currentW], cmd = string.Empty;

        if (pattern[0] == 'S')
        {
            cmd = pattern.Substring(2);

            switch (cmd)
            {
                case "L": currentH++; currentW--; break;
                case "R": currentH++; currentW++; break;
                case "F": currentH++; currentD--; break;
                case "B": currentH++; currentD++; break;
                case "FL": currentH++; currentD--; currentW--; break;
                case "FR": currentH++; currentD--; currentW++; break;
                case "BL": currentH++; currentD++; currentW--; break;
                case "BR": currentH++; currentD++; currentW++; break;
                default: break;
            }
        }
    }

    static void Teleport(string[, ,] cuboid, ref int currentH, ref int currentD, ref int currentW)
    {
        string pattern = cuboid[currentH, currentD, currentW], nextCube = string.Empty;

        if (pattern[0] == 'T')
        {
            nextCube = pattern.Substring(2);
            string[] WD = nextCube.Split(' ');
            currentW = int.Parse(WD[0]); currentD = int.Parse(WD[1]);
        }
    }

    static void Empty(string[, ,] cuboid, ref int currentH, ref int currentD, ref int currentW)
    {
        if (cuboid[currentH, currentD, currentW] == "E") currentH++;
    }

    static bool Basket(string[, ,] cuboid, ref int currentH, ref int currentD, ref int currentW)
    {
        if (cuboid[currentH, currentD, currentW] == "B") return true;
        else return false;
    }

    static void Main()
    {
        int W, H, D, ballW, ballD, currentW, currentH, currentD, noSlideW, noSlideH, noSlideD;
        string line = string.Empty;

        line = Console.ReadLine();
        string[] whd = line.Split(' ');
        W = int.Parse(whd[0]); H = int.Parse(whd[1]); D = int.Parse(whd[2]);

        string[, ,] cuboid = new string[H, D, W];

        for (int i = 0; i < H; i++)
        {
            line = Console.ReadLine();
            string[] stringD = line.Split(new string[] {" | "},StringSplitOptions.RemoveEmptyEntries);
            
            for (int j = 0; j < D; j++)
            {
                string[] stringW = stringD[j].Split(new string[] { "(", ")" }, StringSplitOptions.RemoveEmptyEntries);

                for (int k = 0; k < W; k++) cuboid[i, j, k] = stringW[k];
            } 
        }

        line = Console.ReadLine();
        string[] ball = line.Split(' ');
        ballW = int.Parse(ball[0]); ballD = int.Parse(ball[1]);

        currentH = 0;
        currentD = ballD;
        currentW = ballW;

        do
        {
            noSlideH = currentH;
            noSlideD = currentD;
            noSlideW = currentW; 
            SlideParse(cuboid, ref currentH, ref currentD, ref currentW);
            if ((currentD < 0) || (currentD >= D) || (currentW < 0) || (currentW >= W))
            {
                Console.WriteLine("No");
                Console.WriteLine("{0} {1} {2}", noSlideW, noSlideH, noSlideD);
                break;
            }
            if (currentH >= H)
            {
                Console.WriteLine("Yes");
                Console.WriteLine("{0} {1} {2}", noSlideW, noSlideH, noSlideD);
                break;
            }

            noSlideH = currentH;
            noSlideD = currentD;
            noSlideW = currentW;
            Teleport(cuboid, ref currentH, ref currentD, ref currentW);
            if (currentH >= H)
            {
                Console.WriteLine("Yes");
                Console.WriteLine("{0} {1} {2}", noSlideW, noSlideH, noSlideD);
                break;
            }
            
            noSlideH = currentH;
            noSlideD = currentD;
            noSlideW = currentW;
            Empty(cuboid, ref currentH, ref currentD, ref currentW);
            if (currentH >= H)
            {
                Console.WriteLine("Yes");
                Console.WriteLine("{0} {1} {2}", noSlideW, noSlideH, noSlideD);
                break;
            }

            noSlideH = currentH;
            noSlideD = currentD;
            noSlideW = currentW;
            if (Basket(cuboid, ref currentH, ref currentD, ref currentW))
            {
                Console.WriteLine("No");
                Console.WriteLine("{0} {1} {2}", currentW, currentH, currentD);
                break;
            }
            if (currentH >= H)
            {
                Console.WriteLine("Yes");
                Console.WriteLine("{0} {1} {2}", currentW, currentH - 1, currentD);
                break;
            }
        }
        while (true);
       
        
    }
}

