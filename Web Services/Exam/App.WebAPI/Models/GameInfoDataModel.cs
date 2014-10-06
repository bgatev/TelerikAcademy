namespace App.WebAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Web;

    using App.Models;

    public class GameInfoDataModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Blue { get; set; }

        public string Red { get; set; }

        public string GameState { get; set; }

        public DateTime DateCreated { get; set; }

        public static Expression<Func<Game, GameInfoDataModel>> FromGame
        {
            get
            {
                return g => new GameInfoDataModel
                {
                    Id = g.Id,
                    Name = g.Name,
                    Blue = g.BluePlayer.UserName,
                    Red = g.RedPlayer.UserName,
                    GameState = Enum.GetName(typeof(GameState), g.State),
                    DateCreated = g.DateCreated
                };
            }
        }
    }
}