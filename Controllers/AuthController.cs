﻿using backendPizzaria.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace backendPizzaria.Controllers
{
    [ApiController]
    [Route("/accounts")]
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

        [HttpPost("register")]
        public async Task<ActionResult> UserRegister(RegisterUserModel registerUser)
        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState);

            var user = new IdentityUser
            {
                UserName = registerUser.Email,
                Email = registerUser.Email,
                EmailConfirmed = true,
            };

            var result = await _userManager.CreateAsync(user, registerUser.Password);

            if (result.Succeeded)
            {
                await _sigInManager.SignInAsync(user, false);
                return Ok(await GenerateJwt(user.Email));
            }

            // Coletando e exibindo os erros específicos da criação do usuário
            var errors = string.Join(", ", result.Errors.Select(e => e.Description));
            return Problem($"Falha ao registrar o usuário: {errors}");
        }


        [HttpPost("login")]
        public async Task<ActionResult> UserLogin(LoginUserModel loginUser)
        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState);

            var result = await _sigInManager.PasswordSignInAsync(loginUser.Email, loginUser.Password, false, true);

            if (result.Succeeded)
            {
                return Ok(await GenerateJwt(loginUser.Email));
            }

            return Problem("Usuário ou senha incorretos");
        }


        private async Task<string>  GenerateJwt(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            var roles = await _userManager.GetRolesAsync(user);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
            };

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.Secret);



            var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
            {
                Subject =  new ClaimsIdentity(claims),
                Issuer = _jwtSettings.Sender,
                Audience = _jwtSettings.Audience,
                Expires = DateTime.UtcNow.AddHours(_jwtSettings.ExpirationTime),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            });

            var encodedToken = tokenHandler.WriteToken(token);

            return encodedToken;
        }

    }
}
