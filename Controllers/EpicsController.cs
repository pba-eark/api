using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pba_api.Data;
using pba_api.DTOs;
using pba_api.Models.EpicModel;
using pba_api.Models.EstimateSheetModel;

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
        public async Task<ActionResult<IEnumerable<EpicDto>>> GetEpics()
        {
            var epic = await _context.Epics.ToListAsync();
            return Ok(_mapper.Map<List<EstimateSheetDto>>(epic));
        }

        // GET: api/Epics/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EpicDto>> GetEpic(int id)
        {
            var epicDb = await _context.Epics.FindAsync(id);

            if (epicDb == null)
            {
                return NotFound();
            }

            var epic = _mapper.Map<EpicDto>(epicDb);

            return epic;
        }

        // PUT: api/Epics/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEpic(int id, EpicDto dto)
        {
            //if (id != dto.Id)
            //{
            //    return BadRequest();
            //}
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
        public async Task<ActionResult<EpicDto>> PostEpic(EpicDto dto)
        {
            var epic = _mapper.Map<Epic>(dto);
            _context.Epics.Add(epic);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEpic), dto);
        }

        // DELETE: api/Epics/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEpic(int id)
        {
            var epic = await _context.Epics.FindAsync(id);
            if (epic == null)
            {
                return NotFound();
            }

            _context.Epics.Remove(epic);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EpicExists(int id)
        {
            return _context.Epics.Any(e => e.Id == id);
        }
    }
}
