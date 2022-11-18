using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pba_api.Data;
using pba_api.DTOs;
using pba_api.Models.EstimateSheetModel;
using pba_api.Models.UserModel;

namespace pba_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserTestsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;

        public UserTestsController(IMapper mapper, ApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        // GET: api/UserTests
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUser()
        {
            var users = await _context.Users.ToListAsync();
            return Ok(_mapper.Map<List<CreateUserDto>>(users));
        }

        [HttpPost]
        public async Task<ActionResult<User>> PostUser(CreateUserDto dto)
        {
            var user = _mapper.Map<User>(dto);
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", dto);
        }
    }
}
