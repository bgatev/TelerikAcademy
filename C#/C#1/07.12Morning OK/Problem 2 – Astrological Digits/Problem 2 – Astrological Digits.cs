using System;

class Problem2AstrologicalDigits
{
    static void Main()
    {
        string N;
        int result = 0;

        N = Console.ReadLine();

        do
        {
            result = 0;
            for (int i = 0; i < N.Length; i++) if (!(N[i] == '.' || N[i] == '-')) result += int.Parse(N[i].ToString());
            N = result.ToString();
        } while (result > 9);

        Console.WriteLine(result);
    }
}

