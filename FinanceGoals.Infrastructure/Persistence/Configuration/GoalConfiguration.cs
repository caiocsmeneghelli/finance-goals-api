using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinanceGoals.Domain.Entities;

namespace FinanceGoals.Infrastructure.Persistence.Configuration
{
    public class GoalConfiguration : IEntityTypeConfiguration<Goal>
    {
        public void Configure(EntityTypeBuilder<Goal> builder)
        {
            builder.HasKey(b => b.Guid);

            builder.HasMany(b => b.Transactions)
                .WithOne(r => r.Goal)
                .HasForeignKey(b => b.GoalGuid)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
