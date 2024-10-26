using FinanceGoals.Application;
using FinanceGoals.Application.Commands.Goals.CreateGoal;
using FinanceGoals.Application.Commands.Goals.Deposit;
using FinanceGoals.Application.Commands.Goals.Withdraw;
using FinanceGoals.Application.Query.Goals.GetAll;
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
            var result = await _mediatr.Send(command);
            return Created();
        }

        [HttpGet("")]
        public async Task<IActionResult> Get()
        {
            GetAllGoalsQuery query = new GetAllGoalsQuery();
            var result = await _mediatr.Send(query);

            return Ok(result);
        }

        [HttpPut("deposit/{guid}")]
        public async Task<IActionResult> Deposit(Guid guid, [FromBody]decimal amount)
        {
            DepositCommand command = new DepositCommand(guid, amount);
            Result result = await _mediatr.Send(command);
            if (!result.IsSuccess)
            {
                if(result.StatusCode == (int)HttpStatusCode.NotFound)
                {
                    return NotFound(result.Messages);
                }
                return BadRequest(result.Messages);
            }

            return Ok(result);
        }

        [HttpPut("withdraw/{guid}")]
        public async Task<IActionResult> Withdraw(Guid guid, [FromBody]decimal amount)
        {
            WithdrawCommand command = new WithdrawCommand(guid, amount);
            Result result = await _mediatr.Send(command);

            if (!result.IsSuccess)
            {
                if (result.StatusCode == (int)HttpStatusCode.NotFound)
                {
                    return NotFound(result.Messages);
                }
                return BadRequest(result.Messages);
            }

            return Ok(result);
        }
    }
}
