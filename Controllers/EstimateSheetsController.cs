using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using pba_api.Data;
using pba_api.DTOs;
using pba_api.Models.EstimateSheetModel;
using pba_api.Models.UserModel;
using System.Dynamic;

namespace pba_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstimateSheetsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;

        public EstimateSheetsController(IMapper mapper, ApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        // GET: api/EstimateSheets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EstimateSheet>>> GetEstimateSheets()
        {
            var estimateSheet =  await _context.EstimateSheets.ToListAsync();
            return Ok(_mapper.Map<List<EstimateSheetDto>>(estimateSheet));
        }

        // GET: api/EstimateSheets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ExpandoObject>> GetEstimateSheets(int id, [FromQuery] string? included)
        {
            string[] queryParams = Array.Empty<string>();

            if (included != null)
            {
                queryParams = included.Split(",");
            }

            var estimateSheetDb = await _context.EstimateSheets.FindAsync(id);

            if (estimateSheetDb == null)
            {
                return NotFound();
            }

            EstimateSheetDto estimateSheet = _mapper.Map<EstimateSheetDto>(estimateSheetDb);

            dynamic returnObj = new ExpandoObject();

            returnObj.estimateSheet = estimateSheet;

            if (queryParams.Length > 0 && queryParams.Contains("user"))
            {
                var user = await _context.Users.FindAsync(estimateSheetDb.UserId);
                returnObj.user = user;
            }

            if (queryParams.Length > 0 && queryParams.Contains("customer"))
            {
                var customer = await _context.Customers.FindAsync(estimateSheetDb.CustomerId);
                returnObj.customer = customer;
            }

            if (queryParams.Length > 0 && queryParams.Contains("status"))
            {
                var status = await _context.SheetStatus.FindAsync(estimateSheetDb.SheetStatusId);
                returnObj.status = status;
            }

            return Ok(returnObj);
        }

        // POST: api/EstimateSheets
        [HttpPost]
        public async Task<ActionResult<EstimateSheetDto>> PostEstimateSheet(EstimateSheetDto dto)
        {
            var estimateSheet = _mapper.Map<EstimateSheet>(dto);
            _context.EstimateSheets.Add(estimateSheet);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEstimateSheets), new { id = estimateSheet.Id }, dto);
        }

        // PUT: api/EstimateSheets/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEstimateSheet(int id, EstimateSheetDto dto)
        {
            if (id != dto.Id)
            {
                return BadRequest();
            }

            var estimateSheet = _mapper.Map<EstimateSheet>(dto);
            _context.Entry(estimateSheet).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstimateSheetExists(id))
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

        // DELETE: api/EstimateSheets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEstimateSheet(int id)
        {
            var estimateSheet = await _context.EstimateSheets.FindAsync(id);
            if (estimateSheet == null)
            {
                return NotFound();
            }

            _context.EstimateSheets.Remove(estimateSheet);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EstimateSheetExists(int id)
        {
            return _context.EstimateSheets.Any(e => e.Id == id);
        }
    }
}
