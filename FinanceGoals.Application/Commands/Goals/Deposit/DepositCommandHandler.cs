using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceGoals.Application.Commands.Goals.Deposit
{
    public class DepositCommandHandler : IRequestHandler<DepositCommand, Result>
    {
        public Task<Result> Handle(DepositCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
