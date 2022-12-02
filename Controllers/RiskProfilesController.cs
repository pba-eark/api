using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pba_api.Data;
using pba_api.DTOs;
using pba_api.DTOs.CreateDtos;
using pba_api.DTOs.ReturnDtos;
using pba_api.Models.AdditionalExpensesModel;
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
        public async Task<ActionResult<IEnumerable<ReturnRiskProfileDto>>> GetRiskProfiles()
        {
            var dbObject = await _context.RiskProfiles.ToListAsync();
            return Ok(_mapper.Map<List<ReturnRiskProfileDto>>(dbObject));
        }

        // GET: api/RiskProfiles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReturnRiskProfileDto>> GetRiskProfile(int id)
        {
            var dbObject = await _context.RiskProfiles.FindAsync(id);

            if (dbObject == null)
            {
                return NotFound();
            }

            return _mapper.Map<ReturnRiskProfileDto>(dbObject);
        }

        // POST: api/RiskProfiles
        [HttpPost]
        public async Task<ActionResult<ReturnRiskProfileDto>> PostRiskProfile(CreateRiskProfileDto dto)
        {
            var riskProfile = _mapper.Map<RiskProfile>(dto);
            _context.RiskProfiles.Add(riskProfile);
            await _context.SaveChangesAsync();
            var returnDto = _mapper.Map<ReturnRiskProfileDto>(riskProfile);

            return CreatedAtAction(nameof(GetRiskProfiles), returnDto);
        }

        // PUT: api/RiskProfiles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRiskProfile(int id, CreateRiskProfileDto dto)
        {
            var riskProfile = _mapper.Map<RiskProfile>(dto);
            riskProfile.Id = id;
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

            return Ok(_mapper.Map<ReturnRiskProfileDto>(riskProfile));
        }

        // DELETE: api/Tasks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRiskProfile(int id)
        {
            var dbObject = await _context.RiskProfiles.FindAsync(id);
            if (dbObject == null)
            {
                return NotFound();
            }

            _context.RiskProfiles.Remove(dbObject);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RiskProfileExists(int id)
        {
            return _context.Tasks.Any(e => e.Id == id);
        }
    }
}
