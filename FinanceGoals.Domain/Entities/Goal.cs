﻿using FinanceGoals.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceGoals.Domain.Entities
{
    public class Goal : Entity
    {
        public Goal(string title, decimal targetAmount, DateTime plannedStart, DateTime plannedEnd)
        {
            Title = title;
            TargetAmount = targetAmount;
            PlannedStart = plannedStart;
            PlannedEnd = plannedEnd;
            Status = GoalStatus.OnHold;
            Transactions = new List<Transaction>();
        }

        public string Title { get; private set; }
        
        [Column(TypeName = "decimal(18, 2)")]
        public decimal TargetAmount { get; private set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal TotalAmount { get; private set; }
        public DateTime PlannedStart { get; private set; }
        public DateTime? StartedAt { get; private set; }
        public DateTime PlannedEnd { get; private set; }
        public DateTime? EndedAt { get; private set; }
        public GoalStatus Status { get; private set; }
        public List<Transaction> Transactions { get; private set; }

        public void Deposit(decimal amount)
        {
            if (Status == GoalStatus.OnHold)
            {
                Status = GoalStatus.InProgress;
                StartedAt = DateTime.UtcNow;
            }

            TotalAmount += amount;

            if (TotalAmount >= TargetAmount)
            {
                Status = GoalStatus.Completed;
                EndedAt = DateTime.UtcNow;
            }
        }

        public void Cancel()
        {
            Status = GoalStatus.Cancelled;
        }

        public void WithDraw(decimal amount)
        {
            TotalAmount -= amount;
        }
    }
}
