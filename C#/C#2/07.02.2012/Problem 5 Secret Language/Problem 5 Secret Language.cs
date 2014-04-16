using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Problem5SecretLanguage
{
    static void Main()
    {
        int totalCost = 0;

        string sentence = Console.ReadLine();
        string words = Console.ReadLine();
        string[] word = words.Split(new string[] {", ", "\""},StringSplitOptions.RemoveEmptyEntries);



        if (totalCost > 0) Console.WriteLine(totalCost);
        else Console.WriteLine(-1);
    }
}

