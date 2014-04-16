using System;

class Poker
{
    static void Main()
    {
        int[] cards = new int[5];
        string tempRead;
        int temp;
        
        for (int i = 0; i < 5; i++)
        {
            tempRead = Console.ReadLine();
            switch (tempRead)
            {
                case "2": cards[i] = 2; break;
                case "3": cards[i] = 3; break;
                case "4": cards[i] = 4; break;
                case "5": cards[i] = 5; break;
                case "6": cards[i] = 6; break;
                case "7": cards[i] = 7; break;
                case "8": cards[i] = 8; break;
                case "9": cards[i] = 9; break;
                case "10":cards[i] = 10; break;
                case "J": cards[i] = 11; break;
                case "j": cards[i] = 11; break;
                case "Q": cards[i] = 12; break;
                case "q": cards[i] = 12; break;
                case "K": cards[i] = 13; break;
                case "k": cards[i] = 13; break;
                case "A": cards[i] = 14; break;
                case "a": cards[i] = 14; break;
            }
        }

        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                if (cards[j] > cards[j + 1])
                {
                    temp = cards[j + 1];
                    cards[j + 1] = cards[j];
                    cards[j] = temp;
                }
            }
        }

        if (cards[0] == cards[1] & cards[1] == cards[2] & cards[2] == cards[3] & cards[3] == cards[4] & cards[4] == cards[0]) Console.WriteLine("Impossible");
        else if (cards[1] == cards[2] & cards[2] == cards[3])
        {
            if (cards[0] == cards[1] | cards[4] == cards[1]) Console.WriteLine("Four of a Kind");
            else if (cards[0] == cards[4]) Console.WriteLine("Full House");
            else Console.WriteLine("Three of a Kind");
        }
        else if (cards[0] == cards[1] & cards[1] == cards[2])
        {
            if (cards[3] == cards[4]) Console.WriteLine("Full House");
            else Console.WriteLine("Three of a Kind");
        }
        else if (cards[2] == cards[3] & cards[3] == cards[4])
        {
            if (cards[0] == cards[1]) Console.WriteLine("Full House");
            else Console.WriteLine("Three of a Kind");
        }
        else if ((cards[0] == (cards[1] - 1)) & (cards[1] == (cards[2] - 1)) & (cards[2] == (cards[3] - 1)) & (cards[3] == (cards[4] - 1))) Console.WriteLine("Straight");
        else if ((cards[0] == cards[1] & cards[2] == cards[3]) | (cards[0] == cards[1] & cards[3] == cards[4]) | (cards[1] == cards[2] & cards[3] == cards[4])) Console.WriteLine("Two Pairs");
        else if (cards[0] == cards[1] | cards[1] == cards[2] | cards[2] == cards[3] | cards[3] == cards[4]) Console.WriteLine("One Pair");
        else Console.WriteLine("Nothing");
    }
}

