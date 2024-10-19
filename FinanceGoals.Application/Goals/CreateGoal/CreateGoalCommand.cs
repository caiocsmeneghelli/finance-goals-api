using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceGoals.Application.Goals.CreateGoal
{
    public class CreateGoalCommand : IRequest<int>
    {
        public string Title { get; set; }
        public decimal TargetAmount { get; set; }
        public DateTime PlannedStart { get; set; }
        public DateTime PlannedEnd { get; set; }
    }
}
