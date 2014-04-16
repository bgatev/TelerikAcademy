using System;

class BullsandCows
{
    static void Main()
    {
        int secretNumber,b,bulls=0,c,cows=0, flag=0,flag2=0, zeroPassed=0,onePassed=0,twoPassed=0,threePassed=0;
        int[] secretDigits = new int[4];
        int[] numDigits = new int[4];

        secretNumber = int.Parse(Console.ReadLine());
        b = int.Parse(Console.ReadLine());
        c = int.Parse(Console.ReadLine());

        secretDigits[0] = secretNumber / 1000;
        secretDigits[1] = (secretNumber / 100) % 10;
        secretDigits[2] = (secretNumber / 10) % 10;
        secretDigits[3] = secretNumber % 10;

        for (int i = 1000; i < 10000; i++)
        {
            numDigits[0] = i / 1000;
            numDigits[1] = (i / 100) % 10;
            numDigits[2] = (i / 10) % 10;
            numDigits[3] = i % 10;
           
            for (int j = 0; j < 4; j++)
            {
                if (numDigits[j] == secretDigits[j]) bulls++;
                else if (flag2 == 0)
                {
                    flag2 = 2;
                    if (numDigits[0] != secretDigits[0])
                    {
                        if ((numDigits[1] != secretDigits[1]) && (numDigits[0] == secretDigits[1]))
                        {
                            cows++;
                            onePassed++;
                        }
                        else if ((numDigits[2] != secretDigits[2]) && (numDigits[0] == secretDigits[2]))
                        {
                            cows++;
                            twoPassed++;
                        }
                        else if ((numDigits[3] != secretDigits[3]) && (numDigits[0] == secretDigits[3]))
                        {
                            cows++;
                            threePassed++;
                        }
                    }
                    if (numDigits[1] != secretDigits[1])
                    {
                        if ((numDigits[0] != secretDigits[0]) && (numDigits[1] == secretDigits[0]) && (zeroPassed ==0 ))
                        {
                            cows++;
                            zeroPassed++;
                        }
                        else if ((numDigits[2] != secretDigits[2]) && (numDigits[1] == secretDigits[2]) && (twoPassed == 0))
                        {
                            cows++;
                            twoPassed++;
                        }
                        else if ((numDigits[3] != secretDigits[3]) && (numDigits[1] == secretDigits[3]) && (threePassed == 0))
                        {
                            cows++;
                            threePassed++;
                        }
                    }
                    if (numDigits[2] != secretDigits[2])
                    {
                        if ((numDigits[0] != secretDigits[0]) && (numDigits[2] == secretDigits[0]) && (zeroPassed == 0))
                        {
                            cows++;
                            zeroPassed++;
                        }
                        else if ((numDigits[1] != secretDigits[1]) && (numDigits[2] == secretDigits[1]) && (onePassed == 0))
                        {
                            cows++;
                            onePassed++;
                        }
                        else if ((numDigits[3] != secretDigits[3]) && (numDigits[2] == secretDigits[3]) && (threePassed == 0))
                        {
                            cows++;
                            threePassed++;
                        }
                    }
                    if (numDigits[3] != secretDigits[3])
                    {
                        if ((numDigits[0] != secretDigits[0]) && (numDigits[3] == secretDigits[0]) && (zeroPassed == 0))
                        {
                            cows++;
                            zeroPassed++;
                        }
                        else if ((numDigits[1] != secretDigits[1]) && (numDigits[3] == secretDigits[1]) && (onePassed == 0))
                        {
                            cows++;
                            onePassed++;
                        }
                        else if ((numDigits[2] != secretDigits[2]) && (numDigits[3] == secretDigits[2]) && (twoPassed == 0))
                        {
                            cows++;
                            twoPassed++;
                        }
                    }                
                }       
            }
            flag2 = 0;
            zeroPassed = 0;
            onePassed = 0;
            twoPassed = 0;
            threePassed = 0;

            if ((bulls == b) && (cows == c) && (numDigits[0] != 0) && (numDigits[1] != 0) && (numDigits[2] != 0) && (numDigits[3] != 0))
            {
                Console.Write("{0} ", i);
                flag = 1;
            }
            
            bulls = 0;
            cows = 0;
        }
        
        if (flag==0) Console.WriteLine("No");
    }
}