namespace TicTacToe.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class HighScore
    {
        public int Id { get; set; }

        public int Score { get; set; }
        [Required]
        public string PlayerId { get; set; }

        public virtual User Player { get; set; }
    }
}
