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
    public class GoalRepository : IGoalRepository
    {
        private readonly FinanceDbContext _context;

        public GoalRepository(FinanceDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Goal goal)
        {
            await _context.Goals.AddAsync(goal);
        }

        public async Task<List<Goal>> GetAllAsync()
        {
            return await _context.Goals.ToListAsync();
        }

        public async Task<Goal?> GetByIdAsync(Guid guid)
        {
            return await _context.Goals
                .SingleOrDefaultAsync(reg => reg.Guid == guid);
        }
    }
}
