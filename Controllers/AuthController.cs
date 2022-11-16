using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using pba_api.Data;
using pba_api.Models.DTOs;
using pba_api.Models.UserModel;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace pba_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IConfiguration _config;
        private readonly ApplicationDbContext _context;

        public AuthController(IConfiguration config, ApplicationDbContext context)
        {
            _config = config;
            _context = context;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login([FromBody] UserLoginDTO userLoginDTO)
        {
            var user = Authenticate(userLoginDTO);

            if (user != null)
            {
                var token = Generate(user);

                return Ok(token);
            }

            return NotFound("User not found");
        }

        private string Generate(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.FirstName),
                new Claim(ClaimTypes.Email, user.Email)
            };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                    _config["Jwt:Audience"],
                    claims,
                    expires: DateTime.Now,
                    signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private User Authenticate(UserLoginDTO userLoginDto)
        {
            return _context.Users.FirstOrDefault(o => o.Email.ToLower() == userLoginDto.Email.ToLower() && o.Password == userLoginDto.Password);
        }
    }
}
