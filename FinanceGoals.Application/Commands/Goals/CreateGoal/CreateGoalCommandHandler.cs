using FinanceGoals.Application.Commands.Goals.CreateGoal;
using FinanceGoals.Domain.Entities;
using FinanceGoals.Domain.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceGoals.Application.Commands.Goals.CreateGoal
{
    public class CreateGoalCommandHandler : IRequestHandler<CreateGoalCommand, Result>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateGoalCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(CreateGoalCommand request, CancellationToken cancellationToken)
        {
            // Validate
            if (!request.IsValid)
            {
                var notifications = request.Notifications;
                List<string> messages = notifications
                    .Select(reg => $"{reg.Key}: {reg.Message}").ToList();
                return Result.BadRequest(messages);
            }

            // AutoMapper
            Goal goal = new Goal(request.Title, request.TargetAmount,
                request.PlannedStart, request.PlannedEnd);

            await _unitOfWork.Goals.CreateAsync(goal);
            await _unitOfWork.CompleteAsync();

            return Result.Success();
        }
    }
}
