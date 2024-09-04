using BankingControlPanel.API.Services.JWT;
using BCP.Manager.User;
using BCP.Model.Login;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BankingControlPanel.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IJwtManager _jwtManager;
        private readonly UserManager _userManager;
        public LoginController(UserManager userManager,SignInManager<IdentityUser> signInManager,IConfiguration configuration, IJwtManager jwtManager)
        {
            _jwtManager = jwtManager;
            _userManager = userManager;
        }
        #region Authorization
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _userManager.CreateUser(model); // Adding User
          
            if (result.IsSuccess)
            {
                return Ok();
            }

            foreach (var error in result.Errors) // Handling Errors
            {
                ModelState.AddModelError("", error);
            }
            return BadRequest(ModelState);
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _userManager.SignInAsync(model); // Cheking Authorized User

            if (result.IsSuccess)
            {
                var claim = _jwtManager.GenerateClaim(model.Email); // Generating Email Claims
                var token = _jwtManager.GenerateToken(claim); // Generation JSON Token
                return Ok(new { token });
            }

            return Unauthorized();
        }
        #endregion
    }
}
