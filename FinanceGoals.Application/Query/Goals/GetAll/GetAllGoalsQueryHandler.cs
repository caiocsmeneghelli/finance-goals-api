using FinanceGoals.Domain.Entities;
using FinanceGoals.Domain.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceGoals.Application.Query.Goals.GetAll
{
    public class GetAllGoalsQueryHandler : IRequestHandler<GetAllGoalsQuery, Result>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllGoalsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(GetAllGoalsQuery request, CancellationToken cancellationToken)
        {
            List<Goal> result = await _unitOfWork.Goals.GetAllAsync();
            return Result.Success(result);
        }
    }
}
