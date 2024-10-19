using FinanceGoals.Domain.Entities;
using FinanceGoals.Domain.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceGoals.Application.Goals.CreateGoal
{
    public class CreateGoalCommandHandler : IRequestHandler<CreateGoalCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateGoalCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(CreateGoalCommand request, CancellationToken cancellationToken)
        {
            // Validate

            // AutoMapper
            Goal goal = new Goal(request.Title, request.TargetAmount,
                request.PlannedStart, request.PlannedEnd);

            await _unitOfWork.Goals.CreateAsync(goal);
            await _unitOfWork.CompleteAsync();

            // FIX
            return 1;
        }
    }
}
