using System;
using System.Linq;

namespace Students
{
    public class Student:ICloneable, IComparable<Student>
    {
        private Human personalData;
        private Universities uni;
        private Faculties fac;
        private Specialities spec;
        private string ssn;
        private int course;

        public Student()
        {
        }

        public Student(Human person)
        {
            this.personalData = person;    
        }

        public Student(Human person, Universities studentUni, Faculties studentFac, Specialities studentSpec, string ssnum, int studentCourse)
        {
            this.personalData = person;
            this.uni = studentUni;
            this.fac = studentFac;
            this.spec = studentSpec;
            this.ssn = ssnum;
            this.course = studentCourse;
        }

        public Human PersonalData
        {
            get
            {
                return this.personalData;
            }
            set
            {
                this.personalData = value;
            }
        }

        public Universities Uni
        {
            get
            {
                return this.uni;
            }
            set
            {
                this.uni = value;
            }
        }

        public Faculties Fac
        {
            get
            {
                return this.fac;
            }
            set
            {
                this.fac = value;
            }
        }

        public Specialities Spec
        {
            get
            {
                return this.spec;
            }
            set
            {
                this.spec = value;
            }
        }

        public string SSN
        {
            get
            {
                return this.ssn;
            }
            set
            {
                this.ssn = value;
            }
        }

        public int Course
        {
            get
            {
                return this.course;
            }
            set
            {
                this.course = value;
            }
        }

        public override bool Equals(object obj)
        {
            Student tempStudent = obj as Student;

            if (this.spec == tempStudent.spec && this.ssn == tempStudent.ssn) return true;

            return false;
        }
       
        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3} {4} {5}", this.personalData, this.uni, this.fac, this.spec, this.ssn,this.course);
        }

        public override int GetHashCode()
        {
            return this.personalData.GetHashCode() ^ this.ssn.GetHashCode();
        }

        public static bool operator ==(Student firstStudent, Student secondStudent)
        {
            if (firstStudent.Equals(secondStudent)) return true;          
            
            return false;
        }

        public static bool operator !=(Student firstStudent, Student secondStudent)
        {
            if (!firstStudent.Equals(secondStudent)) return true;
            
            return false; 
        }

        public object Clone()
        {
            Student tempSt = new Student();

            /*tempSt.personalData = this.personalData;
            tempSt.uni = this.uni;
            tempSt.fac = this.fac;
            tempSt.spec = this.spec;
            tempSt.ssn = this.ssn;
            tempSt.course = this.course;*/

            tempSt = this.MemberwiseClone() as Student; //All Properties are value type and you can use Shallow Copy == Deep Copy

            return tempSt;
        }

        public int CompareTo(Student other)
        {
            int compareByName = string.Compare(this.personalData.LName, other.personalData.LName);
            
            if (compareByName == 0) return string.Compare(this.ssn, other.ssn);

            return compareByName;
        }
    }
}
