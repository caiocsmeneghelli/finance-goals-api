using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceGoals.Application.Commands.Goals.CreateGoal
{
    public class CreateGoalCommandNotification : Contract<CreateGoalCommand>
    {
        public CreateGoalCommandNotification(CreateGoalCommand request)
        {
            Requires()
                .IsGreaterThan(request.TargetAmount, 0, "TargetAmount", "Valor desejado precisa ser maior que zero.")
                .IsLowerOrEqualsThan(request.Title.Length, 128, "Title", "Tamanho do Título deve ser menor que 128 caracteres.")
                .IsNotNullOrEmpty(request.Title, "Title", "Título não pode ser vazio.");
        }
    }
}
