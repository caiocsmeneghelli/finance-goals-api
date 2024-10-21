using Flunt.Notifications;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceGoals.Application.Commands.Goals.CreateGoal
{
    public class CreateGoalCommand : IRequest<Result>, Notifiable<Notification>
    {
        public CreateGoalCommand()
        {
            AddNotifications(new Notification(this));
        }

        public string Title { get; set; }
        public decimal TargetAmount { get; set; }
        public DateTime PlannedStart { get; set; }
        public DateTime PlannedEnd { get; set; }
    }
}
