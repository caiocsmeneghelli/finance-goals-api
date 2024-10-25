using FinanceGoals.Domain.Entities;
using FinanceGoals.Domain.UnitOfWork;
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
        private readonly IUnitOfWork _unitOfWork;

        public DepositCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(DepositCommand request, CancellationToken cancellationToken)
        {
            // Validate
            if (!request.IsValid)
            {
                var notifications = request.Notifications;
                List<string> messages = notifications
                    .Select(reg => $"{reg.Key}: {reg.Message}").ToList();
                return Result.BadRequest(messages);
            }

            Goal? goal = await _unitOfWork.Goals.GetByIdAsync(request.GoalGuid);
            if(goal is null)
            {
                return Result.NotFound("O Objetivo Financeiro não foi encontrado.");
            }

            await _unitOfWork.BeginTransaction();
            
            goal.Deposit(request.Amount);
            await _unitOfWork.CompleteAsync();

            var transaction = new Transaction(request.GoalGuid, Domain.Enum.TransactionType.Deposit, request.Amount);
            await _unitOfWork.Transactions.CreateAsync(transaction);
            await _unitOfWork.CompleteAsync();

            await _unitOfWork.CommitAsync();

            return Result.Success();
        }
    }
}
