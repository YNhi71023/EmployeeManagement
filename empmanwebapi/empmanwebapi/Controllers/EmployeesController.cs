using empmanwebapi.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using storeworkingapi.Models;
using System.Data;

namespace empmanwebapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : Controller
    {
        private readonly EmployeesDbContext _context;
        public EmployeesController(EmployeesDbContext context)
        {
            _context = context;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllEmployees()
        {
            DataTable data = await _context.GetAllEmployee_();

            if (data.Rows.Count > 0)
            {
                return Ok(data);
            }

            return BadRequest("Error creating employee");
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateEmployee([FromBody] Employees employee)
        {
            if (employee == null) return BadRequest();


            DataTable data = await _context.CreateEmployeeAsync_(0, employee);

            if (data.Rows.Count > 0)
            {

                return Ok(data);
            }

            return BadRequest("Error creating employee");
        }
        
    }
}

