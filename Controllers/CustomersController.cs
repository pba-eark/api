using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pba_api.Data;
using pba_api.DTOs;
using pba_api.Models.CustomerModel;
using pba_api.Models.UserModel;

namespace pba_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;

        public CustomersController(IMapper mapper, ApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomer()
        {
            var customers = await _context.Customers.ToListAsync();
            return Ok(_mapper.Map<List<CustomerDto>>(customers));
        }

        [HttpPost]
        public async Task<ActionResult<Customer>> PostCustomer(CustomerDto dto)
        {
            var customer = _mapper.Map<Customer>(dto);
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCustomer", dto);
        }
    }
}
