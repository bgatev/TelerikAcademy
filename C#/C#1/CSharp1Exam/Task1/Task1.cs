using System;
using System.Threading;
using System.Globalization;


class CoffeeMachine
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        
        double[] N = new double[5];
        double amountA, priceP, changeAmount, machineMoney;

        for (int i = 0; i < 5; i++) N[i] = double.Parse(Console.ReadLine());
        N[0] *= 0.05;
        N[1] *= 0.1;
        N[2] *= 0.2;
        N[3] *= 0.5;

        machineMoney = N[0] + N[1] + N[2] + N[3] + N[4];
        amountA = double.Parse(Console.ReadLine());
        priceP = double.Parse(Console.ReadLine());

        changeAmount = amountA - priceP;

        if (amountA < priceP) Console.WriteLine("More {0:F2}", -changeAmount);
        else if (amountA > (priceP + machineMoney))
        {
            Console.WriteLine("No {0:F2}", amountA - priceP - machineMoney);
        }
        else Console.WriteLine("Yes {0:F2}",machineMoney - changeAmount);
        

    }
}

