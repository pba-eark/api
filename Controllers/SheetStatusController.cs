using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pba_api.Data;
using pba_api.DTOs.CreateDtos;
using pba_api.DTOs.ReturnDtos;
using pba_api.Models.AdditionalExpensesModel;
using pba_api.Models.SheetStatusModel;

namespace pba_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SheetStatusController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;

        public SheetStatusController(IMapper mapper, ApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        // GET: api/SheetStatus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReturnSheetStatusDto>>> GetSheetStatus()
        {
            var dbObject = await _context.SheetStatus.ToListAsync();
            return Ok(_mapper.Map<List<ReturnSheetStatusDto>>(dbObject));
        }

        // GET: api/SheetStatus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReturnSheetStatusDto>> GetSheetStatus(int id)
        {
            var dbObject = await _context.SheetStatus.FindAsync(id);

            if (dbObject == null)
            {
                return NotFound();
            }

            return _mapper.Map<ReturnSheetStatusDto>(dbObject);
        }

        // POST: api/SheetStatus
        [HttpPost]
        public async Task<ActionResult<ReturnSheetStatusDto>> PostSheetStatus(CreateSheetStatusDto dto)
        {
            var sheetStatus = _mapper.Map<SheetStatus>(dto);
            _context.SheetStatus.Add(sheetStatus);
            await _context.SaveChangesAsync();
            var returnDto = _mapper.Map<ReturnSheetStatusDto>(sheetStatus);

            return CreatedAtAction(nameof(GetSheetStatus), returnDto);
        }

        // PUT: api/SheetStatus/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSheetStatus(int id, CreateSheetStatusDto dto)
        {
            var dbObject = _mapper.Map<SheetStatus>(dto);
            _context.Entry(dbObject).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SheetStatusExists(id))
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

        // DELETE: api/SheetStatus/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSheetStatus(int id)
        {
            var dbObject = await _context.SheetStatus.FindAsync(id);
            if (dbObject == null)
            {
                return NotFound();
            }

            _context.SheetStatus.Remove(dbObject);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SheetStatusExists(int id)
        {
            return _context.SheetStatus.Any(e => e.Id == id);
        }
    }
}
