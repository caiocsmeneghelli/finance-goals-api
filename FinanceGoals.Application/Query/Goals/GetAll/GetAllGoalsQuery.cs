using FinanceGoals.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceGoals.Application.Query.Goals.GetAll
{
    public class GetAllGoalsQuery : IRequest<Result>
    {
    }
}
