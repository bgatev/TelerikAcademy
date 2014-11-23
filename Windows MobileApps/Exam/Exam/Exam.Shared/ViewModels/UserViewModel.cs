using Exam.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Exam.ViewModels
{
    public class UserViewModel
    {
        public static Expression<Func<User, UserViewModel>> FromModel
        {
            get
            {
                return model =>
                    new UserViewModel()
                    {
                        Username = model.Username,
                        Password = model.Password,
                        Group = model.Group
                    };
            }
        }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Group { get; set; }
    }
}
