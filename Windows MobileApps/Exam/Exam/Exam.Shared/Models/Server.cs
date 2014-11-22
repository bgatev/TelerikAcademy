using System;
using System.Collections.Generic;
using System.Text;

namespace Exam.Models
{
    public class Server
    {
        public string HostName { get; set; }
        public string IPAddress { get; set; }
        public string Description { get; set; }
        public Location Location { get; set; }

        public Server(string hostname, string ipaddress, string description = "")
        {
            this.HostName = hostname;
            this.IPAddress = ipaddress;
            this.Description = description;
        }

        public Server()
            : this(Constants.HOSTNAME_DEFAULT, Constants.IPADDRESS_DEFAULT)
        {

        }
    }
}
