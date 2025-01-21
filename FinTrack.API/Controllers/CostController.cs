


using FinTrack.Application.Services.Commands.CreateCost;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

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
            return Ok();
        }
        [HttpGet("/GetById")]
        public async Task<IActionResult> GetByIdCost()
        {
            return Ok();
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
        public async Task<IActionResult> UpdateCost()
        {
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteCost()
        {
            return Ok();
        }
    }
}
