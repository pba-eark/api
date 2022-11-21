using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pba_api.Data;
using pba_api.DTOs.CreateDtos;
using pba_api.DTOs.ReturnDtos;
using pba_api.Models.AdditionalExpensesModel;
using pba_api.Models.EpicModel;

namespace pba_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EpicsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;

        public EpicsController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Epics
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReturnEpicDto>>> GetEpics()
        {
            var dbObject = await _context.Epics.ToListAsync();
            return Ok(_mapper.Map<List<ReturnEpicDto>>(dbObject));
        }

        // GET: api/Epics/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReturnEpicDto>> GetEpic(int id)
        {
            var dbObject = await _context.Epics.FindAsync(id);

            if (dbObject == null)
            {
                return NotFound();
            }

            return _mapper.Map<ReturnEpicDto>(dbObject);
        }

        // PUT: api/Epics/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEpic(int id, CreateEpicDto dto)
        {
            var epic = _mapper.Map<Epic>(dto);
            _context.Entry(epic).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EpicExists(id))
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

        // POST: api/Epics
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ReturnEpicDto>> PostEpic(CreateEpicDto dto)
        {
            var epic = _mapper.Map<Epic>(dto);
            _context.Epics.Add(epic);
            await _context.SaveChangesAsync();
            var returnDto = _mapper.Map<ReturnEpicDto>(epic);

            return CreatedAtAction(nameof(GetEpics), returnDto);
        }

        // DELETE: api/Epics/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEpic(int id)
        {
            var dbObject = await _context.Epics.FindAsync(id);
            if (dbObject == null)
            {
                return NotFound();
            }

            _context.Epics.Remove(dbObject);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EpicExists(int id)
        {
            return _context.Epics.Any(e => e.Id == id);
        }
    }
}
