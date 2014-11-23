using Parse;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exam.Models
{
    [ParseClassName("Location")]
    public class Location : ParseObject
    {
        [ParseFieldName("Latitude")]
        public double Latitude
        {
            get { return GetProperty<double>(); }
            set { SetProperty<double>(value); }
        }

        [ParseFieldName("Longitude")]
        public double Longitude
        {
            get { return GetProperty<double>(); }
            set { SetProperty<double>(value); }
        }

        [ParseFieldName("Name")]
        public string Name { get; set; }

        public Location(double latitude, double longitude, string name = Constants.NAME_DEFAULT)
        {
            this.Latitude = latitude;
            this.Longitude = longitude;
            this.Name = name;
        }

        public Location()
            : this(Constants.LATITUDE_DEFAULT, Constants.LONGITUDE_DEFAULT)
        { 
        }
    }
}
