using FinanceGoals.Domain.Entities;
using FinanceGoals.Domain.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceGoals.Application.Commands.Goals.Cancel
{
    public class CancelCommandHandler : IRequestHandler<CancelCommand, Result>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CancelCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(CancelCommand request, CancellationToken cancellationToken)
        {
            if (request.GuidGoal == Guid.Empty) { return Result.BadRequest("Guid não pode ser vazio."); }

            Goal? goal = await _unitOfWork.Goals.GetByIdAsync(request.GuidGoal);
            if (goal is null) { return Result.NotFound("Objetivo financeiro não encontrado."); }

            goal.Cancel();
            await _unitOfWork.CompleteAsync();

            return Result.Success("Objetivo financeiro cancelado.");
        }
    }
}
