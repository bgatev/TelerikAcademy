namespace WolfRaider.Common.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using MongoRepository;

    [Table("SquadHistory")]
    public partial class SquadHistory : Entity
    {
        public SquadHistory()
            : this(Guid.NewGuid(), null, null, null, null, null, null)
        {
        }

        public SquadHistory(int goals, int redCards, int yellowCards)
            : this(Guid.NewGuid(), null, goals, redCards, yellowCards, null, null)
        {
        }

        public SquadHistory(Guid squadHistoryId, Guid? empoyeeId, int? goals, int? redCards, int? yellowCards, Guid? gameId, Guid? positionId)
        {
            this.SquadHistoryId = squadHistoryId;
            this.EmpoyeeId = empoyeeId;
            this.Goals = goals;
            this.RedCards = redCards;
            this.YellowCards = yellowCards;
            this.GameId = gameId;
            this.PositionId = positionId;
        }

        [Key]
        [Required]
        public Guid SquadHistoryId { get; set; }

        [ForeignKey("Employee")]
        [Required]
        public Guid? EmpoyeeId { get; set; }

        public virtual Employee Employee { get; set; }

        [Required]
        public int? Goals { get; set; }

        [Required]
        public int? RedCards { get; set; }

        [Required]
        public int? YellowCards { get; set; }

        [ForeignKey("Game")]
        [Required]
        public Guid? GameId { get; set; }

        public virtual Game Game { get; set; }

        [ForeignKey("Position")]
        [Required]
        public Guid? PositionId { get; set; }

        public virtual Position Position { get; set; }

        [NotMapped]
        public override string Id { get; set; }
    }
}
