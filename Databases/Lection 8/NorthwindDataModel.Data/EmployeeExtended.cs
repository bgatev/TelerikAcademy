namespace NorthwindDataModel.Data
{
    using System;
    using System.Data.Linq;
    using System.Linq;
    using System.Collections.Generic;

    public partial class EmployeeExtended: Employee
    {
        private EntitySet<Territory> correspondingTerritories;

        public EntitySet<Territory> CorrespondingTerritories
        {
            get
            {
                var currentTeritories = this.Territories;

                this.correspondingTerritories = new EntitySet<Territory>();
                this.correspondingTerritories.AddRange(currentTeritories);

                return this.correspondingTerritories;
            }
        }
    }
}