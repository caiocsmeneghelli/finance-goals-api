namespace FinanceGoals.Application.ViewModels
{
    public class GoalViewModel
    {
        public Guid Guid { get; private set; }
        public string Title { get; private set; }
        public decimal TargetAmount { get; private set; }
        public decimal TotalAmount { get; private set; }
        public DateTime PlannedStart { get; private set; }
        public DateTime? StartedAt { get; private set; }
        public DateTime PlannedEnd { get; private set; }
        public DateTime? EndedAt { get; private set; }
        public string Status { get; private set; }
    }
}