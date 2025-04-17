using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace one_db_prototype_r2.Model {
    [Table("activity_profile_tbl")]
    public class ActivityProfile {
        [Key]
        [Column("activity_id")]
        public char activity_id { get; set; }
        [Column("club_id")]

        public int club_id { get; set; }
        [Column("activity_title")]

        public string activity_title { get; set; }
        [Column("activity_date")]

        public DateTime activity_date  { get; set; }
    }
}
