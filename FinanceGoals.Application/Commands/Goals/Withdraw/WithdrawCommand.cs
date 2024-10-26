using Flunt.Notifications;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceGoals.Application.Commands.Goals.Withdraw
{
    public class WithdrawCommand : Notifiable<Notification>, IRequest<Result>
    {
        public WithdrawCommand(Guid goalGuid, decimal amount)
        {
            GoalGuid = goalGuid;
            Amount = amount;
        }

        public Guid GoalGuid { get; private set; }
        public decimal Amount { get; private set; }
        public decimal TotalAmount { get; private set; }

        public void AddTotalAmount(decimal amount) { TotalAmount = amount; }

        public void Validate()
        {
            AddNotifications(new WithdrawCommandNotification(this));
        }
    }
}
