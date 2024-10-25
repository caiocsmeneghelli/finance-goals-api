using FinanceGoals.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceGoals.Infrastructure.Persistence
{
    public class FinanceDbContext : DbContext
    {
        public DbSet<Goal> Goals { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        public FinanceDbContext(DbContextOptions<FinanceDbContext> options) : base(options)
        { }
    }
}
