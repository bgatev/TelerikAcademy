namespace WolfRaider.Common.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using MongoRepository;

    public partial class Game : Entity
    {
        public Game()
            : this(Guid.NewGuid(), null, null, null)
        {
        }

        public Game(DateTime playedOn)
            : this(Guid.NewGuid(), null, null, playedOn)
        {
        }

        public Game(Guid gameId, Guid? homeTeamId, Guid? guestTeamId, DateTime? playedOn)
        {
            this.GameId = gameId;
            this.HomeTeamId = homeTeamId;
            this.GuestTeamId = guestTeamId;
            this.PlayedOn = playedOn;
            this.SquadHistories = new HashSet<SquadHistory>();
        }

        [Key]
        public Guid GameId { get; set; }

        [ForeignKey("HomeTeam")]
        [Required]
        public Guid? HomeTeamId { get; set; }

        [ForeignKey("GuestTeam")]
        [Required]
        public Guid? GuestTeamId { get; set; }

        public virtual Team HomeTeam { get; set; }

        public virtual Team GuestTeam { get; set; }

        [Required]
        public DateTime? PlayedOn { get; set; }

        public virtual ICollection<SquadHistory> SquadHistories { get; set; }

        [NotMapped]
        public override string Id { get; set; }
    }
}
