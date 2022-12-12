using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pba_api.Data;
using pba_api.DTOs.Composites;
using pba_api.Models.EstimateSheetRoleModel;

namespace pba_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstimateSheetRolesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;

        public EstimateSheetRolesController(IMapper mapper, ApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        // GET: api/EstimateSheetRoles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EstimateSheetRoleDto>>> EstimateSheetRoles()
        {
            var dbObject = await _context.EstimateSheetRoles.ToListAsync();
            return Ok(_mapper.Map<List<EstimateSheetRoleDto>>(dbObject));
        }

        // POST: api/EstimateSheetRoles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EstimateSheetRoleDto>> PostEstimateSheetRole(EstimateSheetRoleDto dto)
        {
            var sheetRole = _mapper.Map<EstimateSheetRole>(dto);
            _context.EstimateSheetRoles.Add(sheetRole);
            await _context.SaveChangesAsync();
            var returnDto = _mapper.Map<EstimateSheetRoleDto>(sheetRole);

            return CreatedAtAction(nameof(EstimateSheetRoles), returnDto);
        }

        // DELETE: api/EstimateSheetRoles
        [HttpDelete]
        public async Task<IActionResult> DeleteEstimateSheetRole([FromQuery] int sheetId, [FromQuery] int roleId)
        {
            var dbObject = await _context.EstimateSheetRoles.FindAsync(sheetId, roleId);
            if (dbObject == null)
            {
                return NotFound();
            }

            _context.EstimateSheetRoles.Remove(dbObject);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
