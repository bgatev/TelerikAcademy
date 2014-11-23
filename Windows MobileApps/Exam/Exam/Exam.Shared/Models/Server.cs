using Parse;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exam.Models
{
    [ParseClassName("Server")]
    public class Server : ParseObject
    {
        [ParseFieldName("HostName")]
        public string HostName
        {
            get { return GetProperty<string>(); }
            set { SetProperty<string>(value); }
        }

        [ParseFieldName("IPAddress")]
        public string IPAddress
        {
            get { return GetProperty<string>(); }
            set { SetProperty<string>(value); }
        }

        [ParseFieldName("Description")]
        public string Description
        {
            get { return GetProperty<string>(); }
            set { SetProperty<string>(value); }
        }

        [ParseFieldName("Location")]
        public Location Location
        {
            get { return GetProperty<Location>(); }
            set { SetProperty<Location>(value); }
        }

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
