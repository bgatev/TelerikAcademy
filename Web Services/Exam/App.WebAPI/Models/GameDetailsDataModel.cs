namespace App.WebAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Web;

    using App.Models;

    public class GameDetailsDataModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime DateCreated { get; set; }

        public string Red { get; set; }

        public string Blue { get; set; }

        public string YourNumber { get; set; }

        public ICollection<Guess> YourGuesses { get; set; }

        public ICollection<Guess> OpponentGuesses { get; set; }  

        public static Expression<Func<Game, GameDetailsDataModel>> FromGame
        {
            get
            {
                return g => new GameDetailsDataModel()
                {
                    Id = g.Id,
                    Name = g.Name,
                    DateCreated = g.DateCreated,
                    Red = g.RedPlayer.UserName,
                    Blue = g.BluePlayer.UserName,
                };
            }
        }
    }
}