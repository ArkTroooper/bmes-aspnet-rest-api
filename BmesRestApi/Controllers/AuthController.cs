using System.Net;
using System.Threading.Tasks;
using BmesRestApi.Messages.Request.User;
using BmesRestApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace BmesRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }


        [HttpPost("login")]
        public async Task<IActionResult> LogIn(LogInRequest request)
        {
            var logInResponse = await _authService.LogInAsync(request);

            if (logInResponse.StatusCode == HttpStatusCode.InternalServerError)
            {
                return BadRequest(logInResponse);
            }

            return Ok(logInResponse);

        }


        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var registerResponse = await _authService.RegisterAsync(request);

            if (registerResponse.StatusCode == HttpStatusCode.InternalServerError)
            {
                return BadRequest(registerResponse);
            }

            return Ok(registerResponse);
        }
    }
}