using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace one_db_prototype_r2.Model {
    [Table("club_main_tbl")]
    public class Club {
        [Key]
        [Column("club_id")]
        public int club_id { get; set; }
        [Column("club_name")]

        public string club_name { get; set; }
    }
}
