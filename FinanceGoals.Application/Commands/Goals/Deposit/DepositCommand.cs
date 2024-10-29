using Flunt.Notifications;
using MediatR;

namespace FinanceGoals.Application.Commands.Goals.Deposit
{
    public class DepositCommand : Notifiable<Notification>, IRequest<Result>
    {
        public Guid GoalGuid { get; set; }
        public decimal Amount { get; set; }

        public void Validate()
        {
            AddNotifications(new DepositCommandNotification(this));
        }
    }
}
