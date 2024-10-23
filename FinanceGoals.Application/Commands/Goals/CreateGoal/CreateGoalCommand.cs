using Flunt.Notifications;
using MediatR;

namespace FinanceGoals.Application.Commands.Goals.CreateGoal
{
    public class CreateGoalCommand : Notifiable<Notification>,IRequest<Result>
    {
        public CreateGoalCommand(string title, decimal targetAmount, DateTime plannedStart, DateTime plannedEnd)
        {
            Title = title;
            TargetAmount = targetAmount;
            PlannedStart = plannedStart;
            PlannedEnd = plannedEnd;

            AddNotifications(new CreateGoalCommandNotification(this));
        }

        public string Title { get; set; }
        public decimal TargetAmount { get; set; }
        public DateTime PlannedStart { get; set; }
        public DateTime PlannedEnd { get; set; }
    }
}
