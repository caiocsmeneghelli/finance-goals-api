using FinanceGoals.Domain.Entities;
using FinanceGoals.Domain.Enum;
using FinanceGoals.Domain.UnitOfWork;
using MediatR;

namespace FinanceGoals.Application.Commands.Goals.Withdraw
{
    public class WithdrawCommandHandler : IRequestHandler<WithdrawCommand, Result>
    {
        private readonly IUnitOfWork _unitOfWork;

        public WithdrawCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(WithdrawCommand request, CancellationToken cancellationToken)
        {
            var goal = await _unitOfWork.Goals.GetByIdAsync(request.GoalGuid);
            if(goal is null)
            {
                return Result.NotFound("Objetivo financeiro não encontrado.");
            }

            request.AddTotalAmount(goal.TotalAmount);
            request.Validate();
            if (!request.IsValid)
            {
                var notifications = request.Notifications;
                List<string> messages = notifications
                    .Select(reg => $"{reg.Key}: {reg.Message}").ToList();
                return Result.BadRequest(messages);
            }

            var transaction = new Transaction(goal.Guid, TransactionType.WithDraw, request.Amount);

            await _unitOfWork.BeginTransaction();

            goal.WithDraw(request.Amount);
            await _unitOfWork.CompleteAsync();

            await _unitOfWork.Transactions.CreateAsync(transaction);
            await _unitOfWork.CompleteAsync();

            await _unitOfWork.CommitAsync();

            return Result.Success();
        }
    }
}
