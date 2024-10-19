using FinanceGoals.Application.Commands.Goals.CreateGoal;
using FinanceGoals.Application.Query.Goals.GetAll;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
    }
}
