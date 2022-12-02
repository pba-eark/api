using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pba_api.Data;
using pba_api.DTOs.CreateDtos;
using pba_api.DTOs.ReturnDtos;
using pba_api.Models.AdditionalExpensesModel;

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
        public async Task<ActionResult<IEnumerable<ReturnAdditionalExpenseDto>>> GetAdditionalExpenses()
        {
            var dbObject = await _context.AdditionalExpenses.ToListAsync();
            return Ok(_mapper.Map<List<ReturnAdditionalExpenseDto>>(dbObject));
        }

        // GET: api/AdditionalExpenses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReturnAdditionalExpenseDto>> GetAdditionalExpense(int id)
        {
            var dbObject = await _context.AdditionalExpenses.FindAsync(id);

            if (dbObject == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<ReturnAdditionalExpenseDto>(dbObject));
        }

        // POST: api/AdditionalExpenses
        [HttpPost]
        public async Task<ActionResult<ReturnAdditionalExpenseDto>> PostAdditionalExpense(CreateAdditionalExpenseDto dto)
        {
            var additionalExpense = _mapper.Map<AdditionalExpense>(dto);
            _context.AdditionalExpenses.Add(additionalExpense);
            await _context.SaveChangesAsync();
            var returnDto = _mapper.Map<ReturnAdditionalExpenseDto>(additionalExpense);

            return CreatedAtAction(nameof(GetAdditionalExpense), returnDto);
        }

        // PUT: api/AdditionalExpense/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdditionalExpense(int id, CreateAdditionalExpenseDto dto)
        {
            var additionalExpense = _mapper.Map<AdditionalExpense>(dto);
            additionalExpense.Id = id;
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

            return Ok(_mapper.Map<ReturnAdditionalExpenseDto>(additionalExpense));
        }

        // DELETE: api/AdditionalExpenses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdditionalExpense(int id)
        {
            var dbObject = await _context.AdditionalExpenses.FindAsync(id);
            if (dbObject == null)
            {
                return NotFound();
            }

            _context.AdditionalExpenses.Remove(dbObject);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AdditionalExpensesExists(int id)
        {
            return _context.AdditionalExpenses.Any(e => e.Id == id);
        }
    }
}
