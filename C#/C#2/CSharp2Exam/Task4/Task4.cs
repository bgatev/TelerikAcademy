using System;
using System.Linq;
using System.Text;

class Task4
{
    static string ReverseString(string s)
    {
        StringBuilder sb = new StringBuilder();

        for (int i = s.Length - 1; i > -1; i--) sb.Append(s[i]);

        return sb.ToString();
    }
    
    static string Encrypt(string msg, char[] cypher, int cypherLength)
    {
        StringBuilder sb = new StringBuilder();

        if (msg.Length >= cypherLength)
        {
            for (int i = 0, j = 0; i < msg.Length; i++, j++)
            {
                char currentSymbol;

                if (j >= cypherLength) j = 0;
                currentSymbol = (char)(((msg[i]-'A') ^ (cypher[j] - 'A')) + 'A');
                sb.Append(currentSymbol);
            }
        }
        else
        {
            int i = 0;
            for (int j = 0; i < msg.Length; i++, j++)
            {
                char currentSymbol;

                currentSymbol = (char)(((msg[j] - 'A') ^ (cypher[i] - 'A')) + 'A');
                sb.Append(currentSymbol);
                
            }

            for (int j = 0; j < cypherLength - msg.Length; j++, i++)
            {
                char currentSymbol;

                currentSymbol = (char)(((sb[j] - 'A') ^ (cypher[i] - 'A')) + 'A');
                sb[j] = currentSymbol;   
            }
        }

        return sb.ToString();
    }

    static string Encode(string msgToEncode)
    {
        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < msgToEncode.Length; i++)
        {
            if (!char.IsDigit(msgToEncode[i])) sb.Append(msgToEncode[i]);
            else
            {
                int digits = i, num = 0;
                while(char.IsDigit(msgToEncode[digits++])) num++;
                string digStr = msgToEncode.Substring(i, num);
                int numbers = int.Parse(digStr);

                for (int j = 0; j < numbers; j++) sb.Append(msgToEncode[i + num]);
                for (int j = 0; j < num; j++) i++;

            }
        }

        return sb.ToString();
    }

    static void Main()
    {       
        string cypheredMsg = Console.ReadLine();

        string cypherLenStr = string.Empty;
        for (int i = cypheredMsg.Length - 1; i > -1; i--)
        {
            if (char.IsDigit(cypheredMsg[i])) cypherLenStr += cypheredMsg[i];
            else break;
        }
        cypherLenStr = ReverseString(cypherLenStr);
        
        int cypherLength = int.Parse(cypherLenStr);
        cypheredMsg = cypheredMsg.Substring(0, cypheredMsg.Length - cypherLenStr.Length);

        string encodedMsg = Encode(cypheredMsg);

        StringBuilder sb = new StringBuilder();
        for (int i = cypherLength; i > 0; i--) sb.Append(encodedMsg[encodedMsg.Length - i]);

        string cyphers = sb.ToString();
        cypheredMsg = encodedMsg.Substring(0,encodedMsg.Length - cypherLength);

        string encryptedMsg = Encrypt(cypheredMsg, cyphers.ToCharArray(), cypherLength);

        Console.WriteLine(encryptedMsg);

    }
}

class Task4Evening
{
    static string Encrypt(string msg, char[] cypher, int cypherLength)
    {
        StringBuilder sb = new StringBuilder();

        if (msg.Length >= cypherLength)
        {
            for (int i = 0, j = 0; i < msg.Length; i++, j++)
            {
                char currentSymbol;

                if (j >= cypherLength) j = 0;
                currentSymbol = (char)(((msg[i] - 'A') ^ (cypher[j] - 'A')) + 'A');
                sb.Append(currentSymbol);
            }
        }
        else
        {
            int i = 0;
            for (int j = 0; i < msg.Length; i++, j++)
            {
                char currentSymbol;

                currentSymbol = (char)(((msg[j] - 'A') ^ (cypher[i] - 'A')) + 'A');
                sb.Append(currentSymbol);

            }

            for (int j = 0; j < cypherLength - msg.Length; j++, i++)
            {
                char currentSymbol;

                currentSymbol = (char)(((sb[j] - 'A') ^ (cypher[i] - 'A')) + 'A');
                sb[j] = currentSymbol;
            }
        }

        return sb.ToString();
    }

    static string Decode(string msgToDecode)
    {
        int num = 1;
        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < msgToDecode.Length - 1; i++)
        {
            if (msgToDecode[i] == msgToDecode[i + 1]) num++;
            else
            {
                if (num > 2)
                {
                    sb.Append(num);
                    sb.Append(msgToDecode[i]);
                }
                else if (num == 2) sb.Append(msgToDecode[i], 2);
                else sb.Append(msgToDecode[i]);
                
                num = 1;
            }
            if ((i == msgToDecode.Length - 2) && (num > 1))
            {
                if (num > 2)
                {
                    sb.Append(num);
                    sb.Append(msgToDecode[i]);
                }
                else if (num == 2) sb.Append(msgToDecode[i], 2);
            }
            else if (i == msgToDecode.Length - 2) sb.Append(msgToDecode[i + 1]);
        }

        return sb.ToString();
    }

    static void Main1()
    {       
        string msg = Console.ReadLine();
        string cypher = Console.ReadLine();

        int cypherLength = cypher.Length;

        string encryptedMsg = Encrypt(msg, cypher.ToCharArray(), cypherLength);
        string msgToDecode = encryptedMsg + cypher;

        string decodedMsg = Decode(msgToDecode);
        string result = decodedMsg + cypherLength;

        Console.WriteLine(result);

    }
}
