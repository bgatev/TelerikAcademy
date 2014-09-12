namespace CarsModel
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Car
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string ManufacturerName { get; set; }

        [Required, MaxLength(20)]
        public string Model { get; set; }

        [Required]
        public TransmissionType TransmissionType { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public Dealer Dealer { get; set; }
    }
}
