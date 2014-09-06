namespace WolfRaider.Common.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Web.Script.Serialization;
    using System.Xml;
    using System.Xml.Schema;
    using System.Xml.Serialization;

    using MongoRepository;
    using WolfRaider.Common.Models.Contracts;

    public partial class Employee : Entity, IExportable, IXmlSerializable
    {
        public Employee()
            : this(Guid.NewGuid(), null, null, null, null)
        {
        }

        public Employee(string firstName, string lastName, int age)
            : this(Guid.NewGuid(), firstName, lastName, age, null)
        {
        }

        public Employee(Guid employeeId, string firstName, string lastName, int? age, Guid? managerId)
        {
            this.EmployeeId = employeeId;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.ManagerId = managerId;

            this.AvailablePositions = new HashSet<Position>();
            this.Nationalities = new HashSet<Nationality>();
            this.ManagedEmployees = new HashSet<Employee>();
            this.SquadHistories = new HashSet<SquadHistory>();
            this.WorkHistories = new HashSet<WorkHistory>();
        }

        public Guid EmployeeId { get; set; }

        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        public int? Age { get; set; }

        [ScriptIgnore]

        public Guid? ManagerId { get; set; }

        [ScriptIgnore]
        [ForeignKey("ManagerId")]
        public Employee Manager { get; set; }

        [ScriptIgnore]
        [NotMapped]
        public string FullName
        {
            get { return this.FirstName + " " + this.LastName; }
        }

        public ICollection<Position> AvailablePositions { get; set; }

        public ICollection<Nationality> Nationalities { get; set; }

        public ICollection<Employee> ManagedEmployees { get; set; }

        public ICollection<SquadHistory> SquadHistories { get; set; }

        public ICollection<WorkHistory> WorkHistories { get; set; }

        [NotMapped]
        [ScriptIgnore]
        public override string Id { get; set; }

        public string GetSerialNumber()
        {
            return this.EmployeeId.ToString();
        }

        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            throw new NotImplementedException();
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteStartElement("EmployeeId");
            writer.WriteString(this.EmployeeId.ToString());
            writer.WriteEndElement();

            writer.WriteStartElement("FirstName");
            writer.WriteString(this.FirstName);
            writer.WriteEndElement();

            writer.WriteStartElement("LastName");
            writer.WriteString(this.LastName);
            writer.WriteEndElement();

            writer.WriteStartElement("Age");
            writer.WriteString(this.Age.ToString());
            writer.WriteEndElement();
        }
    }
}
