using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;
using NuGet.Protocol;
using pba_api.Data;
using pba_api.Models.DTOs;
using pba_api.Models.UserModel;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using static System.Net.Mime.MediaTypeNames;

namespace pba_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IConfiguration _config;
        private readonly ApplicationDbContext _context;
        private readonly HttpClient _httpClient;

        public AuthController(IConfiguration config, ApplicationDbContext context, HttpClient httpClient)
        {
            _config = config;
            _context = context;
            _httpClient = httpClient;
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

        [AllowAnonymous]
        [HttpGet("atlassian")]
        public async Task<IActionResult> AtlassianCallbackAsync([FromQuery] string code)
        {
            var data = new
            {
                grant_type = "authorization_code",
                client_id = _config["Atlassian:ClientId"],
                client_secret = _config["Atlassian:Secret"],
                code = code,
                redirect_uri = "https://localhost:7087/api/auth/atlassian"
            };

            var json = JsonConvert.SerializeObject(data);
            var body = new StringContent(json, Encoding.UTF8, "application/json");

            var url = "https://auth.atlassian.com/oauth/token";
            using var client = new HttpClient();

            var response = await client.PostAsync(url, body);

            var result = await response.Content.ReadAsStringAsync();

            var deserializedResult = JsonConvert.DeserializeObject<dynamic>(result);
            string accessToken = deserializedResult.access_token;

            string redirectUrl = $"http://localhost:3001/callback?token={accessToken}";

            Console.WriteLine(redirectUrl);

            return Redirect(redirectUrl);
        }
    }
}
