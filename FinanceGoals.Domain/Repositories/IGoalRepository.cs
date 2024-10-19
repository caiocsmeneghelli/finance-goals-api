using FinanceGoals.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceGoals.Domain.Repositories
{
    public interface IGoalRepository
    {
        Task CreateAsync(Goal goal);
    }
}
