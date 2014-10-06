namespace ASPNETWebAPI.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class ArtistModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Country { get; set; }

        public DateTime DateOfBirth { get; set; }
    }
}