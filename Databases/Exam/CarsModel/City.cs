namespace CarsModel
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class City
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(10)]
        [Index("CityName", IsUnique = false)]
        public string Name { get; set; }
    }
}
