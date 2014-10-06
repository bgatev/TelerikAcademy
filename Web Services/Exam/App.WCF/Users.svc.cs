namespace App.WCF
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.ServiceModel;
    using System.ServiceModel.Web;
    using System.Text;

    using App.Data;
    using App.Models;

    public class Users : IUsers
    {
        private IAppData data;
        private const int PageCount = 10;

        public Users()
        {
            this.data = new AppData(AppDbContext.Create());
        }

        public ICollection<User> GetUsers()
        {
            return this.GetUsersPaged(0);
        }

        public ICollection<User> GetUsersPaged(int page)
        {
            return this.data.Users.All().OrderBy(u => u.UserName).Skip(page * PageCount).Take(10)
                                  .Select(a => new User() {Id = a.Id, UserName = a.UserName }).ToList();
        }

        public WCFUser GetUserDetailsById(string id)
        {
            var user = this.data.Users.All().Where(u => u.Id == id).FirstOrDefault();

            int rank = 100 * user.Wins + 15 * user.Losses;
            var currentUser = new WCFUser() 
            { 
                Id = id,
                Losses = user.Losses,
                Rank = rank,
                Username = user.UserName,
                Wins = user.Wins
            };

            return currentUser;
        }
    }
}
