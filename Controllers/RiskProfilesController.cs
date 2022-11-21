using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pba_api.Data;
using pba_api.DTOs;
using pba_api.Models.RiskProfileModel;

namespace pba_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RiskProfilesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;

        public RiskProfilesController(IMapper mapper, ApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        // GET: api/RiskProfiles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RiskProfileDto>>> GetRiskProfiles()
        {
            var riskProfiles = await _context.RiskProfiles.ToListAsync();
            return Ok(_mapper.Map<List<RiskProfileDto>>(riskProfiles));
        }

        // GET: api/RiskProfiles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RiskProfileDto>> GetRiskProfile(int id)
        {
            var dbObject = await _context.RiskProfiles.FindAsync(id);

            if (dbObject == null)
            {
                return NotFound();
            }

            return _mapper.Map<RiskProfileDto>(dbObject);
        }

        // POST: api/RiskProfiles
        [HttpPost]
        public async Task<ActionResult<RiskProfileDto>> PostRiskProfile(RiskProfileDto dto)
        {
            var riskProfile = _mapper.Map<RiskProfile>(dto);
            _context.RiskProfiles.Add(riskProfile);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetRiskProfile), dto);
        }

        // PUT: api/RiskProfiles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRiskProfile(int id, RiskProfileDto dto)
        {
            //if (id != dto.Id)
            //{
            //    return BadRequest();
            //}

            var riskProfile = _mapper.Map<RiskProfile>(dto);
            _context.Entry(riskProfile).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RiskProfileExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Tasks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRiskProfile(int id)
        {
            var riskProfile = await _context.RiskProfiles.FindAsync(id);
            if (riskProfile == null)
            {
                return NotFound();
            }

            _context.RiskProfiles.Remove(riskProfile);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RiskProfileExists(int id)
        {
            return _context.Tasks.Any(e => e.Id == id);
        }
    }
}
