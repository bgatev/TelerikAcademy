namespace StudentSystemModel
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Homework
    {
        [Key, Required]
        public int Id { get; set; }

        [Required, MaxLength(255)]
        public string Content { get; set; }

        [Required]
        public DateTime TimeSent { get; set; }
    }
}
