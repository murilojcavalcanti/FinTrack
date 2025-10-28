using FinTrack.Application.Services.Commands.LoginCommands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinTrack.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LoginController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("/Login")]
        public async Task<IActionResult> LoginAsync(LoginCommand login)
        {
            try
            {
                var token = await _mediator.Send(login);
                return Ok(new { Message = $"{token}"});
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred during login", Error = ex.Message });
            }
        }
    }
}
