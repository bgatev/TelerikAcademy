namespace App.WebAPI.Models
{
    using System.ComponentModel.DataAnnotations;

    public class UsersRankDataModel
    {
        [Required]
        public string Username { get; set; }

        public int Rank { get; set; }
    }
}