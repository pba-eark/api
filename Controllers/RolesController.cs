using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pba_api.Data;
using pba_api.DTOs.CreateDtos;
using pba_api.DTOs.ReturnDtos;
using pba_api.Models.AdditionalExpensesModel;
using pba_api.Models.RoleModel;

namespace pba_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;

        public RolesController(IMapper mapper, ApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        // GET: api/Roles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReturnRoleDto>>> GetRoles()
        {
            var dbObject = await _context.Roles.ToListAsync();
            return Ok(_mapper.Map<List<ReturnRoleDto>>(dbObject));
        }


        // GET: api/Roles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReturnRoleDto>> GetRole(int id)
        {
            var dbObject = await _context.Roles.FindAsync(id);

            if (dbObject == null)
            {
                return NotFound();
            }

            return _mapper.Map<ReturnRoleDto>(dbObject);
        }

        // POST: api/Roles
        [HttpPost]
        public async Task<ActionResult<ReturnRoleDto>> PostAdditionalExpense(CreateRoleDto dto)
        {
            var role = _mapper.Map<Role>(dto);
            _context.Roles.Add(role);
            await _context.SaveChangesAsync();
            var returnDto = _mapper.Map<ReturnRoleDto>(role);

            return CreatedAtAction(nameof(GetRoles), returnDto);
        }

        // PUT: api/Roles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoles(int id, CreateRoleDto dto)
        {
            var role = _mapper.Map<Role>(dto);
            role.Id = id;
            _context.Entry(role).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RolesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(_mapper.Map<ReturnRoleDto>(role));
        }

        // DELETE: api/Roles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoles(int id)
        {
            var dbObject = await _context.Roles.FindAsync(id);
            if (dbObject == null)
            {
                return NotFound();
            }

            _context.Roles.Remove(dbObject);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RolesExists(int id)
        {
            return _context.Roles.Any(e => e.Id == id);
        }
    }
}
