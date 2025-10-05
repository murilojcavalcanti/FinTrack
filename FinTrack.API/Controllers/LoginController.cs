using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinTrack.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpPost("/Login")]
        public IActionResult Login([FromBody] string user)
        {
            try
            {
                return Ok(new { Message = "Login successful", User = user });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred during login", Error = ex.Message });
            }
        }
    }
}
