using FinTrack.Application.Services.Commands.UserCommands.CreateUser;
using FinTrack.Application.Services.Commands.UserCommands.DeleteUser;
using FinTrack.Application.Services.Commands.UserCommands.UpdateUser;
using FinTrack.Application.Services.Queries.UsersQueries.GetAllUsersQuery;
using FinTrack.Application.Services.Queries.UsersQueries.GetByIdUsersQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinTrack.API.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class UserController:ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }


        // POST: UserController/CreateUser/
        [HttpPost("/CreateUser")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserCommand command)
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

        // GET: UserController/GetAllUser/
        [HttpGet("/GetAllUser")]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                var query = new GetAllUsersQuery();
                var result = await _mediator.Send(query);
                if (!result.IsSuccess) return BadRequest(result.Messsage);
                return Ok(result.Data);
            }
            catch
            {
                throw;
            }
        }

        // GET: UserController/GetByIdUser/
        [HttpGet("/GetByIdUser")]
        public async Task<IActionResult> GetByIdReceives([FromBody] GetByIdUserQuery query)
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

        // PUT: UserController/UpdateUser/
        [HttpPut("/UpdateUser")]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserCommand command)
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

        // GET: UserController/DeleteUser
        [HttpDelete("/DeleteUser")]
        public async Task<IActionResult> DeleteUser([FromBody] DeleteUserCommand command)
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
