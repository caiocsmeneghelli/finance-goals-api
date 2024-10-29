using AutoMapper;
using FinanceGoals.Application.ViewModels;
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
        private readonly IMapper _mapper;

        public GetAllTransactionQuerryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result> Handle(GetAllTransactionQuery request, CancellationToken cancellationToken)
        {
            var goal = await _unitOfWork.Goals.GetByIdAsync(request.GoalGuid);
            if(goal is null)
            {
                return Result.NotFound("Objetivo Financeiro não encontrado.");
            }

            List<TransactionViewModel> result = _mapper.Map<List<Transaction>, List<TransactionViewModel>>(goal.Transactions);

            return Result.Success(result);
        }
    }
}
