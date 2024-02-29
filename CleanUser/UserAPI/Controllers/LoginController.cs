using Microsoft.AspNetCore.Mvc;
using UserApplication.DTO;
using UserInfrastrucutre.JWTToken;
using Serilog;
using UserApplication.Interfaces;

namespace UserAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        private readonly ILoginService _loginService;
        private readonly IConfiguration _config;
        public LoginController(ILoginService loginService, IConfiguration config)
        {
            _loginService = loginService;
            _config = config;
        }

        [HttpPost("Login")]
        public IActionResult LoginUser(LoginDTO login)
        {
            try
            {
                var userAvailable = _loginService.LoginUser(login);

                if (userAvailable == null)
                {
                    return NotFound();
                }


                if (login.Pwd != userAvailable.Pwd)
                {
                    Log.Warning("Wrong Password Entered for user with ID {UserId}", userAvailable.Id);
                    return Ok("Wrong Password Entered");
                }


                var jwtServices = new JwtServices(_config);
                var token = jwtServices.GenerateToken(
                    userAvailable.Id,
                   userAvailable.Email,
                   userAvailable.Role
                );
                Log.Information("User with ID {UserId} logged in successfully", userAvailable.Id);
                return Ok(token);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occurred while processing the login request");
                return StatusCode(500, "Internal Server Error");

            }
        }
    }
}
