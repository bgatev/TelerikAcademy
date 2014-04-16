using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.CodeDom.Compiler;
using Microsoft.CSharp;
using System.Reflection;

namespace SoftwareAcademy
{
	public interface ICourse
    {
        string Name { get; set; }
        ITeacher Teacher { get; set; }
        void AddTopic(string topic);
        string ToString();
    }
	public interface ICourseFactory
    {
        ITeacher CreateTeacher(string name);
        ILocalCourse CreateLocalCourse(string name, ITeacher teacher, string lab);
        IOffsiteCourse CreateOffsiteCourse(string name, ITeacher teacher, string town);
    }
	public interface ILocalCourse : ICourse
    {
        string Lab { get; set; }
    }
	public interface IOffsiteCourse : ICourse
    {
        string Town { get; set; }
    }
	public interface ITeacher
    {
        string Name { get; set; }
        void AddCourse(ICourse course);
        string ToString();
    }    
	public class SoftwareAcademyCommandExecutor
    {
        private static string ReadInputCSharpCode()
        {
            StringBuilder result = new StringBuilder();
            string line;
            while ((line = Console.ReadLine()) != "")
            {
                result.AppendLine(line);
            }
            return result.ToString();
        }

        static void CompileAndRun(string csharpCode)
        {
            // Prepare a C# program for compilation
            string[] csharpClass =
            {
                @"using System;
                  using SoftwareAcademy;

                  public class RuntimeCompiledClass
                  {
                     public static void Main()
                     {"
                        + csharpCode + @"
                     }
                  }"
            };

            // Compile the C# program
            CompilerParameters compilerParams = new CompilerParameters();
            compilerParams.GenerateInMemory = true;
            compilerParams.TempFiles = new TempFileCollection(".");
            compilerParams.ReferencedAssemblies.Add("System.dll");
            compilerParams.ReferencedAssemblies.Add(Assembly.GetExecutingAssembly().Location);
            CSharpCodeProvider csharpProvider = new CSharpCodeProvider();
            CompilerResults compile = csharpProvider.CompileAssemblyFromSource(
                compilerParams, csharpClass);

            // Check for compilation errors
            if (compile.Errors.HasErrors)
            {
                string errorMsg = "Compilation error: ";
                foreach (CompilerError ce in compile.Errors)
                {
                    errorMsg += "\r\n" + ce.ToString();
                }
                throw new Exception(errorMsg);
            }

            // Invoke the Main() method of the compiled class
            Assembly assembly = compile.CompiledAssembly;
            Module module = assembly.GetModules()[0];
            Type type = module.GetType("RuntimeCompiledClass");
            MethodInfo methInfo = type.GetMethod("Main");
            methInfo.Invoke(null, null);
        }

        static void Main()
        {
            string csharpCode = ReadInputCSharpCode();
            CompileAndRun(csharpCode);
        }
    }
	public class Teacher:ITeacher
    {
        private string name;
        List<ICourse> teacherCourses; 

        public Teacher(string fullName)
        {
            this.Name = fullName;
            this.teacherCourses = new List<ICourse>();
        }
        
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (value == null) throw new ArgumentNullException();
                else if (value.Length < 3) throw new ArgumentOutOfRangeException("The name is too short");
                else this.name = value; 
            }
        }

        public void AddCourse(ICourse course)
        {
            this.teacherCourses.Add(course);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(string.Format("Teacher: Name={0}",this.Name));

            if (this.teacherCourses.Count() > 0)
            {
                sb.Append("; Courses=[");
                foreach (var singleCourse in this.teacherCourses)
                {
                    sb.Append(singleCourse.Name);
                    sb.Append(", ");
                }

                if (sb[sb.Length - 2] == ',') sb.Remove(sb.Length - 2, 2);
                sb.Append("]");
            }

            return sb.ToString();
        }
    }
	public class OffsiteCourse:IOffsiteCourse
    {
        private string town, name;
        private ITeacher teacher;
        List<string> courseTopics;

        public OffsiteCourse(string courseName, ITeacher courseTeacher, string courseTown)
        {
            this.Name = courseName;
            if (courseTeacher != null) this.Teacher = courseTeacher;
            this.Town = courseTown;
            this.courseTopics = new List<string>();
        }

        public string Town
        {
            get
            {
                return this.town;
            }
            set
            {
                if (value == null) throw new ArgumentNullException();
                else if (value.Length < 3) throw new ArgumentOutOfRangeException("The town is too short");
                else this.town = value;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (value == null) throw new ArgumentNullException();
                else if (value.Length < 3) throw new ArgumentOutOfRangeException("The name is too short");
                else this.name = value;
            }
        }

        public ITeacher Teacher
        {
            get
            {
                return this.teacher;
            }
            set
            {
                this.teacher = value;
            }
        }

        public void AddTopic(string topic)
        {
            this.courseTopics.Add(topic);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(string.Format("{0}: Name={1}", this.GetType().Name, this.Name));
            if (this.Teacher != null) sb.Append(string.Format("; Teacher={0}", this.Teacher.Name));
            if (this.courseTopics.Count() > 0)
            {
                sb.Append(string.Format("; Topics=["));

                foreach (var singleTopic in this.courseTopics)
                {
                    sb.Append(singleTopic);
                    sb.Append(", ");
                }

                if (sb[sb.Length - 2] == ',') sb.Remove(sb.Length - 2, 2);
                sb.Append("]");
            }

            if (!string.IsNullOrEmpty(this.Town)) sb.Append(string.Format("; Town={0}", this.Town));

            return sb.ToString();
        }
    }
	public class LocalCourse:ILocalCourse
    {
        private string lab, name;
        private ITeacher teacher;
        List<string> courseTopics;

        public LocalCourse(string courseName, ITeacher courseTeacher, string courseLab)
        {
            this.Name = courseName;
            if (courseTeacher != null) this.Teacher = courseTeacher;
            this.Lab = courseLab;
            this.courseTopics = new List<string>();
        }

        public string Lab
        {
            get
            {
                return this.lab;
            }
            set
            {
                if (value == null) throw new ArgumentNullException();
                else if (value.Length < 1) throw new ArgumentOutOfRangeException("The lab is too short");
                else this.lab = value;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (value == null) throw new ArgumentNullException();
                else if (value.Length < 3) throw new ArgumentOutOfRangeException("The name is too short");
                else this.name = value;
            }
        }

        public ITeacher Teacher
        {
            get
            {
                return this.teacher;
            }
            set
            {
                this.teacher = value;
            }
        }

        public void AddTopic(string topic)
        {
            this.courseTopics.Add(topic);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(string.Format("{0}: Name={1}" ,this.GetType().Name,this.Name));
            if (this.teacher != null) sb.Append(string.Format("; Teacher={0}",this.Teacher.Name));
            if (this.courseTopics.Count() > 0)
            {
                sb.Append(string.Format("; Topics=["));

                foreach (var singleTopic in this.courseTopics)
                {
                    sb.Append(singleTopic);
                    sb.Append(", ");
                }

                if (sb[sb.Length - 2] == ',') sb.Remove(sb.Length - 2, 2);
                sb.Append("]");
            }

            if (!string.IsNullOrEmpty(this.Lab)) sb.Append(string.Format("; Lab={0}", this.Lab));
            
            return sb.ToString();
        }
    }
	public class CourseFactory : ICourseFactory
    {
        public ITeacher CreateTeacher(string name)
        {
            Teacher myTeacher = new Teacher(name);

            return myTeacher;
        }

        public ILocalCourse CreateLocalCourse(string name, ITeacher teacher, string lab)
        {
            LocalCourse myLocalCourse = new LocalCourse(name, teacher, lab);

            return myLocalCourse;
        }

        public IOffsiteCourse CreateOffsiteCourse(string name, ITeacher teacher, string town)
        {
            OffsiteCourse myOffsiteCourse = new OffsiteCourse(name, teacher, town);

            return myOffsiteCourse;
        }
    }
}
