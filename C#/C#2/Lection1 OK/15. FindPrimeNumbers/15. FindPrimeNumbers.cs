//Write a program that finds all prime numbers in the range [1...10 000 000]. Use the sieve of Eratosthenes algorithm (find it in Wikipedia).

using System;

class FindPrimeNumbers
{
    static void SetPrimeNumbersMultipliersToZero(int[] inArray, int primeNumber)
    {
        for (int i = 2; i < (inArray.Length / primeNumber + 1); i++) inArray[primeNumber * i - 1] = 0;      
    }
    
    static void Main()
    {
        int[] numArray = new int[10000000];
        int primeNumbersCount = 0;

        for (int i = 0; i < numArray.Length; i++) numArray[i] = (i + 1);

        for (int i = 2; i < numArray.Length; i++) SetPrimeNumbersMultipliersToZero(numArray, i);

        for (int i = 0; i < numArray.Length; i++)
        {
            if (numArray[i] != 0)
            {
                Console.Write("{0} ", numArray[i]);
                primeNumbersCount++;
            }
        }
        Console.WriteLine(primeNumbersCount);
    }
}

