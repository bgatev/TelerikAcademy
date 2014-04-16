using System;

class Task2MissCat2011
{
    static void Main()
    {
        ushort catvote,catwinner=0,catnum=0;
        ushort[] cat=new ushort[10];
        uint N;
        
        for (int i = 0; i < 10; i++)
		{
			 cat[i]=0;
		}

        N = uint.Parse(Console.ReadLine());

        for (int i = 0; i < N; i++)
        {
            catvote = ushort.Parse(Console.ReadLine());
            switch (catvote)
            {
                case 1: cat[0]++; break;
                case 2: cat[1]++; break;
                case 3: cat[2]++; break;
                case 4: cat[3]++; break;
                case 5: cat[4]++; break;
                case 6: cat[5]++; break;
                case 7: cat[6]++; break;
                case 8: cat[7]++; break;
                case 9: cat[8]++; break;
                case 10: cat[9]++; break;
            }
        }

        if (cat[0] >= cat[1])
        {
            catwinner = cat[0];
            catnum = 1;
        }
        else
        {
            catwinner = cat[1];
            catnum = 2;
        }
        if (catwinner < cat[2])
        {
            catwinner = cat[2];
            catnum = 3;
        }
 	    if (catwinner<cat[3]) 
        {
            catwinner = cat[3];
            catnum = 4;
	    }
        if (catwinner < cat[4])
        {
            catwinner = cat[4];
            catnum = 5;
        }
        if (catwinner < cat[5])
        {
            catwinner = cat[5];
            catnum = 6;
        }
        if (catwinner < cat[6])
        {
            catwinner = cat[6];
            catnum = 7;
        }
        if (catwinner < cat[7])
        {
            catwinner = cat[7];
            catnum = 8;
        }
        if (catwinner < cat[8])
        {
            catwinner = cat[8];
            catnum = 9;
        }
        if (catwinner < cat[9])
        {
            catwinner = cat[9];
            catnum = 10;
        }

        Console.WriteLine(catnum);

    }
}

