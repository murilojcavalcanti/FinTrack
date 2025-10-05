using FinTrack.Application.Services.Commands.BalanceCommands.CreateBalance;
using FinTrack.Application.Services.Commands.BalanceCommands.DeleteBalance;
using FinTrack.Application.Services.Commands.BalanceCommands.UpdateBalance;
using FinTrack.Application.Services.Queries.BalanceQueries.GetAllBalance;
using FinTrack.Application.Services.Queries.BalanceQueries.GetByIdBalance;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinTrack.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BalanceController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BalanceController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // POST: BalanceController/CreateReceive/
        [HttpPost("/CreateBalance")]
        public async Task<IActionResult> Create([FromBody] CreateBalanceCommand command)
        {
            try
            {
                var result = _mediator.Send(command);
                if (!result.Result.IsSuccess) return BadRequest(result.Result.Messsage);
                return Ok(result);
            }
            catch
            {
                throw;
            }
        }

        // GET: BalanceController/GetAll/
        [HttpGet("/GetAllBalance")]
        public async Task<IActionResult> GetAllBalance()
        {
            try
            {
                var query = new GetAllBalanceQuery();
                var result = await  _mediator.Send(query);
                if (!result.IsSuccess) return BadRequest(result.Messsage);
                return Ok(result);
            }
            catch
            {
                throw;
            }
        }

        // GET: BalanceController/GetById/
        [HttpGet("/GetByIdBalance")]
        public async Task<IActionResult> GetByIdBalance([FromBody] GetByIdBalanceQuery query)
        {
            try
            {
                var result = await _mediator.Send(query);
                if (!result.IsSuccess) return BadRequest(result.Messsage);
                return Ok(result);
            }
            catch
            {
                throw ;
            }
        }

        // PUT: BalanceController/Update/
        [HttpPut("/UpdateBalance")]
        public async Task<IActionResult> UpdateBalance([FromBody] UpdateBalanceCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                if (!result.IsSuccess) return BadRequest(result.Messsage);
                return Ok(result);
            }
            catch
            {
                throw;
            }
        }

        // GET: BalanceController/Delete
        [HttpDelete("/DeleteBalance")]
        public async Task<IActionResult> DeleteBalance([FromBody] DeleteBalanceCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                if (!result.IsSuccess) return BadRequest(result.Messsage);
                return Ok(result);
            }
            catch
            {
                throw;
            }
        }
    }
}
