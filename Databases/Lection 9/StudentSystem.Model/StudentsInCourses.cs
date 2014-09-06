namespace StudentSystemModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class StudentsInCourses
    {
        [Key, ForeignKey("Courses")]
        public int CoursesId { get; set; }

        [Key, ForeignKey("Students")]
        public int StudentsId { get; set; }

        public Courses Courses { get; set; }

        public Students Students { get; set; }
    }
}
