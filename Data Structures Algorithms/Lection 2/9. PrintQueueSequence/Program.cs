using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        Queue<int> sequence = new Queue<int>();

        sequence.Enqueue(2);

        for (int i = 0; i < 50; i++)
        {
            int currentNumber = sequence.Dequeue();

            Console.WriteLine(currentNumber);

            sequence.Enqueue(currentNumber + 1);
            sequence.Enqueue(2 * currentNumber + 1);
            sequence.Enqueue(currentNumber + 2);
        }
    }
}