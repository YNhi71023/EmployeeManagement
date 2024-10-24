using empmanwebapi.CORE;
using empmanwebapi.Data;
using empmanwebapi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using storeworkingapi.Models;
using System.Data;

namespace empmanwebapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : APIController
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
        [HttpGet("[action]")]
        public async Task<IActionResult> GetEmployeeById(int employee_id)
        {
            ReponseModel r = new ReponseModel();
        
 
            DataTable data = await _context.GetEmployeeById_(employee_id);
            if (data.Rows.Count == 0)
            {
                r.status = "error";
                r.message = "employee not found";
                return Ok(r);
            }
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


            DataTable data = await _context.CreateEmployeeAsync_(employee_id, employee);

            if (data.Rows.Count > 0)
            {

                return Ok(data);
            }

            return BadRequest("Error creating employee");
        }
        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateEmployee(int id, [FromBody] Employees employee)
        {
            if (id != employee.employee_id)
            {
                return BadRequest(new { message = "Employee ID mismatch" });
            }

            try
            {
                bool isUpdated = await _context.UpdateEmployeeAsync_(employee);

                if (isUpdated)
                {
                    return Ok(new { message = "Employee updated successfully" });
                }
                else
                {
                    return NotFound(new { message = "Employee not found" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred", error = ex.Message });
            }
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> DaleteEmployee(int employee_id)
        {
            try
            {
                bool isDeleted = await _context.DeleteEmployee_(employee_id);

                if (isDeleted)
                {
                    return Ok(new { message = "Employee deleted successfully" });
                }
                else
                {
                    return NotFound(new { message = "Employee not found" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred", error = ex.Message });
            }
        }

    }
}

