using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exam.Models
{
    [Table("Server")]
    public class ServerLocal
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        [Unique, MaxLength(20)]
        public string HostName { get; set; }

        [Unique, MaxLength(15)]
        public string IPAddress { get; set; }

        public string Description { get; set; }

        public Location Location { get; set; }
    }
}
