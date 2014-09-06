namespace StudentSystemModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Courses
    {
        public Courses()
        {
            this.Homeworks = new HashSet<Homework>();
        }

        [Key, Required]
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(255)]
        public string Materials { get; set; }

        public virtual ICollection<Homework> Homeworks { get; set; }
    }
}
