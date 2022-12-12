using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pba_api.Data;
using pba_api.DTOs.Composites;
using pba_api.DTOs.CreateDtos;
using pba_api.DTOs.ReturnDtos;
using pba_api.Models.EpicModel;
using pba_api.Models.EstimateSheetRiskProfileModel;

namespace pba_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstimateSheetRiskProfilesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;

        public EstimateSheetRiskProfilesController(IMapper mapper, ApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        // GET: api/EstimateSheetRiskProfiles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EstimateSheetRiskProfileDto>>> EstimateSheetRiskProfiles()
        {
            var dbObject = await _context.EstimateSheetRiskProfiles.ToListAsync();
            return Ok(_mapper.Map<List<EstimateSheetRiskProfileDto>>(dbObject));
        }

        //// GET: api/Epics/EstimateSheetRiskProfiles/5
        //[HttpGet("sheet/{id}")]
        //public async Task<ActionResult<IEnumerable<EstimateSheetRiskProfileDto>>> GetEpics(int id)
        //{
        //    var dbObject = await _context.EstimateSheetRiskProfiles.Where(x => x.EstimateSheetId.Equals(id)).ToListAsync();

        //    if (dbObject == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(_mapper.Map<List<EstimateSheetRiskProfileDto>>(dbObject));
        //}

        //// GET: api/EstimateSheetRiskProfiles
        //[HttpGet]
        //public async Task<ActionResult<EstimateSheetRiskProfileDto>> GetOneEpic([FromQuery] int sheetId, [FromQuery] int profileId)
        //{
        //    var dbObject = await _context.EstimateSheetRiskProfiles.FindAsync(sheetId, profileId);

        //    if (dbObject == null)
        //    {
        //        return NotFound();
        //    }

        //    return _mapper.Map<EstimateSheetRiskProfileDto>(dbObject);
        //}

        // POST: api/EstimateSheetRiskProfiles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EstimateSheetRiskProfileDto>> PostEstimateSheetRiskProfile(EstimateSheetRiskProfileDto dto)
        {
            var sheetRiskProfile = _mapper.Map<EstimateSheetRiskProfile>(dto);
            _context.EstimateSheetRiskProfiles.Add(sheetRiskProfile);
            await _context.SaveChangesAsync();
            var returnDto = _mapper.Map<EstimateSheetRiskProfileDto>(sheetRiskProfile);

            return CreatedAtAction(nameof(EstimateSheetRiskProfiles), returnDto);
        }

        // DELETE: api/EstimateSheetRiskProfiles
        [HttpDelete]
        public async Task<IActionResult> DeleteEstimateSheetRiskProfile([FromQuery] int sheetId, [FromQuery] int profileId)
        {
            var dbObject = await _context.EstimateSheetRiskProfiles.FindAsync(sheetId, profileId);
            if (dbObject == null)
            {
                return NotFound();
            }

            _context.EstimateSheetRiskProfiles.Remove(dbObject);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
