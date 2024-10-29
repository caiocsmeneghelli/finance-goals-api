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
        public Guid GoalGuid { get; set; }
        public decimal Amount { get; set; }
        public decimal TotalAmount { get; private set; }

        public void AddTotalAmount(decimal amount) { TotalAmount = amount; }

        public void Validate()
        {
            AddNotifications(new WithdrawCommandNotification(this));
        }
    }
}
