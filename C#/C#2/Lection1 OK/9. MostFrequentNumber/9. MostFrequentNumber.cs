//Write a program that finds the most frequent number in an array. Example:
//	{4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3}  4 (5 times)

using System;

class MostFrequentNumber1
{
    static string MostFrequentNumber(int[] inArray)
    {
        int tempNum = 1, mostNum = 0, index = 0, element = 0;
        string result;

        for (int i = 0; i < inArray.Length - 1; i++)
        {
            if (inArray[i] == inArray[i + 1]) tempNum++;
            else
            {
                if (tempNum > mostNum)
                {
                    mostNum = tempNum;
                    index = i - (mostNum - 1);
                    element = inArray[i];
                }
                tempNum = 1;
            }
        }
        result = Convert.ToString(index) + Convert.ToString(element) + Convert.ToString(mostNum);

        return result;
    }
    
    
    static void Main()
    {
        int n;
        string mostFrequentNum;

        n = int.Parse(Console.ReadLine());
        int[] numArray = new int[n];

        for (int i = 0; i < numArray.Length; i++) numArray[i] = int.Parse(Console.ReadLine());

        Array.Sort(numArray);

        for (int i = 0; i < numArray.Length; i++) Console.Write("{0} ", numArray[i]);
        Console.WriteLine();

        mostFrequentNum = MostFrequentNumber(numArray);
        Console.WriteLine("In sorted array you have max frequent number {0} start from index {1} and repeated {2} times.", mostFrequentNum[1], mostFrequentNum[0], mostFrequentNum[2]);        

    }
}

