using FinanceGoals.Domain.Entities;
using FinanceGoals.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceGoals.Infrastructure.Persistence.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly FinanceDbContext _context;

        public TransactionRepository(FinanceDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Transaction goal)
        {
            await _context.Transactions.AddAsync(goal);
        }

        public async Task<List<Transaction>> GetAllAsync()
        {
            return await _context.Transactions.ToListAsync();
        }

        public async Task<Transaction?> GetByGuidAsync(Guid guid)
        {
            return await _context.Transactions
                .SingleOrDefaultAsync(reg => reg.Guid == guid);
        }
    }
}
