namespace WolfRaider.Common.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using MongoRepository;

    public partial class Occupation : Entity
    {
        public Occupation()
            : this(Guid.NewGuid(), null)
        {
        }

        public Occupation(string name)
            : this(Guid.NewGuid(), name)
        {
        }

        public Occupation(Guid occupationId, string name)
        {
            this.OccupationId = occupationId;
            this.Name = name;
        }

        [Key]
        [Required]
        public Guid OccupationId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public virtual ICollection<WorkHistory> WorkHistories { get; set; }

        [NotMapped]
        public override string Id { get; set; }
    }
}
