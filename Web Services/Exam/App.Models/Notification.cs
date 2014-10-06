namespace App.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Notification
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Message { get; set; }

        public DateTime DateCreated { get; set; }

        public GameState State {get; set;}

        public NotificationType Type {get; set;}

        [Required]
        public int GameId { get; set; }
    }
}
