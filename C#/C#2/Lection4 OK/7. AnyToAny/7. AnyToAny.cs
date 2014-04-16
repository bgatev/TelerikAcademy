//Write a program to convert from any numeral system of given base s to any other numeral system of base d (2 ≤ s, d ≤  16).

using System;

class AnyToAny1
{
    static int AnyToDec(string inString, int sourceSystem)
    {
        int result = 0;

        for (int i = inString.Length - 1, j = 0; i > -1; i--, j++)
        {
            if ((inString[i] > '9') && (inString[i] < 'G')) result += ((inString[i] - 'A' + 10) * (int)Math.Pow(sourceSystem, j));
            else if ((inString[i] > 'Z') && (inString[i] < 'g')) result += ((inString[i] - 'a' + 10) * (int)Math.Pow(sourceSystem, j));
            else result += ((inString[i] - '0') * (int)Math.Pow(sourceSystem, j));
        }

        return result;
    }

    static string ReverseString(string inString)
    {
        string temp = string.Empty;

        for (int i = inString.Length - 1; i > -1; i--) temp += inString[i];

        return temp;
    }

    static string DecToAny(int num, int destSystem)
    {
        string result = string.Empty;

        do
        {
            if ((num % destSystem) <= 9) result += num % destSystem;
            else if ((num % destSystem) <= 15) result += Convert.ToChar((num % destSystem) + 'A' - 10);

            num /= destSystem;
        }
        while (num > 0);
        result = ReverseString(result);

        return result;
    }

    static void Main()
    {
        string num = string.Empty, resultValue = string.Empty;
        int sourceSystem, destSystem;

        do
        {
            Console.Write("Input less or equal than 32-bit number:");
            num = Console.ReadLine();
        }
        while (num.Length > 32);

        sourceSystem = int.Parse(Console.ReadLine());
        destSystem = int.Parse(Console.ReadLine());

        resultValue = DecToAny(AnyToDec(num, sourceSystem), destSystem);

        Console.WriteLine(resultValue);
    }
}

