using System;

class Problem1FighterAttack
{
    static void Main()
    {
        int pX1, pY1, pX2, pY2, fX, fY, D, result=0, hitX, hitY;
     
        pX1 = int.Parse(Console.ReadLine());
        pY1 = int.Parse(Console.ReadLine());
        pX2 = int.Parse(Console.ReadLine());
        pY2 = int.Parse(Console.ReadLine());
        fX = int.Parse(Console.ReadLine());
        fY = int.Parse(Console.ReadLine());
        D = int.Parse(Console.ReadLine());

        hitX = fX + D;
        hitY = fY;

        if (pY1 < pY2)
        {
            if ((hitY > pY2 + 1) || (hitY < pY1 - 1) || (hitX < pX1 - 1) || (hitX > pX2) || ((hitX == pX1 - 1) && (hitY == pY2 + 1)) || ((hitX == pX1 - 1) && (hitY == pY1 - 1)))
            {
                result = 0;
            }
            else if (((hitY == pY2 + 1) && (hitX >= pX1 || hitX <= pX2)) || ((hitY == pY1 - 1) && (hitX >= pX1 || hitX <= pX2)))
            {
                result = 50;

            }
            else if ((hitX == pX1 - 1) && (hitY >= pY1 || hitY <= pY2))
            {
                result = 75;
            }
            else if ((hitX == pX2) && (hitY == pY1 || hitY == pY2))
            {
                result = 150;
            }
            else if ((hitX == pX2) && (hitY > pY1 || hitY < pY2))
            {
                result = 200;
            }
            else if (((hitY == pY1) && (hitX >= pX1 || hitX < pX2)) || ((hitY == pY2) && (hitX >= pX1 || hitX < pX2)))
            {
                result = 225;
            }
            else result = 275;
        }
        else if (pY1 > pY2)
        {
            if ((hitY > pY1 + 1) || (hitY < pY2 - 1) || (hitX < pX1 - 1) || (hitX > pX2) || ((hitX == pX1 - 1) && (hitY == pY1 + 1)) || ((hitX == pX1 - 1) && (hitY == pY2 - 1)))
            {
                result = 0;
            }
            else if (((hitY == pY1 + 1) && (hitX >= pX1 || hitX <= pX2)) || ((hitY == pY2 - 1) && (hitX >= pX1 || hitX <= pX2)))
            {
                result = 50;

            }
            else if ((hitX == pX1 - 1) && (hitY >= pY2 || hitY <= pY1))
            {
                result = 75;
            }
            else if ((hitX == pX2) && (hitY == pY1 || hitY == pY2))
            {
                result = 150;
            }
            else if ((hitX == pX2) && (hitY > pY2 || hitY < pY1))
            {
                result = 200;
            }
            else if (((hitY == pY1) && (hitX >= pX1 || hitX < pX2)) || ((hitY == pY2) && (hitX >= pX1 || hitX < pX2)))
            {
                result = 225;
            }
            else result = 275;
        }
        else//pY1=pY2
        {
            if ((hitY > pY1 + 1) || (hitY < pY1 - 1) || (hitX < pX1 - 1) || (hitX > pX2) || ((hitX == pX1 - 1) && (hitY == pY1 + 1)) || ((hitX == pX1 - 1) && (hitY == pY1 - 1)))
            {
                result = 0;
            }
            else if (((hitY == pY1 + 1) && (hitX >= pX1 || hitX <= pX2)) || ((hitY == pY1 - 1) && (hitX >= pX1 || hitX <= pX2)))
            {
                result = 50;

            }
            else if ((hitX == pX1 - 1) && (hitY == pY1))
            {
                result = 75;
            }
            else if ((hitX == pX2) && (hitY == pY1))
            {
                result = 100;
            }
            else result = 175;
        }

        Console.WriteLine("{0}%", result);
    }
}

