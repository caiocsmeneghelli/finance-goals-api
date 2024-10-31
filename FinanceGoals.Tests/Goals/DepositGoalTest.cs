using FinanceGoals.Application.Commands.Goals.Deposit;
using FinanceGoals.Domain.Entities;
using FinanceGoals.Domain.Repositories;
using FinanceGoals.Domain.UnitOfWork;
using NSubstitute;

namespace FinanceGoals.Tests.Goals
{
    public class DepositGoalTest
    {
        private readonly IUnitOfWork _unitOfWork;

        public DepositGoalTest()
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
            _unitOfWork
                .Goals
                .GetByIdAsync(Arg.Any<Guid>())
                .Returns(Task.FromResult<Goal?>(goal));

            // Act
            var command = new DepositCommand();
            command.GoalGuid = new Guid();
            command.Amount = 320m;
            var handler = new DepositCommandHandler(_unitOfWork);

            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact]
        public async void HandlerShouldReturnFailWhenGoalNotFound()
        {
            // Arrange
            _unitOfWork
                .Goals
                .GetByIdAsync(Arg.Any<Guid>())
                .GetAwaiter();

            // Act
            var command = new DepositCommand() { GoalGuid = new Guid(), Amount = 320m };
            var handler = new DepositCommandHandler(_unitOfWork);

            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.Equal(404, result.StatusCode);
        }

        [Fact]
        public async void HandlerShouldReturnFailWhenDepositAmountIsNegative()
        {
            // Arrange
            var goal = new Goal("Kawasaki Ninja 400", 34000m, new DateTime(2024, 11, 01), new DateTime(2026, 11, 01));
            _unitOfWork
                .Goals
                .GetByIdAsync(Arg.Any<Guid>())
                .Returns(Task.FromResult<Goal?>(goal));

            // Act
            var command = new DepositCommand() { GoalGuid = new Guid(), Amount = -320m };
            var handler = new DepositCommandHandler(_unitOfWork);

            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.Equal(400, result.StatusCode);
        }
    }
}
