using System.ComponentModel.DataAnnotations;

namespace one_db_prototype.Model {
    public class Club {
        [Key]
        public int club_id { get; set; }
        public int club_name { get; set; }
    }
}
