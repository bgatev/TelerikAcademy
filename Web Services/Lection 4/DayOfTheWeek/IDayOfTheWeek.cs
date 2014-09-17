namespace DayOfTheWeek
{
    using System;
    using System.Runtime.Serialization;
    using System.ServiceModel;
    using System.ServiceModel.Web;
    using System.Text;

    [ServiceContract]
    public interface IDayOfTheWeek
    {

        [OperationContract]
        string GetWeekDay(DateTime inputDate);
    }
}
