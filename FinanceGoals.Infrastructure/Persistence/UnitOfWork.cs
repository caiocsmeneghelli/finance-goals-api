using FinanceGoals.Domain.Repositories;
using FinanceGoals.Domain.UnitOfWork;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceGoals.Infrastructure.Persistence
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly FinanceDbContext _context;
        private IDbContextTransaction _transaction;

        public UnitOfWork(IGoalRepository goals, ITransactionRepository transactions, FinanceDbContext context)
        {
            Goals = goals;
            Transactions = transactions;
            _context = context;
        }

        public IGoalRepository Goals { get; }
        public ITransactionRepository Transactions {get;}

        public async Task BeginTransaction()
        {
            _transaction = await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitAsync()
        {
            try
            {
                await _transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                await _transaction.RollbackAsync();
                throw ex;
            }
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }

    }
}
