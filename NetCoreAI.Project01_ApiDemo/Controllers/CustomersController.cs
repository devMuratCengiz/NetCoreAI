using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetCoreAI.Project01_ApiDemo.Context;
using NetCoreAI.Project01_ApiDemo.Entities;

namespace NetCoreAI.Project01_ApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ApiContext _context;

        public CustomersController(ApiContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult CustomerList()
        {
            var value = _context.Customers.ToList();
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CreateCustomer(Customer customer)
        {
            var response = _context.Customers.Add(customer);
            _context.SaveChanges();
            if (response != null)
            {
                return Ok("Customer created successfully");
            }
            else
            {
                return BadRequest("Customer creation failed");
            }
        }
        [HttpDelete]
        public IActionResult DeleteCustomer(int id)
        {
            var customer = _context.Customers.Find(id);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
                _context.SaveChanges();
                return Ok("Customer deleted successfully");
            }
            return BadRequest("Customer not found");
        }

        [HttpGet("GetById")]
        public IActionResult GetCustomer(int id)
        {
            var customer = _context.Customers.Find(id);
            if (customer != null)
            {
                return Ok(customer);
            }
            return BadRequest("Customer not found");

        }
        [HttpPut]
        public IActionResult UpdateCustomer(Customer customer)
        {
            var value = _context.Customers.Find(customer.Id);
            if(value is not null)
            {
                _context.Entry(value).State = EntityState.Detached;
                _context.Customers.Update(customer);
                _context.SaveChanges();
                return Ok("Customer updated successfully");
            }
            return BadRequest("Customer can not found.");
        }
    }
}
