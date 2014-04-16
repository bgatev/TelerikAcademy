using System;

namespace Events
{
    public class Handler
    {
        private string id;

        public Handler(string ID, Publisher pub)
        {
            id = ID;
            pub.RaiseMyEvent += this.MyEvent;
        }

        public void MyEvent(object sender, MyEventArgs e)
        {
            Console.WriteLine("Event with ID-> " + id + " received the message: {0}", e.Message);
        }
    }
}
