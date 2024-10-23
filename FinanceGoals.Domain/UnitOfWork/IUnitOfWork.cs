using FinanceGoals.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceGoals.Domain.UnitOfWork
{
    public interface IUnitOfWork
    {
        IGoalRepository Goals { get; }
        ITransactionRepository Transactions { get; }

        Task<int> CompleteAsync();
        Task BeginTransaction();
        Task CommitAsync();
    }
}
