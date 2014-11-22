using System;
using System.Collections.Generic;
using System.Text;

namespace Exam.Models
{
    public class Location
    {
        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public string Description { get; set; }

        public Location(double latitude, double longitude, string description = Constants.DESCRIPTION_DEFAULT)
        {
            this.Latitude = latitude;
            this.Longitude = longitude;
            this.Description = description;
        }

        public Location()
            : this(Constants.LATITUDE_DEFAULT, Constants.LONGITUDE_DEFAULT)
        { 
        }
    }
}
