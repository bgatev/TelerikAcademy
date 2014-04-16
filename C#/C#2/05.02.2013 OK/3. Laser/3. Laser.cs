using System;
using System.Linq;

class Laser
{
    static int W, H, D;

    static bool OnTheEdge(int currentW, int currentH, int currentD)
    {
        if (currentW == 1)
        {
            if ((currentH == 1) || (currentH == H)) return true;
            if ((currentD == 1) || (currentD == D)) return true;
        }
        else if (currentW == W)
        {
            if ((currentH == 1) || (currentH == H)) return true;
            if ((currentD == 1) || (currentD == D)) return true;
        }
        else
        {
            if ((currentH == 1) && (currentD == 1)) return true;
            if ((currentH == 1) && (currentD == D)) return true;
            if ((currentH == H) && (currentD == 1)) return true;
            if ((currentH == H) && (currentD == D)) return true;
        }

        return false;
    }
  
    static void Main()
    {
        int startW, startH, startD;
        int dirW, dirH, dirD;
        string line = string.Empty;
        
        line = Console.ReadLine();
        string[] whd = line.Split(' ');
        W = int.Parse(whd[0]); H = int.Parse(whd[1]); D = int.Parse(whd[2]);

        bool[, ,] cuboid = new bool[W, H, D];

        for (int i = 0; i < W; i++)
            for (int j = 0; j < H; j++) 
                for (int k = 0; k < D; k++) cuboid[i, j, k] = false;
        
        line = Console.ReadLine();
        string[] startWhd = line.Split(' ');
        startW = int.Parse(startWhd[0]); startH = int.Parse(startWhd[1]); startD = int.Parse(startWhd[2]);

        line = Console.ReadLine();
        string[] dirWhd = line.Split(' ');
        dirW = int.Parse(dirWhd[0]); dirH = int.Parse(dirWhd[1]); dirD = int.Parse(dirWhd[2]);

        do
        {
            cuboid[startW - 1, startH - 1, startD - 1] = true;

            if (((startW + dirW) < 1) || ((startW + dirW) > W)) dirW *= -1;
            if (((startH + dirH) < 1) || ((startH + dirH) > H)) dirH *= -1;
            if (((startD + dirD) < 1) || ((startD + dirD) > D)) dirD *= -1;

            int nextW = (startW + dirW), nextH = (startH + dirH), nextD = (startD + dirD);

            if ((cuboid[nextW - 1, nextH - 1, nextD - 1]) || OnTheEdge(nextW, nextH, nextD)) break;
            else
            {
                startW = nextW;
                startH = nextH;
                startD = nextD;
            }
        }
        while (true);

        Console.WriteLine("{0} {1} {2}", startW, startH, startD);
    }
}

