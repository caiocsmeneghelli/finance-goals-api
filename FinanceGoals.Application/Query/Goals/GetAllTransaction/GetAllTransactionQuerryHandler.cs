using FinanceGoals.Domain.Entities;
using FinanceGoals.Domain.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceGoals.Application.Query.Goals.GetAllTransaction
{
    public class GetAllTransactionQuerryHandler : IRequestHandler<GetAllTransactionQuery, Result>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllTransactionQuerryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(GetAllTransactionQuery request, CancellationToken cancellationToken)
        {
            var goal = await _unitOfWork.Goals.GetByIdAsync(request.GoalGuid);
            if(goal is null)
            {
                return Result.NotFound("Objetivo Financeiro não encontrado.");
            }

            return Result.Success(goal.Transactions);
        }
    }
}
