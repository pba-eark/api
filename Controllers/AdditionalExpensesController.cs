using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pba_api.Data;
using pba_api.DTOs;
using pba_api.Models.AdditionalExpensesModel;
using pba_api.Models.EstimateSheetModel;

namespace pba_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdditionalExpensesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;

        public AdditionalExpensesController(IMapper mapper, ApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        // GET: api/AdditionalExpenses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AdditionalExpenseDto>>> GetAdditionalExpenses()
        {
            var additionalExpenses = await _context.AdditionalExpenses.ToListAsync();
            return Ok(_mapper.Map<List<AdditionalExpenseDto>>(additionalExpenses));
        }

        // GET: api/AdditionalExpenses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AdditionalExpenseDto>> GetAdditionalExpenses(int id)
        {
            var additionalExpensesDb = await _context.AdditionalExpenses.FindAsync(id);

            if (additionalExpensesDb == null)
            {
                return NotFound();
            }

            var additionalExpenses = _mapper.Map<AdditionalExpenseDto>(additionalExpensesDb);

            return additionalExpenses;
        }

        // POST: api/AdditionalExpenses
        [HttpPost]
        public async Task<ActionResult<AdditionalExpenseDto>> PostAdditionalExpense(AdditionalExpenseDto dto)
        {
            var additionalExpense = _mapper.Map<AdditionalExpense>(dto);
            _context.AdditionalExpenses.Add(additionalExpense);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAdditionalExpenses), new { id = additionalExpense.Id }, dto);
        }

        // PUT: api/AdditionalExpense/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdditionalExpense(int id, AdditionalExpenseDto dto)
        {
            if (id != dto.Id)
            {
                return BadRequest();
            }

            var additionalExpense = _mapper.Map<AdditionalExpense>(dto);
            _context.Entry(additionalExpense).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdditionalExpensesExists(id))
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

        // DELETE: api/AdditionalExpenses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdditionalExpense(int id)
        {
            var additionalExpenses = await _context.AdditionalExpenses.FindAsync(id);
            if (additionalExpenses == null)
            {
                return NotFound();
            }

            _context.AdditionalExpenses.Remove(additionalExpenses);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AdditionalExpensesExists(int id)
        {
            return _context.AdditionalExpenses.Any(e => e.Id == id);
        }
    }
}
