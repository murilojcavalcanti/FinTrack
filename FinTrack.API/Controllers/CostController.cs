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


        // POST: CostController/Create/
        [HttpPost]
        public async Task<IActionResult> CreateCost(CreateCostCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                if (!result.IsSuccess) return BadRequest(result.Messsage);
                return Ok(result);
            }
            catch
            {
                throw new ArgumentException("Erro ao completar processo");
            }
        }
        // GET: CostController/GetAll/
        [HttpGet]
        public async Task<IActionResult> GetAllCost()
        {
            try
            {
                var query = new GetAllCostQuery();
                var result = await _mediator.Send(query);

                return Ok(result.Data);
            }
            catch
            {
                throw new ArgumentException("Erro ao completar processo");
            }
        }

        // GET: CostController/GetByID/
        [HttpGet("/GetById")]
        public async Task<IActionResult> GetByIdCost(GetByIdCostQuery query)
        {
            try
            {
                var result = await _mediator.Send(query);
                return Ok(result.Data);
            }
            catch
            {
                throw new ArgumentException("Erro ao completar processo");
            }
        }

        // GET: CostController/GetByDate
        [HttpGet("/GetByDate")]
        public async Task<IActionResult> GetByDateCost()
        {
            return Ok();
        }
        // GET: CostController/GetByDescription/
        [HttpGet("/GetByDescription")]
        public async Task<IActionResult> GetByDescritionCost()
        {
            return Ok();
        }

        // PUT: CostController/Update/
        [HttpPut]
        public async Task<IActionResult> UpdateCost(UpdateCostCommand  command)
        {
            try
            {
                var result = await _mediator.Send(command);
                if (!result.IsSuccess) return BadRequest(result.Messsage);
                return Ok(result.IsSuccess);
            }
            catch
            {
                throw new ArgumentException("Erro ao completar processo");
            }
        }

        // DELETE: CostController/Delete/
        [HttpDelete]
        public async Task<IActionResult> DeleteCost(DeleteCostCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                if (!result.IsSuccess) return BadRequest(result.Messsage);
                return Ok(result.IsSuccess);
            }
            catch
            {
                throw new ArgumentException("Erro ao completar processo");
            }
        }
    }
}
