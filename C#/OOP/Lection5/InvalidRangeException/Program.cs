using System;
using System.Linq;

namespace InvalidRangeExceptions
{
    class Program
    {
        static void Main()
        {
            Random numRnd = new Random();
            Random dtRnd = new Random();
            
            int num,dtNum,myNum;
            
            DateTime dtStart = new DateTime(1979, 12, 1);
            DateTime dtEnd = new DateTime(2014, 1, 15);
            DateTime myStart = new DateTime(1980, 1, 1);
            DateTime myEnd = new DateTime(2013, 12, 31);
            
            int dtStartMyEnd = (myEnd - dtStart).Days;
            int myStartDtEnd = (dtEnd - myStart).Days;
            
            while (true)
            {
                try
                {
                    num = numRnd.Next(0, 150);
                    if (num < 0 || num > 100) throw new InvalidRangeException<int>(1, 100, "Invalid Number");
                    else Console.WriteLine(num);

                    dtNum = dtRnd.Next(dtStartMyEnd);
                    myNum = dtRnd.Next(myStartDtEnd);
                    if (dtNum > 12418 || myNum > 12418) throw new InvalidRangeException<DateTime>(myStart, myEnd);
                    else Console.WriteLine(myStart.AddDays(myNum));
                }
                catch (InvalidRangeException<int>)
                {
                    Console.WriteLine("Invalid int data");
                }
                catch (InvalidRangeException<DateTime>)
                {
                    Console.WriteLine("Invalid DateTime data");
                    break;
                }
            }

        }
    }
}
