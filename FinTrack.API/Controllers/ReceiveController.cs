using FinTrack.Application.Services.Commands.ReceiveCommands.CreateReceive;
using FinTrack.Application.Services.Commands.ReceiveCommands.DeleteReceive;
using FinTrack.Application.Services.Commands.ReceiveCommands.UpdateReceive;
using FinTrack.Application.Services.Queries.ReceiveQueries.GetAll;
using FinTrack.Application.Services.Queries.ReceiveQueries.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinTrack.API.Controllers
{

    [Route("Api/[controller]")]
    [ApiController]
    public class ReceiveController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReceiveController(IMediator mediator)
        {
            _mediator = mediator;
        }


        // POST: ReceiveController/CreateReceive/
        [HttpPost("/CreateReceive")]
        public async Task<IActionResult> Create([FromBody]CreateReceiveCommand command)
        {
            try
            {
                var result = _mediator.Send(command);
                if (!result.Result.IsSuccess) return BadRequest(result.Result.Messsage);
                return Ok(result.Result);
            }
            catch
            {
                throw;
            }
        }
        
        // GET: ReceiveController/GetAll/
        [HttpGet("/GetAllReceive")]
        public async Task<IActionResult> GetAllReceives()
        {
            try
            {
                var query = new GetAllReceiveQuery();
                var result = await _mediator.Send(query);
                if (!result.IsSuccess) return BadRequest(result.Messsage);
                return Ok(result.Data);
            }
            catch
            {
                throw;
            }
        }
        
        // GET: ReceiveController/GetById/
        [HttpGet("/GetByIdReceive")]
        public async Task<IActionResult> GetByIdReceives([FromBody] GetByIdReceiveQuery query)
        {
            try
            {
                var result = await _mediator.Send(query);
                if (!result.IsSuccess) return BadRequest(result.Messsage);
                return Ok(result.Data);
            }
            catch
            {
                throw;
            }
        }

        // PUT: ReceiveController/Update/
        [HttpPut("/UpdateReceive")]
        public async Task<IActionResult> UpdateReceive([FromBody] UpdateReceiveCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                if (!result.IsSuccess) return BadRequest(result.Messsage);
                return Ok(result.IsSuccess);
            }
            catch
            {
                throw;
            }
        }

        // GET: ReceiveController/Delete
        [HttpDelete("/DeleteReceive")]
        public async Task<IActionResult> DeleteReceive([FromBody] DeleteReceiveCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                if (!result.IsSuccess) return BadRequest(result.Messsage);
                return Ok(result.IsSuccess);
            }
            catch
            {
                throw;
            }
        }
    }
}
