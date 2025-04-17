using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace one_db_prototype_chilibean.Model {
    [Table("remarks_activity_tbl")]
    public class RemarksActivity {
        [Key]
        [ForeignKey("ActivityProfile")]
        [Column("activity_id")]
        public Guid activity_id { get; set; }

        [StringLength(1000)]
        [Column("activity_title_remark")]
        public string activity_title_remark { get; set; }

        [StringLength(1000)]
        [Column("activity_brief_description_remark")]
        public string activity_brief_description_remark { get; set; }

        [StringLength(1000)]
        [Column("rationale_remark")]
        public string rationale_remark { get; set; }

        [StringLength(1000)]
        [Column("objectives_remark")]
        public string objectives_remark { get; set; }

        [StringLength(1000)]
        [Column("activity_type_remark")]
        public string activity_type_remark { get; set; }

        [StringLength(1000)]
        [Column("activity_date_remark")]
        public string activity_date_remark { get; set; }

        [StringLength(1000)]
        [Column("activity_reach_remark")]
        public string activity_reach_remark { get; set; }

        [StringLength(1000)]
        [Column("activity_budget_remark")]
        public string activity_budget_remark { get; set; }

        public ActivityProfile ActivityProfile { get; set; }
    }
}
