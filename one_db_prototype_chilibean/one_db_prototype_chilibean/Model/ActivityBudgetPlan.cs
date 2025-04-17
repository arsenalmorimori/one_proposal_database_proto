using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace one_db_prototype_chilibean.Model {
    [Table("activity_budget_plan_tbl")]
    public class ActivityBudgetPlan {
        [Key]
        [Column("budget_plan_id")]
        public int budget_plan_id { get; set; }

        [Required]
        [ForeignKey("ActivityProfile")]
        [Column("activity_id")]
        public string activity_id { get; set; }

        [Required]
        [StringLength(100)]
        [Column("item_name")]
        public string item_name { get; set; }

        [Required]
        [Column("price")]
        public decimal price { get; set; }

        [Required]
        [Column("quantity")]
        public int quantity { get; set; }

        public ActivityProfile ActivityProfile { get; set; }
    }

}
