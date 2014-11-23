using Exam.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Exam.ViewModels
{
    public class LocationViewModel
    {
        public static Expression<Func<Location, LocationViewModel>> FromModel
        {
            get
            {
                return model =>
                    new LocationViewModel()
                    {
                        Latitude = model.Latitude,
                        Longitude = model.Longitude,
                        Name = model.Name
                    };
            }
        }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public string Name { get; set; }
    }
}
