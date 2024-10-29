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

namespace FinanceGoals.Application.Query.Goals.GetAll
{
    public class GetAllGoalsQueryHandler : IRequestHandler<GetAllGoalsQuery, Result>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllGoalsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result> Handle(GetAllGoalsQuery request, CancellationToken cancellationToken)
        {
            List<Goal> result = await _unitOfWork.Goals.GetAllAsync();
            List<GoalViewModel> listVw = _mapper.Map<List<Goal>, List<GoalViewModel>>(result);

            return Result.Success(listVw);
        }
    }
}
