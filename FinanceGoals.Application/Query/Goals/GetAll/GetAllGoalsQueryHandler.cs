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
    public class GetAllGoalsQueryHandler : IRequestHandler<GetAllGoalsQuery, List<Goal>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllGoalsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<List<Goal>> Handle(GetAllGoalsQuery request, CancellationToken cancellationToken)
        {
            return _unitOfWork.Goals.GetAllAsync();
        }
    }
}
