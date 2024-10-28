using FinanceGoals.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceGoals.Application.Query.Goals.GetAllTransaction
{
    public class GetAllTransactionQuery : IRequest<Result>
    {
        public Guid GoalGuid { get; private set; }

        public GetAllTransactionQuery(Guid goalGuid)
        {
            GoalGuid = goalGuid;
        }
    }
}
