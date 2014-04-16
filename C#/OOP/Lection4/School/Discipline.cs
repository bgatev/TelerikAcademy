using System;
using System.Collections.Generic;
using System.Linq;

namespace School
{
    public class Discipline : IComment
    {
        private string name;
        private int numOfLectures, numOfExercises;
        
        public Discipline() : this(null, 0, 0)
        {

        }

        public Discipline(string discName):this(discName,0,0)
        {

        }

        public Discipline(string discName, int numberOfLectures, int numberOfExercises)
        {
            this.name = discName;
            this.numOfLectures = numberOfLectures;
            this.numOfExercises = numberOfExercises;
            this.Comments = new List<string>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (value.Length > 0) this.name = value;
                else throw new ArgumentException("Invalid Discipline Name");
            }
        }

        public int NumOfLectures
        {
            get
            {
                return this.numOfLectures;
            }
            set
            {
                if (value > 0) this.numOfLectures = value;
                else throw new ArgumentException("Invalid Number Of Lectures");
            }
        }

        public int NumOfExercises
        {
            get
            {
                return this.numOfExercises;
            }
            set
            {
                if (value > 0) this.numOfExercises = value;
                else throw new ArgumentException("Invalid Number Of Exercises");
            }
        }

        public List<string> Comments { get; set; }

        public void AddComment(string comment)
        {
            this.Comments.Add(comment);
        }
    }
}
