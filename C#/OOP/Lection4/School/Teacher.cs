using System;
using System.Collections.Generic;
using System.Linq;

namespace School
{
    public class Teacher : People
    {
        private List<Discipline> discipline;
        public Teacher(string name):base(name)
        {
            this.discipline = new List<Discipline>();    
        }

        public void AddDiscipline(Discipline inDiscipline)
        {
            this.discipline.Add(inDiscipline);
        }
    }
}
