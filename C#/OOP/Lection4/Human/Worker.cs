using System;
using System.Linq;

namespace Human
{
    public class Worker : Human
    {
        private int weekSalary, workHoursPerDay;

        public Worker(string firstName, string lastName) : base(firstName, lastName)
        {
        }

        public Worker(string firstName, string lastName, int workerWeekSalary, int workHPD):base(firstName, lastName)
        {
            this.weekSalary = workerWeekSalary;
            this.workHoursPerDay = workHPD;
        }

        public int WeekSalary
        {
            get
            {
                return this.weekSalary;
            }
            set
            {
                if (value > 0) this.weekSalary = value;
                else throw new ArgumentException("Invalid WeekSalary");
            }
        }

        public int WorkHoursPerDay
        {
            get
            {
                return this.workHoursPerDay;
            }
            set
            {
                if ((value >= 0) && (value <= 24)) this.workHoursPerDay = value;
                else throw new ArgumentException("Invalid WorkHoursPerDay");
            }
        }

        public double MoneyPerHour()
        {
            double result = this.weekSalary;

            result /= (this.workHoursPerDay * 7);
            
            return  result;
        }
    }
}
