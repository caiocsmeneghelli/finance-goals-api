using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceGoals.Application.Commands.Goals.Cancel
{
    public class CancelCommand : IRequest<Result>
    {
        public Guid GuidGoal { get; private set; }

        public CancelCommand(Guid guidGoal)
        {
            GuidGoal = guidGoal;
        }
    }
}
