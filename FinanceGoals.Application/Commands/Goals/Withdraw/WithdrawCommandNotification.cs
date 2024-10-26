using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceGoals.Application.Commands.Goals.Withdraw
{
    public class WithdrawCommandNotification : Contract<WithdrawCommand>
    {
        public WithdrawCommandNotification(WithdrawCommand request)
        {
            Requires()
                .IsNotNullOrEmpty(request.GoalGuid.ToString(), "GoalGuid", "Guid não pode ser vazio.")
                .IsGreaterThan(request.Amount, 0, "Amount", "Valor não pode ser 0 ou negativo.")
                .IsLowerOrEqualsThan(request.Amount, request.TotalAmount, "Amount", "O valor da transação deve ser menor que o valor que existe.");
        }
    }
}
