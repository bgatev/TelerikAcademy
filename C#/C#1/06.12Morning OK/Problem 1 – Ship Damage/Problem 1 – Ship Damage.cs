using System;

class Problem1ShipDamage
{
    static void Main()
    {
        int sX1, sY1, sX2, sY2, H, cX1, cY1, cX2, cY2, cX3, cY3, result = 0;
	    int cX1Hit, cY1Hit, cX2Hit, cY2Hit, cX3Hit, cY3Hit;
        int temp;

        sX1 = int.Parse(Console.ReadLine());
        sY1 = int.Parse(Console.ReadLine());
        sX2 = int.Parse(Console.ReadLine());
        sY2 = int.Parse(Console.ReadLine());
        H = int.Parse(Console.ReadLine());
        cX1 = int.Parse(Console.ReadLine());
        cY1 = int.Parse(Console.ReadLine());
        cX2 = int.Parse(Console.ReadLine());
        cY2 = int.Parse(Console.ReadLine());
        cX3 = int.Parse(Console.ReadLine());
        cY3 = int.Parse(Console.ReadLine());

        cX1Hit = cX1;
        cY1Hit = 2 * H - cY1;
        cX2Hit = cX2;
        cY2Hit = 2 * H - cY2;
        cX3Hit = cX3;
        cY3Hit = 2 * H - cY3;

        if (sY1 > sY2)
        {
            temp = sY1;
            sY1 = sY2;
            sY2 = temp;
        }
        if (sX1 > sX2)
        {
            temp = sX1;
            sX1 = sX2;
            sX2 = temp;
        }

        //corners
        if (((cX1Hit == sX1) || (cX1Hit == sX2)) && ((cY1Hit == sY1) || (cY1Hit == sY2))) result += 25;
        if (((cX2Hit == sX1) || (cX2Hit == sX2)) && ((cY2Hit == sY1) || (cY2Hit == sY2))) result += 25;
        if (((cX3Hit == sX1) || (cX3Hit == sX2)) && ((cY3Hit == sY1) || (cY3Hit == sY2))) result += 25;
        
        //x sides
        if (((cX1Hit == sX1) || (cX1Hit == sX2)) && ((cY1Hit > sY1) && (cY1Hit < sY2))) result += 50;
        if (((cX2Hit == sX1) || (cX2Hit == sX2)) && ((cY2Hit > sY1) && (cY2Hit < sY2))) result += 50;
        if (((cX3Hit == sX1) || (cX3Hit == sX2)) && ((cY3Hit > sY1) && (cY3Hit < sY2))) result += 50;

        //y sides
        if (((cX1Hit > sX1) && (cX1Hit < sX2)) && ((cY1Hit == sY1) || (cY1Hit == sY2))) result += 50;
        if (((cX2Hit > sX1) && (cX2Hit < sX2)) && ((cY2Hit == sY1) || (cY2Hit == sY2))) result += 50;
        if (((cX3Hit > sX1) && (cX3Hit < sX2)) && ((cY3Hit == sY1) || (cY3Hit == sY2))) result += 50;

        //inside
        if (((cX1Hit > sX1) && (cX1Hit < sX2)) && ((cY1Hit > sY1) && (cY1Hit < sY2))) result += 100;
        if (((cX2Hit > sX1) && (cX2Hit < sX2)) && ((cY2Hit > sY1) && (cY2Hit < sY2))) result += 100;
        if (((cX3Hit > sX1) && (cX3Hit < sX2)) && ((cY3Hit > sY1) && (cY3Hit < sY2))) result += 100;


        Console.WriteLine("{0}%",result);
    }
}

