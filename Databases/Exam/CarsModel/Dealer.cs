namespace CarsModel
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Dealer
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public string City { get; set; }
    }
}
