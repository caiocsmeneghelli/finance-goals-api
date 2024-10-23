using Flunt.Notifications;
using MediatR;

namespace FinanceGoals.Application.Commands.Goals.Deposit
{
    public class DepositCommand : Notifiable<Notification>, IRequest<Result>
    {
        public DepositCommand(Guid goalGuid, decimal amount)
        {
            GoalGuid = goalGuid;
            Amount = amount;

            AddNotifications(new DepositCommandNotification(this));
        }

        public Guid GoalGuid { get; private set; }
        public decimal Amount { get; private set; }
    }
}
