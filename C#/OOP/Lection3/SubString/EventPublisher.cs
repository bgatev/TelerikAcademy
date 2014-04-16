using MyLinq;
using System;
using System.Threading;

namespace Events
{
    public class Publisher
    {
        public event EventHandler<MyEventArgs> RaiseMyEvent;
        
        public void Start(Students[] allStudents, int execTime, int lastedTime)
        {
            RaiseEvent(new MyEventArgs("The Students Event start"));

            for (int i = 0; i < lastedTime; i+=execTime)
			{
                Thread.Sleep(execTime * 1000);
                StudentsFilters.FindAlphaNames(allStudents);
                StudentsFilters.SortByName(allStudents);
                StudentsFilters.SortByNameLinq(allStudents);
			}
        }

        protected virtual void RaiseEvent(MyEventArgs e)
        {
            EventHandler<MyEventArgs> myEvent = this.RaiseMyEvent;

            if (myEvent != null)
            {
                e.Message += String.Format(" at {0}", DateTime.Now.ToString());
                myEvent(this, e);
            }
        }
    }
}
