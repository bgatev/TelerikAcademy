namespace WolfRaider.DataConverter.Importers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    using WolfRaider.Common.Models;
    using WolfRaider.DataConverter.Importers.Contracts;

    public class XmlImporter : IImporter<string>
    {
        public IEnumerable<Position> ParsePositions(string filePath)
        {
            var readFile = XDocument.Load(filePath);
            
            Guid guid = Guid.NewGuid();
            IEnumerable<Position> parsedPositions = (from position in readFile.Descendants("position")
                         select new Position()
                         {
                             Name = position.Element("name").Value
                         }).ToList();

            return parsedPositions;
        }

        public IEnumerable<Employee> ParseEmployees(string filePath)
        {
            var readFile = XDocument.Load(filePath);

            IEnumerable<Employee> parsedPositions = (from employee in readFile.Descendants("position")
                                                     select new Employee()
                                                     {
                                                         //Name = position.Element("name").Value
                                                         FirstName = employee.Element("firstname").Value,
                                                         LastName = employee.Element("lastname").Value,
                                                         Age = int.Parse(employee.Element("age").Value)
                                                     }).ToList();

            return parsedPositions;
        }

        public Employee ConvertToEmployee(string data)
        {
            throw new NotImplementedException();
        }

        public Occupation ConvertToOccupation(string data)
        {
            throw new NotImplementedException();
        }

        public Nationality ConvertToNationality(string data)
        {
            throw new NotImplementedException();
        }

        public Position ConvertToPosition(string data)
        {
            throw new NotImplementedException();
        }

        public Game ConvertToGame(string data)
        {
            throw new NotImplementedException();
        }

        public SquadHistory ConvertToSquadHistory(string data)
        {
            throw new NotImplementedException();
        }

        public Team ConvertToTeam(string data)
        {
            throw new NotImplementedException();
        }

        public WorkHistory ConvertToWorkHistory(string data)
        {
            throw new NotImplementedException();
        }
    }
}
