namespace App.WebAPI.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Http;

    using App.Data;
    using App.Models;
    using App.WebAPI.Infrastructure;
    using App.WebAPI.Models;

    public class GamesController : BaseApiController
    {
        private const int PageCount = 10;
        private IUserIdProvider userIdProvider;

        public GamesController(IAppData data) : base(data)
        {

        }

        public GamesController(IAppData data, IUserIdProvider userIdProvider) : base(data)
        {
            this.userIdProvider = userIdProvider;
        }

        [HttpPost]
        [Authorize]
        public IHttpActionResult Create([FromBody] string name, string number)
        {
            var currentUserId = this.userIdProvider.GetUserId();

            var newGame = new Game
            {
                Name = name,
                RedPlayer = new User() { Id = currentUserId, UserNumber = number},
                RedPlayerId = currentUserId,
                State = GameState.WaitingForOpponent,
                DateCreated = DateTime.Now
            };

            this.data.Games.Add(newGame);
            this.data.SaveChanges();

            var gameModel = new GameInfoDataModel() 
            {
                Id = newGame.Id,
                Name = newGame.Name,
                Blue = "No blue player yet",
                Red = newGame.RedPlayer.UserName,
                GameState = Enum.GetName(typeof(GameState), newGame.State),
                DateCreated = newGame.DateCreated
            };

            return Ok(gameModel);
        }
        
        [HttpPut]
        [Authorize]
        public IHttpActionResult Join([FromBody] string number)
        {
            var currentUserId = this.userIdProvider.GetUserId();
            var currentUser = this.data.Users.Find(currentUserId);
            currentUser.UserNumber = number;

            var game = this.data.Games.All()
                .Where(g => g.State == GameState.WaitingForOpponent && g.RedPlayerId != currentUserId && g.BluePlayerId != currentUserId)
                .FirstOrDefault();

            if (game == null) return NotFound();
            
            if (game.RedPlayerId == null) game.RedPlayerId = currentUserId;
            else if (game.BluePlayerId == null) game.BluePlayerId = currentUserId;

            Random random = new Random();
            int result = random.Next(100000, 200000);

            if (result % 2 == 0) game.State = GameState.TurnRed;
            else game.State = GameState.TurnBlue;

            this.data.SaveChanges();

            return Ok(string.Format("You joined game {0}", game.Name));
        }

        [HttpGet]
        public IHttpActionResult Status(int gameId)
        {
            var currentUserId = this.userIdProvider.GetUserId();

            var game = this.data.Games.All()
                .Where(x => x.Id == gameId)
                .Select(x => new { x.RedPlayerId, x.BluePlayerId })
                .FirstOrDefault();

            if (game == null) return this.NotFound();

            if (game.RedPlayerId != currentUserId && game.BluePlayerId != currentUserId) return this.BadRequest("This is not your game!");

            var gameInfo = this.data.Games.All()
                .Where(g => g.Id == gameId)
                .Select(g => new GameInfoDataModel()
                {
                    Id = g.Id,
                    Name = g.Name,
                    Blue = g.BluePlayer.UserName,
                    Red = g.RedPlayer.UserName,
                    GameState = Enum.GetName(typeof(GameState), g.State),
                    DateCreated = g.DateCreated
                })
                .FirstOrDefault();

            return Ok(gameInfo);
        }

        [HttpPost]
        public IHttpActionResult MakeGuess(PlayRequestDataModel request)
        {
            if (request == null || !ModelState.IsValid) return this.BadRequest(ModelState);

            var currentUserId = this.userIdProvider.GetUserId();
            var currentUser = this.data.Users.Find(currentUserId);

            var game = this.data.Games.Find(request.GameId);

            if (game == null) return this.BadRequest("Invalid game id!");
            if (game.RedPlayerId != currentUserId && game.BluePlayerId != currentUserId) return this.BadRequest("This is not your game!");
            if (game.State != GameState.TurnRed && game.State != GameState.TurnBlue) return this.BadRequest("Invalid game state!");
            if ((game.State == GameState.TurnRed && game.RedPlayerId != currentUserId) || (game.State == GameState.TurnBlue && game.BluePlayerId != currentUserId)) return this.BadRequest("It's not your turn!");

            var otherUser = new User();
            if (game.RedPlayer != currentUser) otherUser = game.RedPlayer;
            else if (game.BluePlayer != currentUser) otherUser = game.BluePlayer;

            var cowsBullsResult = GetCowBulls(request.Number, otherUser.UserNumber);

            var currentGuess = new Guess() 
            { 
                UserID = currentUserId,
                Username = currentUser.UserName,
                GameID = request.GameId,
                Number = request.Number,
                DateMade = DateTime.Now,
                CowsCount = cowsBullsResult.Cows,
                BullsCount = cowsBullsResult.Bulls
            };


            return Ok(currentGuess);
        }

        // GET api/games
        [HttpGet]
        public IHttpActionResult GetAllPublicGames()
        {
            /*var games = this.GetAllOrdered()
                .Where(s => s.State == GameState.WaitingForPlayer)
                .Take(10)
                .Select(GameInfoDataModel.FromGame).ToList();

            return Ok(games);*/

            return Ok(this.GetPublicGamesByPage(0));
        }

        // GET api/games?page=P
        [HttpGet]
        public IHttpActionResult GetPublicGamesByPage(int page)
        {
            var games = this.GetAllOrdered()
                .Where(s => s.State == GameState.WaitingForOpponent)
                .Skip(page * PageCount)
                .Take(10)
                .Select(GameInfoDataModel.FromGame).ToList();

            return Ok(games);  
        }
        
        // GET api/games
        [HttpGet]
        [Authorize]
        public IHttpActionResult GetAllGames()
        {
            /*var games = this.GetAllOrdered()
                .Where(s => s.State == GameState.WaitingForPlayer || s.State == GameState.TurnRed || s.State == GameState.TurnBlue)
                .Take(10)
                .Select(GameInfoDataModel.FromGame).ToList();

            return Ok(games);*/
            return Ok(GetGamesByPage(0));
        }

        // GET api/games?page=P
        [HttpGet]
        [Authorize]
        public IHttpActionResult GetGamesByPage(int page)
        {
            var games = this.GetAllOrdered()
                .Where(s => s.State == GameState.WaitingForOpponent || s.State == GameState.TurnRed || s.State == GameState.TurnBlue)
                .Skip(page * PageCount)
                .Take(10)
                .Select(GameInfoDataModel.FromGame).ToList();

            return Ok(games);
        }

        // GET api/games/id
        [HttpGet]
        [Authorize]
        public IHttpActionResult GetGamesById(int id)
        {
            var game = this.data.Games.Find(id);
            var currentUserId = this.userIdProvider.GetUserId();

            if (game.RedPlayerId != currentUserId && game.BluePlayerId != currentUserId) return this.BadRequest("This is not your game!");
            var yourNumber = this.data.Users.Find(currentUserId).UserNumber;
            var yourGuesses = GetAllGuesses(id, currentUserId);
            var oppGuesses = new List<Guess>();

            if (game.RedPlayerId == currentUserId) oppGuesses = GetAllGuesses(id, game.BluePlayerId);
            else oppGuesses = GetAllGuesses(id, game.RedPlayerId);

            var currentModel = new GameDetailsDataModel() 
            {
                Id = game.Id,
                Name = game.Name,
                DateCreated = game.DateCreated,
                Red = game.RedPlayer.UserName,
                Blue = game.BluePlayer.UserName,
                YourNumber = yourNumber,
                YourGuesses = yourGuesses,
                OpponentGuesses = oppGuesses
            };

            return Ok(currentModel);
        }

        private IQueryable<Game> GetAllOrdered()
        {
            return this.data.Games.All().OrderBy(s => s.State).ThenBy(n => n.Name).ThenBy(d => d.DateCreated).ThenBy(p => p.RedPlayer.UserName);
        }

        private List<Guess> GetAllGuesses(int gameId, string username)
        {
            return this.data.Guesses.All().Where(g => g.GameID == gameId && g.Username == username).ToList();
        }

        private CowsBullsResult GetCowBulls(string guessNumber, string userNumber)
        {
            // calculate cows and bulls from guessNumber and userNumber
            int cows = 1;
            int bulls = 3;

            return new CowsBullsResult { Cows = cows, Bulls = bulls };
        }
    }
}