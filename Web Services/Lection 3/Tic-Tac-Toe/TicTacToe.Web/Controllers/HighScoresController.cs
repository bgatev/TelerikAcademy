namespace TicTacToe.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Web.Http;

    using Microsoft.AspNet.Identity;

    using TicTacToe.Data;
    using TicTacToe.Models;
    using TicTacToe.Web.DataModels;
    using TicTacToe.GameLogic;
    using TicTacToe.Web.Infrastructure;

    [Authorize]
    public class HighScoresController : BaseApiController
    {
        private IGameResultValidator resultValidator;
        private IUserIdProvider userIdProvider;

        public HighScoresController(
            ITicTacToeData data,
            IGameResultValidator resultValidator,
            IUserIdProvider userIdProvider)
            : base(data)
        {
            this.resultValidator = resultValidator;
            this.userIdProvider = userIdProvider;
        }

        [HttpGet]
        public IHttpActionResult All()
        {
            var scores = this.data.HighScores.All().OrderByDescending(s => s.Score).Take(10);

            return Ok(scores);
        }
    }
}