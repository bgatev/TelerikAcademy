namespace WolfRaider.Common.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using MongoRepository;

    [Table("WorkHistory")]
    public partial class WorkHistory : Entity
    {
        public WorkHistory()
            : this(Guid.NewGuid(), null, null, null, null, null, null)
        {
        }

        public WorkHistory(DateTime startDate, DateTime? endDate, decimal salary)
            : this(Guid.NewGuid(), startDate, endDate, salary, null, null, null)
        {
        }

        public WorkHistory(Guid workHistoryId, DateTime? startDateTime, DateTime? endDateTime, decimal? salary, Guid? employeeId, Guid? teamId, Guid? occupationId)
        {
            this.WorkHistoryId = workHistoryId;
            this.StartDate = startDateTime;
            this.EndDate = endDateTime;
            this.Salary = salary;
            this.EmployeeId = employeeId;
            this.TeamId = teamId;
            this.OccupationId = occupationId;
        }

        [Key]
        [Required]
        public Guid WorkHistoryId { get; set; }

        [ForeignKey("Employee")]
        [Required]
        public Guid? EmployeeId { get; set; }

        public virtual Employee Employee { get; set; }

        [ForeignKey("Team")]
        [Required]
        public Guid? TeamId { get; set; }

        public virtual Team Team { get; set; }

        [Column(TypeName = "date")]
        [Required]
        public DateTime? StartDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? EndDate { get; set; }

        [Required]
        public decimal? Salary { get; set; }

        [ForeignKey("Occupation")]
        [Required]
        public Guid? OccupationId { get; set; }

        public virtual Occupation Occupation { get; set; }

        [NotMapped]
        public override string Id { get; set; }
    }
}
