namespace App.WebAPI.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Http;

    using App.Data;
    using App.WebAPI.Models;
    using App.WebAPI.Infrastructure;

    public class ScoresController : BaseApiController
    {
        private IUserIdProvider userIdProvider;

        public ScoresController(IAppData data) : base(data)
        {
        }

        public ScoresController(IAppData data, IUserIdProvider userIdProvider)
            : base(data)
        {
            this.userIdProvider = userIdProvider;
        }

        [HttpGet]
        public IHttpActionResult GetHighScores()
        {
            var allUsers = this.CalculateRank();

            return Ok(allUsers);
        }

        private IQueryable<UsersRankDataModel> CalculateRank()
        {
            var allUsers = this.data.Users.All();
            HashSet<UsersRankDataModel> allUsersInfo = new HashSet<UsersRankDataModel>();

            foreach (var user in allUsers)
            {
                int rank = 100 * user.Wins + 15 * user.Losses;
                allUsersInfo.Add(new UsersRankDataModel() { Username = user.UserName, Rank = rank });
            }

            var result = allUsersInfo.OrderByDescending(r => r.Rank).ThenBy(u => u.Username).Take(10);

            return result.AsQueryable();
        }

    }
}