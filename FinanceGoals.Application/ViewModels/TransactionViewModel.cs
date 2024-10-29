using FinanceGoals.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceGoals.Application.ViewModels
{
    public class TransactionViewModel
    {
        public Guid Guid { get; private set; }
        public string TransactionType { get; private set; }
        public decimal Amount { get; private set; }
        public DateTime Date { get; private set; }
    }
}
