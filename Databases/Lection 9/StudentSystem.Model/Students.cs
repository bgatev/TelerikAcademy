namespace StudentSystemModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Students
    {
        public Students()
        {
            this.Homeworks = new HashSet<Homework>();
        }

        [Key, Required]
        public int Id { get; set; }

        [Required, MaxLength(20)]
        public string Name { get; set; }

        [Required]
        public int Number { get; set; }

        public virtual ICollection<Homework> Homeworks { get; set; }
    }
}
