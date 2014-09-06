namespace WolfRaider.DataConverter.Exporters
{
    using System.Web.Script.Serialization;
    using WolfRaider.Common.Models;
    using WolfRaider.DataConverter.Exporters.Contracts;

    /// <summary>
    /// A class for exporting some data to to a json file.
    /// </summary>
    public class JsonExporter : IExporter<string>
    {
        private readonly JavaScriptSerializer serializer;

        public JsonExporter()
        {
            this.serializer = new JavaScriptSerializer();
        }

        public string ConvertEmployee(Employee employee)
        {
           return this.GetJson(employee);
        }

        public string ConvertOccupation(Occupation occupation)
        {
            return this.GetJson(occupation);
        }

        public string ConvertNationality(Nationality nationality)
        {
            return this.GetJson(nationality);
        }

        public string ConvertPosition(Position position)
        {
            return this.GetJson(position);
        }

        public string ConvertGame(Game game)
        {
            return this.GetJson(game);
        }

        public string ConvertSquadHistory(SquadHistory squadHistory)
        {
            return this.GetJson(squadHistory);
        }

        public string ConvertTeam(Team team)
        {
            return this.GetJson(team);
        }

        public string ConvertWorkHistory(WorkHistory workHistory)
        {
            return this.GetJson(workHistory);
        }

        private string GetJson(object data)
        {
            string json = this.serializer.Serialize(data);
            return json;
        }
    }
}
