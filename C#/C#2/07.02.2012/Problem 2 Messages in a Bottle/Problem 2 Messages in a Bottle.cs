using System;
using System.Linq;
using System.Text;

class Problem2MessagesinaBottle
{
    static void Main()
    {
        int numberOfMsgs = 0, msgIndex = 0;
        string message = Console.ReadLine();
        string cipher = Console.ReadLine();

        StringBuilder sb = new StringBuilder();
        
        for (int i = 0; i < message.Length; i++)
        {
            for (int j = 1; j < cipher.Length; j++)
			{
			    if (message[i] == cipher[j] && char.IsLetter(cipher[j - 1]) && (j == cipher.Length - 1 || char.IsLetter(cipher[j + 1])))
                {
                    sb.Append(cipher[j - 1]);
                    if (sb.Length == message.Length) numberOfMsgs++;
                }
			}
               
        }

        Console.WriteLine(numberOfMsgs);
        Console.WriteLine(sb.ToString());
    }
}

