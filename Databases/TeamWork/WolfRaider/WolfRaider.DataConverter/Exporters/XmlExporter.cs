namespace WolfRaider.DataConverter.Exporters
{
    using System.IO;
    using System.Xml.Serialization;
    using WolfRaider.Common.Models;
    using WolfRaider.DataConverter.Exporters.Contracts;

    public class XmlExporter : IExporter<string>
    {
        public string ConvertEmployee(Employee employee)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(employee.GetType());

            TextWriter stream = new StringWriter();
            xmlSerializer.Serialize(stream, employee);

            return stream.ToString();
        }

        public string ConvertOccupation(Occupation occupation)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(occupation.GetType());

            TextWriter stream = new StringWriter();
            xmlSerializer.Serialize(stream, occupation);

            return stream.ToString();
        }

        public string ConvertNationality(Nationality nationality)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(nationality.GetType());

            TextWriter stream = new StringWriter();
            xmlSerializer.Serialize(stream, nationality);

            return stream.ToString();
        }

        public string ConvertPosition(Position position)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(position.GetType());

            TextWriter stream = new StringWriter();
            xmlSerializer.Serialize(stream, position);

            return stream.ToString();
        }

        public string ConvertGame(Game game)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(game.GetType());

            TextWriter stream = new StringWriter();
            xmlSerializer.Serialize(stream, game);

            return stream.ToString();
        }

        public string ConvertSquadHistory(SquadHistory squadHistory)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(squadHistory.GetType());

            TextWriter stream = new StringWriter();
            xmlSerializer.Serialize(stream, squadHistory);

            return stream.ToString();
        }

        public string ConvertTeam(Team team)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(team.GetType());

            TextWriter stream = new StringWriter();
            xmlSerializer.Serialize(stream, team);

            return stream.ToString();
        }

        public string ConvertWorkHistory(WorkHistory workHistory)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(workHistory.GetType());

            TextWriter stream = new StringWriter();
            xmlSerializer.Serialize(stream, workHistory);

            return stream.ToString();
        }
    }
}
