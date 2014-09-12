namespace CarsModel
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Manifacturer
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(10)]
        [Index("ManifacturerName", IsUnique = false)]
        public string Name { get; set; }
    }
}
