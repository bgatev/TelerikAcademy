using System;

public class Program
{
    private const int MaxCount = 6;

    public class Inner
    {
        public void PrintAsString(bool variable)
        {
            string variableStr = variable.ToString();
            Console.WriteLine(variableStr);
        }
    }

    public static void Main()
    {
        Program.Inner newInstance = new Program.Inner();
        newInstance.PrintAsString(true);
    }
}
