using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pba_api.Data;
using pba_api.DTOs.CreateDtos;
using pba_api.DTOs.ReturnDtos;
using pba_api.Models.AdditionalExpensesModel;
using pba_api.Models.EpicStatusModel;

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
        public async Task<ActionResult<IEnumerable<ReturnEpicStatusDto>>> GetEpicStatus()
        {
            var dbObject = await _context.EpicStatus.ToListAsync();
            return Ok(_mapper.Map<List<ReturnEpicStatusDto>>(dbObject));
        }

        // GET: api/EpicStatus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReturnEpicStatusDto>> GetEpicStatus(int id)
        {
            var dbObject = await _context.EpicStatus.FindAsync(id);

            if (dbObject == null)
            {
                return NotFound();
            }

            var epicStatus = _mapper.Map<ReturnEpicStatusDto>(dbObject);

            return epicStatus;
        }

        // POST: api/EpicStatus
        [HttpPost]
        public async Task<ActionResult<ReturnEpicStatusDto>> PostEpicStatus(CreateEpicStatusDto dto)
        {
            var epicStatus = _mapper.Map<EpicStatus>(dto);
            _context.EpicStatus.Add(epicStatus);
            await _context.SaveChangesAsync();
            var returnDto = _mapper.Map<ReturnEpicStatusDto>(epicStatus);

            return CreatedAtAction(nameof(GetEpicStatus), returnDto);
        }

        // PUT: api/EpicStatus/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEpicStatus(int id, CreateEpicStatusDto dto)
        {
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
