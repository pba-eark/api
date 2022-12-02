using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pba_api.Data;
using pba_api.DTOs;
using pba_api.Models.EstimateSheetUserModel;

namespace pba_api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EstimateSheetUsersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;

        public EstimateSheetUsersController(IMapper mapper, ApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        // GET: api/EstimateSheetUsers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EstimateSheetUserDto>>> GetEstimateSheetUsers()
        {
            var dbObject = await _context.EstimateSheetUsers.ToListAsync();
            return Ok(_mapper.Map<List<EstimateSheetUserDto>>(dbObject));
        }

        //// GET: api/EstimateSheetUsers/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<EstimateSheetUserDto>> GetEstimateSheetUser(int id)
        //{
        //    var dbObject = await _context.EstimateSheetUsers.FindAsync(id);

        //    if (dbObject == null)
        //    {
        //        return NotFound();
        //    }

        //    return _mapper.Map<EstimateSheetUserDto>(dbObject);
        //}

        // POST: api/EstimateSheetUsers
        [HttpPost]
        public async Task<ActionResult<EstimateSheetUserDto>> PostEstimateSheetUser(EstimateSheetUserDto dto)
        {
            var estimateSheetUser = _mapper.Map<EstimateSheetUser>(dto);
            _context.EstimateSheetUsers.Add(estimateSheetUser);
            await _context.SaveChangesAsync();
            var returnDto = _mapper.Map<EstimateSheetUserDto>(estimateSheetUser);

            return CreatedAtAction(nameof(GetEstimateSheetUsers), returnDto);
        }

        //// PUT: api/EstimateSheetUsers/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutEstimateSheetUser(int id, EstimateSheetUserDto dto)
        //{
        //    var estimateSheetUser = _mapper.Map<EstimateSheetUser>(dto);
        //    _context.Entry(estimateSheetUser).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!EstimateSheetUsersExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // DELETE: api/EstimateSheetUsers/5
        [HttpDelete]
        public async Task<IActionResult> DeleteEstimateSheetUser([FromQuery] int sheetId, [FromQuery] int userId)
        {
            var dbObject = await _context.EstimateSheetUsers.FindAsync(sheetId, userId);
            if (dbObject == null)
            {
                return NotFound();
            }

            _context.EstimateSheetUsers.Remove(dbObject);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        //private bool EstimateSheetUsersExists(int id)
        //{
        //    return _context.EstimateSheetUsers.Any(e => e.Id == id);
        //}
    }
}
