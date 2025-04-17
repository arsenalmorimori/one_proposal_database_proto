using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace one_db_prototype_chilibean.Model {
        [Table("activity_detail_tbl")]
        public class ActivityDetail {
            [Key]
            [ForeignKey("ActivityProfile")]
            [Column("activity_id")]
            public string activity_id { get; set; }

            [Required]
            [StringLength(5000)]
            [Column("activity_rationale")]
            public string activity_rationale { get; set; }

            [Required]
            [StringLength(5000)]
            [Column("activity_objectives")]
            public string activity_objectives { get; set; }

            [Required]
            [StringLength(500)]
            [Column("activity_activity_type")]
            public string activity_activity_type { get; set; }

            [Required]
            [StringLength(500)]
            [Column("activity_activity_reach")]
            public string activity_activity_reach { get; set; }

            public ActivityProfile ActivityProfile { get; set; }
        }

}
