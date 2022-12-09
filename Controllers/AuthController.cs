using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using pba_api.Data;
using pba_api.DTOs;
using pba_api.DTOs.ReturnDtos;
using pba_api.Models.UserModel;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BC = BCrypt.Net.BCrypt;

namespace pba_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IConfiguration _config;
        private readonly ApplicationDbContext _context;
        private readonly HttpClient _httpClient;
        private readonly IMapper _mapper;

        public AuthController(IConfiguration config, ApplicationDbContext context, HttpClient httpClient, IMapper mapper)
        {
            _config = config;
            _context = context;
            _httpClient = httpClient;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login([FromBody] UserLoginDTO userLoginDTO)
        {
            var user = AuthenticateUser(userLoginDTO);

            if (user != null)
            {
                var token = GenerateToken(user);
                var returnUserDto = _mapper.Map<ReturnUserDto>(user);
                var response = new {User = returnUserDto, Token = token};

                return Ok(response);
            }

            return NotFound("User not found");
        }

        private string GenerateToken(User user)
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
                    expires: DateTime.Now.AddDays(7),
                    signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private User? AuthenticateUser(UserLoginDTO userLoginDto)
        {
            var user = _context.Users.SingleOrDefault(x => x.Email == userLoginDto.Email);

            if (BC.Verify(userLoginDto.Password, user.Password))
            {
                return user;
            }
            return null;
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
