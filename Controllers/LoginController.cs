using BankingControlPanel.API.Services.JWT;
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
        public LoginController(UserManager<IdentityUser> userManager,
                            SignInManager<IdentityUser> signInManager,
                            IConfiguration configuration, IJwtManager jwtManager
         )
        {
            _jwtManager = jwtManager;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            //var result = await _signInManager.PasswordSignInAsync(user.Email, user.Password, false, false);

            //if (result.Succeeded)
            //{
                //var IsUser = await _userManager.FindByEmailAsync(user.Email);
                var token = _jwtManager.GenerateToken(user.Email);
                return Ok(new { token });
            //}

            return Unauthorized();
        }

    }
}
