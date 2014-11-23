using Parse;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exam.Models
{
    [ParseClassName("User")]
    public class User : ParseObject
    {
        [ParseFieldName("Username")]
        public string Username
        {
            get { return GetProperty<string>(); }
            set { SetProperty<string>(value); }
        }

        [ParseFieldName("Password")]
        public string Password
        {
            get { return GetProperty<string>(); }
            set { SetProperty<string>(value); }
        }

        [ParseFieldName("Group")]
        public string Group
        {
            get { return GetProperty<string>(); }
            set { SetProperty<string>(value); }
        }

        public User(string username, string password, string group)
        {
            this.Username = username;
            this.Password = password;
            this.Group = group;
        }

        public User()
            : this(Constants.USERNAME_DEFAULT, Constants.PASSWORD_DEFAULT, Constants.GROUP_DEFAULT)
        {

        }
    }
}
