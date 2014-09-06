namespace WolfRaider.Common.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using MongoRepository;

    public partial class Nationality : Entity
    {
        public Nationality()
            : this(Guid.NewGuid(), null)
        {
        }

        public Nationality(string name)
            : this(Guid.NewGuid(), name)
        {
        }

        public Nationality(Guid nationalityId, string name)
        {
            this.NationalityId = nationalityId;
            this.Name = name;

            this.NationalityId = Guid.NewGuid();
            this.Teams = new HashSet<Team>();
            this.Citizens = new HashSet<Employee>();
        }

        [Key]
        [Required]
        public Guid NationalityId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public virtual ICollection<Employee> Citizens { get; set; }

        public virtual ICollection<Team> Teams { get; set; }

        [NotMapped]
        public override string Id { get; set; }
    }
}
