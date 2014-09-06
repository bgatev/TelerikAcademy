namespace WolfRaider.Common.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using MongoRepository;

    public partial class Team : Entity
    {
        public Team()
            : this(Guid.NewGuid(), null, null)
        {
        }

        public Team(string name)
            : this(Guid.NewGuid(), name, null)
        {
        }

        public Team(Guid teamId, string name, Guid? nationalityId)
        {
            this.TeamId = teamId;
            this.Name = name;
            this.NationalityId = nationalityId;

            this.HomeGames = new HashSet<Game>();
            this.AwayGames = new HashSet<Game>();
            this.WorkHistories = new HashSet<WorkHistory>();
        }

        [Key]
        [Required]
        public Guid TeamId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [ForeignKey("Nationality")]
        [Required]
        public Guid? NationalityId { get; set; }

        public virtual Nationality Nationality { get; set; }

        public virtual ICollection<Game> HomeGames { get; set; }

        public virtual ICollection<Game> AwayGames { get; set; }

        public virtual ICollection<WorkHistory> WorkHistories { get; set; }

        [NotMapped]
        public override string Id { get; set; }
    }
}
