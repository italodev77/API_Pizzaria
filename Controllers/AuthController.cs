using backendPizzaria.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace backendPizzaria.Controllers
{
    public class AuthController: ControllerBase
    {
        private readonly SignInManager<IdentityUser> _sigInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly JwtSettings _jwtSettings;

        public AuthController(
            SignInManager<IdentityUser> signInManager,
            UserManager<IdentityUser> userManager,
            IOptions<JwtSettings> jwtSettings
            )
        {
            _sigInManager = signInManager;
            _userManager = userManager;
            _jwtSettings = jwtSettings.Value;
        }

        [HttpPost]
        public async Task<ActionResult> UserRegister(RegisterUserModel registerUser)
        {
            return Ok();
        }
        
        [HttpPost]
        public async Task<ActionResult> UserLogin(LoginUserModel loginUser)
        {
            return Ok();
        }
    }
}
