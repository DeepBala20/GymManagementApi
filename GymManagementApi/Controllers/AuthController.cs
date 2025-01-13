using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GymManagementApi.Data;
using GymManagementApi.Model;

namespace GymManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthRepository _authRepository;

        public AuthController(AuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] AuthModel auth)
        {
            if (auth == null || string.IsNullOrWhiteSpace(auth.UserName) || string.IsNullOrWhiteSpace(auth.Password))
            {
                return BadRequest("Invalid authentication request.");
            }

            // Validate user credentials
            var user = _authRepository.ValidateUser(auth);
            if (user == null)
            {
                return Unauthorized("Invalid username or password.");
            }

            // Generate the token
            var token = _authRepository.GenerateToken(user);
            if (token != null)
            {
                return Ok(new
                {
                    Token = token,
                    Expiration = DateTime.UtcNow.AddMinutes(_authRepository.JwtSettings.ExpiryMinutes)
                });
            }

            return StatusCode(500, "An error occurred while generating the token.");
        }
    }
}
