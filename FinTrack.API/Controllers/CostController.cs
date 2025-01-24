using FinTrack.Application.Services.Commands.CostCommands.CreateCost;
using FinTrack.Application.Services.Commands.CostCommands.DeleteCost;
using FinTrack.Application.Services.Commands.CostCommands.UpdateCost;
using FinTrack.Application.Services.Queries.CostQueries.GetAll;
using FinTrack.Application.Services.Queries.CostQueries.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinTrack.API.Controllers
{
    [Route("Api/Cost")]
    [ApiController]

    public class CostController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CostController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCost(CreateCostCommand command)
        {
            var result = await _mediator.Send(command);
            if (!result.IsSuccess) return BadRequest(result.Messsage);

            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCost()
        {
            var query = new GetAllCostQuery();
            var result = await _mediator.Send(query);

            return Ok(result);
        }
        [HttpGet("/GetById")]
        public async Task<IActionResult> GetByIdCost(GetByIdCostQuery query)
        {
            var result = _mediator.Send(query);
            return Ok(result);
        }
        [HttpGet("/GetByDate")]
        public async Task<IActionResult> GetByDateCost()
        {
            return Ok();
        }
        [HttpGet("/GetByDescription")]
        public async Task<IActionResult> GetByDescritionCost()
        {
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCost(UpdateCostCommand  command)
        {
            var result = await _mediator.Send(command);
            if (!result.IsSuccess) return BadRequest(result.Messsage);
            return Ok(result);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteCost(DeleteCostCommand command)
        {
            var result = await _mediator.Send(command);
            if (!result.IsSuccess) return BadRequest(result.Messsage);
            return Ok(result);
        }
    }
}
