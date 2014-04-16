using MyLinq;
using System;
using System.Diagnostics;
using System.Linq;

namespace Events
{
    public delegate void Timer(Students[] allStudents);

    public class Event
    {
        public static void Timer(Students[] allStudents, int execTime, int lastedTime)
        {
            Timer myTimer = new Timer(StudentsFilters.FindAlphaNames);
            myTimer += new Timer(StudentsFilters.SortByName);
            myTimer += new Timer(StudentsFilters.SortByNameLinq);

            Stopwatch time = new Stopwatch();
            time.Start();
            while (time.ElapsedMilliseconds < lastedTime)
                if (time.ElapsedMilliseconds % execTime == 0) myTimer(allStudents);
 
            time.Stop();
        }
    }

}
