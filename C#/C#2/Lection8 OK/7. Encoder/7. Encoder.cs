//Write a program that encodes and decodes a string using given encryption key (cipher). The key consists of a sequence of characters. 
//The encoding/decoding is done by performing XOR (exclusive or) operation over the first letter of the string with the first of the key, 
//the second – with the second, etc. When the last key character is reached, the next is the first.

using System;
using System.Linq;

class Encoder
{
    static int ExtractBit(int num, int bitnum)
    {
        int bit;

        bit = ((num & (1 << bitnum)) >> bitnum);
        
        return bit;
    }

    static string Encode(string stringToEncode, string cipher)
    {
        string encodedString = string.Empty;

        for (int i = 0, j = 0; i < stringToEncode.Length; i++)
        {

            encodedString += Convert.ToChar(stringToEncode[i] ^ ExtractBit(cipher[j], j));

            if (j < cipher.Length - 1) j++;
            else j = 0;
        }

        return encodedString;
    }

    static string Decode(string stringToDecode, string cipher)
    {
        string decodedString = string.Empty;

        decodedString = Encode(stringToDecode, cipher);

        return decodedString;
    }

    static void Main()
    {
        const string Key = "CipherIsVeryLong";

        string sourceString = string.Empty, encodedString = string.Empty, decodedString = string.Empty;

        sourceString = Console.ReadLine();

        encodedString = Encode(sourceString, Key);
        Console.WriteLine(encodedString);

        decodedString = Decode(encodedString, Key);
        Console.WriteLine(decodedString);  
    }
}

