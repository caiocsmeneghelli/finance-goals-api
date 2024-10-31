using FinanceGoals.Application;
using FinanceGoals.Application.Commands.Goals.Cancel;
using FinanceGoals.Application.Commands.Goals.CreateGoal;
using FinanceGoals.Application.Commands.Goals.Deposit;
using FinanceGoals.Application.Commands.Goals.Withdraw;
using FinanceGoals.Application.Query.Goals.GetAll;
using FinanceGoals.Application.Query.Goals.GetAllTransaction;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace FinanceGoals.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoalController : ControllerBase
    {
        private readonly IMediator _mediatr;

        public GoalController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }

        [HttpPost("")]
        public async Task<IActionResult> Create(CreateGoalCommand command)
        {
            // Alterar para Created
            var result = await _mediatr.Send(command);
            return Ok(result);
        }

        [HttpGet("")]
        public async Task<IActionResult> Get()
        {
            GetAllGoalsQuery query = new GetAllGoalsQuery();
            var result = await _mediatr.Send(query);

            return Ok(result);
        }

        [HttpPut("deposit/{guid}")]
        public async Task<IActionResult> Deposit(Guid guid, DepositCommand command)
        {
            command.GoalGuid = guid;
            Result result = await _mediatr.Send(command);
            if (!result.IsSuccess)
            {
                if (result.StatusCode == (int)HttpStatusCode.NotFound)
                {
                    return NotFound(result);
                }
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPut("withdraw/{guid}")]
        public async Task<IActionResult> Withdraw(Guid guid, WithdrawCommand command)
        {
            command.GoalGuid = guid;
            Result result = await _mediatr.Send(command);

            if (!result.IsSuccess)
            {
                if (result.StatusCode == (int)HttpStatusCode.NotFound)
                {
                    return NotFound(result);
                }
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpGet("transactions/{goalGuid}")]
        public async Task<IActionResult> ListTransaction(Guid goalGuid)
        {
            GetAllTransactionQuery query = new GetAllTransactionQuery(goalGuid);
            Result result = await _mediatr.Send(query);

            if (!result.IsSuccess)
            {
                return NotFound(result);
            }

            return Ok(result);
        }

        [HttpPut("cancel/{goalGuid}")]
        public async Task<IActionResult> Cancel(Guid goalGuid)
        {
            var command = new CancelCommand(goalGuid);
            Result result = await _mediatr.Send(command);

            if (!result.IsSuccess)
            {
                if (result.StatusCode == (int)HttpStatusCode.BadRequest) { return BadRequest(result); }
                if (result.StatusCode == (int)HttpStatusCode.NotFound) { return NotFound(result); }
            }

            return Ok(result);
        }
    }
}
