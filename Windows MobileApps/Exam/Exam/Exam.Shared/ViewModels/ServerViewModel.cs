using Exam.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Exam.ViewModels
{
    public class ServerViewModel
    {
        public static Expression<Func<Server, ServerViewModel>> FromModel
        {
            get
            {
                return model =>
                    new ServerViewModel()
                    {
                        HostName = model.HostName,
                        IPAddress = model.IPAddress,
                        Description = model.Description,
                        Location = model.Location
                    };
            }
        }

        public string HostName { get; set; }

        public string IPAddress { get; set; }

        public string Description { get; set; }

        public Location Location { get; set; }
    }
}
