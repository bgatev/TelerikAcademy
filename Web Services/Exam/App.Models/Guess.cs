namespace App.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Guess
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string UserID { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public int GameID { get; set; }

        [Required]
        [StringLength(4)]
        public string Number { get; set; }

        public DateTime DateMade { get; set; }

        [Range(0, 4)]
        public int CowsCount { get; set; }

        [Range(0, 4)]
        public int BullsCount { get; set; }
    }
}
