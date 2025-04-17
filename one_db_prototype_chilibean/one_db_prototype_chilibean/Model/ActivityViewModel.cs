namespace one_db_prototype_chilibean.Model {
    public class ActivityViewModel {
        public ActivityProfile Profile { get; set; }
        public ActivityBrief Brief { get; set; }
        public ActivityDetail Detail { get; set; }
        public Club Club { get; set; }
        public List<ActivityBudgetPlan> BudgetPlans { get; set; }
        public ActivityStatus Status { get; set; }
        public RemarksActivity Remarks { get; set; }
    }
}
