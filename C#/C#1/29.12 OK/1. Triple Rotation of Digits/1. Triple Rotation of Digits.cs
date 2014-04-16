using System;

class TripleRotationofDigits
{
    static void Main()
    {
        int K, digit0;
        string result;

        K = int.Parse(Console.ReadLine());

        for (int i = 0; i < 3; i++)
        {
            if (K > 9)
            {
                digit0 = K % 10;
                K /= 10;

                result = digit0.ToString() + K.ToString();
                K = int.Parse(result);
            }
        }

        Console.WriteLine(K);
    }
}

