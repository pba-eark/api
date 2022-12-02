using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pba_api.Data;
using pba_api.DTOs.CreateDtos;
using pba_api.DTOs.ReturnDtos;
using pba_api.Models.AdditionalExpensesModel;
using pba_api.Models.UserModel;
using System.Security.Claims;
using BC = BCrypt.Net.BCrypt;

namespace pba_api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UsersController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReturnUserDto>>> GetUsers()
        {
            var users = await _context.Users.ToListAsync();
            return Ok(_mapper.Map<List<ReturnUserDto>>(users));
        }

        // GET: api/Users/Me
        [HttpGet("me")]
        public IActionResult GetMe()
        {
            return Ok(GetCurrentUser());
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        private User? GetCurrentUser()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;

            if (identity != null)
            {
                var userClaims = identity.Claims;

                return new User
                {
                    FirstName = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.NameIdentifier).Value,
                    Email = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Email).Value
                };
            }
            return null;
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<ReturnUserDto>> PutUser(int id, CreateUserDto dto)
        {
            var user = _mapper.Map<User>(dto);
            user.Id= id;
            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(_mapper.Map<ReturnUserDto>(user));
        }

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<ReturnUserDto>> PostUser(CreateUserDto dto)
        {
            var user = _mapper.Map<User>(dto);
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
            try
            {
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
            }
            catch
            {
                return Ok("Email is already in use.");
            }
            var returnDto = _mapper.Map<ReturnUserDto>(user);

            return CreatedAtAction(nameof(GetUsers), returnDto);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var dbObject = await _context.Users.FindAsync(id);
            if (dbObject == null)
            {
                return NotFound();
            }

            _context.Users.Remove(dbObject);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
