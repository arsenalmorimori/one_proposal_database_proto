
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace one_db_prototype_chilibean.Model {
    [Table("activity_status_tbl")]
    public class ActivityStatus {
        [Key]
        [ForeignKey("ActivityProfile")]
        [Column("activity_id")]
        public Guid activity_id { get; set; }

        [Required]
        [StringLength(50)]
        [Column("activity_overall_status")]
        public string activity_overall_status { get; set; } = "pending";

        [Required]
        [StringLength(50)]
        [Column("admin_1_status")]
        public string admin_1_status { get; set; } = "pending";

        [Required]
        [StringLength(50)]
        [Column("admin_2_status")]
        public string admin_2_status { get; set; } = "pending";

        [Required]
        [StringLength(50)]
        [Column("admin_3_status")]
        public string admin_3_status { get; set; } = "pending";

        [Required]
        [Column("checked_date")]
        public DateTime checked_date { get; set; }

        public ActivityProfile ActivityProfile { get; set; }
    }
}
