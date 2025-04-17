using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace one_db_prototype_chilibean.Model {

    [Table("activity_profile_tbl")]
    public class ActivityProfile {
        [Key]
        [Column("activity_id")]
        public string activity_id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [Column("club_id")]
        public int club_id { get; set; }

        [Required]
        [StringLength(150)]
        [Column("activity_title")]
        public string activity_title { get; set; }

        [Required]
        [Column("activity_date")]
        public DateTime activity_date { get; set; }

        [Required]
        [StringLength(50)]
        [Column("club_name")]
        public string club_name { get; set; }

        [ForeignKey("club_id")]
        public Club Club { get; set; }

        public ActivityBrief ActivityBrief { get; set; }
        public ActivityDetail ActivityDetail { get; set; }
        public ActivityStatus ActivityStatus { get; set; }
        public RemarksActivity RemarksActivity { get; set; }
        public ICollection<ActivityBudgetPlan> ActivityBudgetPlans { get; set; }
    }

}
