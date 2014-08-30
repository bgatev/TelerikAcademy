using System;
using WolfRaider.Common.Models.Contracts;

namespace WolfRaider.Common.Models
{
    public class TestData : IExportable
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public TestData(string name)
        {
            this.Id = Guid.NewGuid();
            this.Name = name;
        }

        public override string ToString()
        {
            return this.Id + " " + this.Name;
        }

        public string GetSerialNumber()
        {
            return this.Id.ToString();
        }
    }
}
