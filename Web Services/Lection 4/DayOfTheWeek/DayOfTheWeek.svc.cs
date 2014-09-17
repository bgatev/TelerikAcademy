namespace DayOfTheWeek
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.ServiceModel;
    using System.ServiceModel.Web;
    using System.Text;

    public class DayOfTheWeek : IDayOfTheWeek
    {
        public string GetWeekDay(DateTime inputDate)
        {
            string currentDay = inputDate.DayOfWeek.ToString();
            switch (currentDay)
            {
                case "Monday": currentDay = "Понеделник";  break;
                case "Tuesday": currentDay = "Вторник"; break;
                case "Wednesday": currentDay = "Сряда"; break;
                case "Thursday": currentDay = "Четвъртък"; break;
                case "Friday": currentDay = "Петък"; break;
                case "Saturday": currentDay = "Събота"; break;
                case "Sunday": currentDay = "Неделя"; break;
                default: break;
            }

            return currentDay;
        }
    }
}
