﻿using FinanceGoals.Application.Commands.Goals.CreateGoal;
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
    public class CreateGoalTest
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateGoalTest()
        {
            var goalRepositoryMock = Substitute.For<IGoalRepository>();
            _unitOfWork = Substitute.For<IUnitOfWork>();
            _unitOfWork.Goals.Returns(goalRepositoryMock);
        }

        /// <summary>
        /// Test if command is valid, should return Result.Success = true
        /// </summary>

        [Fact]
        public async void HandlerShouldReturnSucces()
        {
            // Arrange
            _unitOfWork
                .Goals
                .GetByIdAsync(Arg.Any<Guid>())
                .GetAwaiter();

            // Act
            var command = new CreateGoalCommand()
            {
                Title = "Kawasaki Ninja 400",
                PlannedStart = new DateTime(2024, 11, 01),
                PlannedEnd = new DateTime(2026, 11, 01),
                TargetAmount = 34.000m
            };

            var handler = new CreateGoalCommandHandler(_unitOfWork);
            var result = await handler.Handle(command, CancellationToken.None);


            // Assert
            Assert.True(result.IsSuccess);
        }
    }
}