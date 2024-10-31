using FinanceGoals.Application.Commands.Goals.Deposit;
using FinanceGoals.Application.Commands.Goals.Withdraw;
using FinanceGoals.Domain.Entities;
using FinanceGoals.Domain.Repositories;
using FinanceGoals.Domain.UnitOfWork;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceGoals.Tests.Goals
{
    public class WithdrawGoalTest
    {
        private readonly IUnitOfWork _unitOfWork;

        public WithdrawGoalTest()
        {
            var goalRepositoryMock = Substitute.For<IGoalRepository>();
            var transactionRepositoryMock = Substitute.For<ITransactionRepository>();
            _unitOfWork = Substitute.For<IUnitOfWork>();

            _unitOfWork.Goals.Returns(goalRepositoryMock);
            _unitOfWork.Transactions.Returns(transactionRepositoryMock);
        }

        [Fact]
        public async void HandlerShouldReturnSuccess()
        {
            // Arrange
            var goal = new Goal("Kawasaki Ninja 400", 34000m, new DateTime(2024, 11, 01), new DateTime(2026, 11, 01));
            goal.Deposit(4000);
            _unitOfWork
                .Goals
                .GetByIdAsync(Arg.Any<Guid>())
                .Returns(Task.FromResult<Goal?>(goal));

            // Act
            var command = new WithdrawCommand() { GoalGuid = new Guid(), Amount = 320m };
            var handler = new WithdrawCommandHandler(_unitOfWork);

            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact]
        public async void HandlerShouldReturnFalseWhenWithdrawAmountGreaterThanTotalAmount()
        {
            // Arrange
            var goal = new Goal("Kawasaki Ninja 400", 34000m, new DateTime(2024, 11, 01), new DateTime(2026, 11, 01));
            goal.Deposit(300);
            _unitOfWork
                .Goals
                .GetByIdAsync(Arg.Any<Guid>())
                .Returns(Task.FromResult<Goal?>(goal));

            // Act
            var command = new WithdrawCommand() { GoalGuid = new Guid(), Amount = 320m };
            var handler = new WithdrawCommandHandler(_unitOfWork);

            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.False(result.IsSuccess);
        }
    }
}
