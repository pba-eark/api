using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pba_api.Data;
using pba_api.DTOs;
using pba_api.DTOs.CreateDtos;
using pba_api.DTOs.ReturnDtos;
using pba_api.Models.AdditionalExpensesModel;
using pba_api.Models.EstimateSheetModel;
using System.Dynamic;

namespace pba_api.Controllers
{
    [Authorize]
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
        public async Task<ActionResult<IEnumerable<ReturnEstimateSheetDto>>> GetEstimateSheets()
        {
            var dbObject = await _context.EstimateSheets.ToListAsync();
            return Ok(_mapper.Map<List<ReturnEstimateSheetDto>>(dbObject));
        }

        // GET: api/EstimateSheets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ExpandoObject>> GetEstimateSheet(int id, [FromQuery] string? included)
        {
            string[] queryParams = Array.Empty<string>();

            if (included != null)
            {
                queryParams = included.Split(",");
            }

            var dbObject = await _context.EstimateSheets.FindAsync(id);

            if (dbObject == null)
            {
                return NotFound();
            }

            CreateEstimateSheetDto estimateSheet = _mapper.Map<CreateEstimateSheetDto>(dbObject);

            dynamic returnObj = new ExpandoObject();

            returnObj.estimateSheet = estimateSheet;

            if (queryParams.Length > 0 && queryParams.Contains("customer"))
            {
                var customer = await _context.Customers.FindAsync(dbObject.CustomerId);
                returnObj.customer = _mapper.Map<ReturnCustomerDto>(customer);
            }

            if (queryParams.Length > 0 && queryParams.Contains("status"))
            {
                var status = await _context.SheetStatus.FindAsync(dbObject.SheetStatusId);
                returnObj.status = status;
            }

            return Ok(returnObj);
        }

        // POST: api/EstimateSheets
        [HttpPost]
        public async Task<ActionResult<ReturnEstimateSheetDto>> PostEstimateSheet(CreateEstimateSheetDto dto)
        {
            var estimateSheet = _mapper.Map<EstimateSheet>(dto);

            if (estimateSheet.CustomerId == 0)
            {
                estimateSheet.CustomerId = null;
            }

            if (estimateSheet.SheetStatusId == 0)
            {
                estimateSheet.SheetStatusId = null;
            }

            _context.EstimateSheets.Add(estimateSheet);

            await _context.SaveChangesAsync();
            var returnObj = _mapper.Map<ReturnEstimateSheetDto>(estimateSheet);

            return CreatedAtAction(nameof(GetEstimateSheets), returnObj);
        }

        // PUT: api/EstimateSheets/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEstimateSheet(int id, CreateEstimateSheetDto dto)
        {
            var estimateSheet = _mapper.Map<EstimateSheet>(dto);
            estimateSheet.Id = id;
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

            return Ok(_mapper.Map<ReturnEstimateSheetDto>(estimateSheet));
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
