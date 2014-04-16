using System;

class Anacci
{
    static void Main()
    {
        char fNum, sNum, fsSum;
        int L, fANum, sANum, fsASum;

        fNum = char.Parse(Console.ReadLine());
        sNum = char.Parse(Console.ReadLine());
        L = int.Parse(Console.ReadLine());

        fANum = Convert.ToInt32(fNum) - 0x40;
        sANum = Convert.ToInt32(sNum) - 0x40;

        if (((fANum + sANum) % 26) == 0) fsASum = 26;
        else fsASum = (fANum + sANum) % 26;

        fsSum = Convert.ToChar(fsASum + 0x40);


        if (L == 1) Console.WriteLine(fNum);
        else                               // L > 1
        {
            Console.WriteLine(fNum);
            for (int i = 0; i < L - 1 ; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    if ((i == 0) && (j == 0)) Console.Write(sNum);
                    
                    Console.Write(fsSum);
                    for (int k = 0; k < i; k++) Console.Write(' ');
                    fNum = sNum;
                    sNum = fsSum;
                    
                    fANum = Convert.ToInt32(fNum) - 0x40;
                    sANum = Convert.ToInt32(sNum) - 0x40;

                    if (((fANum + sANum) % 26) == 0) fsASum = 26;
                    else fsASum = (fANum + sANum) % 26;

                    fsSum = Convert.ToChar(fsASum + 0x40);
                    if (i == 0) break;
                }
                Console.WriteLine();
            }

        }
        //Console.WriteLine("{0} {1} {2}",fANum,sANum, fsSum);
    }
}
