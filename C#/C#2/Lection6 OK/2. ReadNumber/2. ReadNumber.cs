//Write a method ReadNumber(int start, int end) that enters an integer number in given range [start…end]. If an invalid number or non-number
//text is entered, the method should throw an exception. Using this method write a program that enters 10 numbers:
//			a1, a2, … a10, such that 1 < a1 < … < a10 < 100

using System;

class ReadNumber1
{
    private static int counter;

    static int ReadNumber(int start, int end)
    {
        int number = 0;

        try
        {
            Console.WriteLine("Please input number between {0} and {1}", start, end);
            number = int.Parse(Console.ReadLine());
            if ((number < start) || (number > end)) throw new FormatException();
            counter++;
            return number;
        }

        catch(FormatException)
        {
            Console.WriteLine("Invalid number between {0} and {1}", start, end);
        }

        return 0;
        
    }

    static void Main()
    {
        const int ERange = 100;

        int sRange = 1;
        int[] numbers = new int[10];

        counter = 0;
        do
        {
            numbers[counter] = ReadNumber(sRange, ERange);
            Array.Sort(numbers);
            Array.Reverse(numbers);
            sRange = numbers[0];  
        } 
        while (counter < 10);

        Array.Reverse(numbers);
        Console.WriteLine();
        for (int i = 0; i < numbers.Length; i++) Console.WriteLine(numbers[i]);
        
    }
}
