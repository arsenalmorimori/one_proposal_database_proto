using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace one_db_prototype_chilibean.Model {
    [Table("club_main_tbl")]
    public class Club {
        [Key]
        [Column("club_id")]
        public int club_id { get; set; }

        [StringLength(50)]
        [Column("club_name")]
        public string? club_name { get; set; }  // Note the ?

        public ICollection<ActivityProfile> ActivityProfiles { get; set; }
    }


}
