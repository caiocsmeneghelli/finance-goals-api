﻿using FinanceGoals.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceGoals.Domain.Entities
{
    public class Transaction : Entity
    {
        public Transaction(Guid goalGuid, TransactionType transactionType, decimal amount)
        {
            GoalGuid = goalGuid;
            TransactionType = transactionType;
            Amount = amount;
        }

        public Guid GoalGuid { get; private set; }
        public TransactionType TransactionType { get; private set; }
        public decimal Amount { get; private set; }
    }
}