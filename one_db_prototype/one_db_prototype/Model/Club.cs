using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace one_db_prototype.Model {
    [Table("club_main_tbl")]  // Explicit table name mapping
    public class Club {
        [Key]
        [Column("club_id")]  // Must match your MySQL column name exactly
        public int club_id { get; set; }

        [Column("club_name")]
        public string club_name { get; set; }
    }
}
