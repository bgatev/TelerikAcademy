using System;

public class Program
{
    public void FindValue(int[] numbers, int value)
    {
        for (int i = 0; i < 100; i++)
        {
            Console.WriteLine(numbers[i]);

            if ((i % 10 == 0) && (numbers[i] == value))
            {
                Console.WriteLine("Value Found");
            }
        }

        // More code here
    }
}