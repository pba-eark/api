using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pba_api.Data;
using pba_api.DTOs;
using pba_api.Models.EpicStatusModel;
using pba_api.Models.EstimateSheetModel;

namespace pba_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EpicStatusController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;

        public EpicStatusController(IMapper mapper, ApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        // GET: api/EpicStatus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EpicStatusDto>>> GetEpicStatus()
        {
            var epicStatus = await _context.EpicStatus.ToListAsync();
            return Ok(_mapper.Map<List<EpicStatusDto>>(epicStatus));
        }

        // GET: api/EpicStatus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EpicStatusDto>> GetEpicStatus(int id)
        {
            var epicStatusDb = await _context.EpicStatus.FindAsync(id);

            if (epicStatusDb == null)
            {
                return NotFound();
            }

            var epicStatus = _mapper.Map<EpicStatusDto>(epicStatusDb);

            return epicStatus;
        }

        // POST: api/EpicStatus
        [HttpPost]
        public async Task<ActionResult<EpicStatusDto>> PostEpicStatus(EpicStatusDto dto)
        {
            var epicStatus = _mapper.Map<EpicStatus>(dto);
            _context.EpicStatus.Add(epicStatus);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEpicStatus), new { id = epicStatus.Id }, dto);
        }

        // PUT: api/EpicStatus/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEpicStatus(int id, EpicStatusDto dto)
        {
            if (id != dto.Id)
            {
                return BadRequest();
            }

            var epicStatus = _mapper.Map<EpicStatus>(dto);
            _context.Entry(epicStatus).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EpicStatusExists(id))
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

        // DELETE: api/EpicStatus/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEpicStatus(int id)
        {
            var epicStatus = await _context.EpicStatus.FindAsync(id);
            if (epicStatus == null)
            {
                return NotFound();
            }

            _context.EpicStatus.Remove(epicStatus);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EpicStatusExists(int id)
        {
            return _context.EpicStatus.Any(e => e.Id == id);
        }
    }
}
