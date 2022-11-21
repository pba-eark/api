﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pba_api.Data;
using pba_api.DTOs.CreateDtos;
using pba_api.DTOs.ReturnDtos;

namespace pba_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;

        public TasksController(IMapper mapper, ApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        // GET: api/Tasks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReturnTaskDto>>> GetTasks()
        {
            var tasks = await _context.Tasks.ToListAsync();
            return Ok(_mapper.Map<List<ReturnTaskDto>>(tasks));
        }

        // GET: api/Tasks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReturnTaskDto>> GetTask(int id)
        {
            var dbObject = await _context.Tasks.FindAsync(id);

            if (dbObject == null)
            {
                return NotFound();
            }

            return _mapper.Map<ReturnTaskDto>(dbObject);
        }

        // POST: api/Tasks
        [HttpPost]
        public async Task<ActionResult<CreateTaskDto>> PostTask(CreateTaskDto dto)
        {
            var task = _mapper.Map<Models.TaskModel.Task>(dto);
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTask), dto);
        }

        // PUT: api/Tasks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTask(int id, CreateTaskDto dto)
        {
            //if (id != dto.Id)
            //{
            //    return BadRequest();
            //}

            var task = _mapper.Map<Models.TaskModel.Task>(dto);
            _context.Entry(task).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaskExists(id))
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

        // DELETE: api/Tasks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task == null)
            {
                return NotFound();
            }

            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TaskExists(int id)
        {
            return _context.Tasks.Any(e => e.Id == id);
        }
    }
}