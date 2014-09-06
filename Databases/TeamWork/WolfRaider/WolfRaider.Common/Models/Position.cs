namespace WolfRaider.Common.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using MongoRepository;

    public partial class Position : Entity
    {
        public Position()
            : this(Guid.NewGuid(), null)
        {
        }

        public Position(string name)
            : this(Guid.NewGuid(), name)
        {
        }

        public Position(Guid positionId, string name)
        {
            this.PositionId = positionId;
            this.Name = name;

            this.Employees = new HashSet<Employee>();
            this.SquadHistories = new HashSet<SquadHistory>();
        }

        [Key]
        public Guid PositionId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }

        public virtual ICollection<SquadHistory> SquadHistories { get; set; }

        [NotMapped]
        public override string Id { get; set; }
    }
}
