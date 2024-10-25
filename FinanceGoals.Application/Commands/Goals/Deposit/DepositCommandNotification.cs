using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceGoals.Application.Commands.Goals.Deposit
{
    public class DepositCommandNotification : Contract<DepositCommand>
    {
        public DepositCommandNotification(DepositCommand request)
        {
            Requires()
                .IsNotNullOrEmpty(request.GoalGuid.ToString(), "GoalGuid", "Guid não pode ser vazio.")
                .IsGreaterThan(request.Amount, 0, "Amount", "Valor não pode ser 0 ou negativo.");
        }
    }
}
