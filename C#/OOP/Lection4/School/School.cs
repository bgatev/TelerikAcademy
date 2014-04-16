using System;
using System.Collections.Generic;
using System.Linq;

namespace School
{
    public class MySchool
    {
        private List<Classes> myClasses;

        public MySchool()
        {
            this.myClasses = new List<Classes>();
        }

        public void AddClass(Classes inClass)
        {
            this.myClasses.Add(inClass);
        }
    }
}
