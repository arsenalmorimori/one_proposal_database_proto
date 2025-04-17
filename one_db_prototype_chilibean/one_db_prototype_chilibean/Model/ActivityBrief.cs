using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace one_db_prototype_chilibean.Model {
    [Table("activity_brief_tbl")]
    public class ActivityBrief {
        [Key]
        [ForeignKey("ActivityProfile")]
        [Column("activity_id")]
        public Guid activity_id { get; set; }

        [Required]
        [StringLength(150)]
        [Column("activity_brief_description")]
        public string activity_brief_description { get; set; }

        [Required]
        [Column("activity_date")]
        public DateTime activity_date { get; set; }

        public ActivityProfile ActivityProfile { get; set; }
    }
}
