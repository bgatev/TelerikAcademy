namespace App.WebAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;

    public class PlayRequestDataModel
    {
        public int GameId { get; set; }

        [StringLength(4)]
        [Required]
        public string Number { get; set; }
    }
}