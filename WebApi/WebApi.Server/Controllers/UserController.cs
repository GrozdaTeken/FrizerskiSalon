using Application.Authentication;
using Application.DTOs.Create;
using Application.DTOs.Returnable;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace WebApi.Authentication
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IUserService _userService;

        public AuthenticateController(IConfiguration configuration, IUserService UserService)
        {
            _configuration = configuration;
            _userService = UserService;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            if (model == null || string.IsNullOrEmpty(model.EmailOrUsername) || string.IsNullOrEmpty(model.Password))
            {
                return BadRequest(new Response { Status = "Error", Message = "Invalid input data!" });
            }

            var isEmail = model.EmailOrUsername.Contains("@");

            var user = isEmail
                ? await _userService.GetUserByEmailAndPasswordAsync(model.EmailOrUsername, model.Password)
                : await _userService.GetUserByUsernameAndPasswordAsync(model.EmailOrUsername, model.Password);

            if (user == null)
            {
                return BadRequest(new Response { Status = "Error", Message = "User doesn't exist!" });
            }

            var userRole = user.Role;

            var authClaims = new List<Claim>
            {
                new(ClaimTypes.Email, user.Email),
                new(ClaimTypes.Role, userRole.ToString()),
            };

            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return Ok(new { token = tokenString });
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(UserCreate model)
        {
            if (model == null || string.IsNullOrEmpty(model.Email) || string.IsNullOrEmpty(model.Password))
            {
                return BadRequest(new Response { Status = "Error", Message = "Invalid input data!" });
            }

            var emailExists = await _userService.EmailExistAsync(model.Email);
            if (emailExists)
            {
                return BadRequest(new Response { Status = "Error", Message = "Email already in use!" });
            }

            try
            {
                var newUser = await _userService.AddUserAsync(model);

                return Ok(new Response
                {
                    Status = "Success",
                    Message = "User registered successfully!",
                    Data = new UserReturnable(
                        newUser.UserId,
                        newUser.Username,
                        newUser.Email,
                        newUser.Role
                    )
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new Response { Status = "Error", Message = ex.Message });
            }
        }

    }
}
