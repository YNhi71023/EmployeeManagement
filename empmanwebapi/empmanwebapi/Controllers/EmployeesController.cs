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
         
        [HttpPost("[action]")]
        [SercurityToken]
        public async Task<IActionResult> FilterEmployee([FromBody] EmployeeFilterModel em)
        {
            ReponseModel r = new ReponseModel();
            DataTable data = await _context.FilterEmployee_(user_login,em);
            if (data.Rows.Count == 0)
            {
                r.status = "error";
                r.message = "employee not found";
                return Ok(r);
            }
            if (data.Rows.Count > 0)
            {
                r.status = "ok";
                r.message = "filter successful";
                r.data = data;
                return Ok(r);
            }

            return BadRequest("Error filter employee");
        }

        [HttpPost("[action]")]
        [SercurityToken]
        public async Task<IActionResult> FilterType([FromBody] TypeFilterModel t)
        {
            ReponseModel r = new ReponseModel();
            DataTable data = await _context.FilterType_(user_login,t);
            if (data.Rows.Count == 0)
            {
                r.status = "error";
                r.message = "employee type not found";
                return Ok(r);
            }
            if (data.Rows.Count > 0)
            {
                r.status = "ok";
                r.message = "filter successful";
                r.data = data;
                return Ok(r);
            }

            return BadRequest("Error filter employee type");
        }
        [HttpPost("[action]")]
        [SercurityToken]
        public async Task<IActionResult> FilterPosition([FromBody] PositionFilterModel p)
        {
            ReponseModel r = new ReponseModel();
            DataTable data = await _context.FilterPosition_(user_login,p);
            if (data.Rows.Count == 0)
            {
                r.status = "error";
                r.message = "employee position not found";
                return Ok(r);
            }
            if (data.Rows.Count > 0)
            {
                r.status = "ok";
                r.message = "filter successful";
                r.data = data;
                return Ok(r);
            }

            return BadRequest("Error filter employee position");
        }
        [HttpPost("[action]")]
        [SercurityToken]
        public async Task<IActionResult> FilterManager([FromBody] EmpManFilterModel em)
        {
            ReponseModel r = new ReponseModel();
            DataTable data = await _context.FilterManager_(user_login, em);
            if (data.Rows.Count == 0)
            {
                r.status = "error";
                r.message = "employee manager not found";
                return Ok(r);
            }
            if (data.Rows.Count > 0)
            {
                r.status = "ok";
                r.message = "filter successful";
                r.data = data;
                return Ok(r);
            }

            return BadRequest("Error filter employee manager");
        }

        [HttpPost("[action]")]
        [SercurityToken]
        public async Task<IActionResult> CreateEmployee([FromBody] EmployeeCreateModel e)
        {
            ReponseModel r = new ReponseModel();
            //if (e == null)
            //{
            //    r.status = "error";
            //    r.message = "please input employeee";
            //    return Ok(r);
            //};
            DataTable data = await _context.CreateEmployee_(user_login, e);
            if (data.Rows.Count > 0)
            {
                r.status = "ok";
                r.message = data.Rows[0]["NOTIFICATION"].ToString();
                r.data = data;
                return Ok(r);
            }
            return BadRequest("Error creating employee ");
        }
        
        [HttpPost("[action]")]
        [SercurityToken]
        public async Task<IActionResult> CreateType([FromBody] EmpTypeModel et)
        {
            ReponseModel r = new ReponseModel();
            if (et == null)
            {
                r.status = "error";
                r.message = "please input type";
                return Ok(r);
            };
            DataTable data = await _context.CreateType_(user_login, et);
            if (data.Rows.Count > 0)
            {
                r.status = "ok";
                r.message = data.Rows[0]["NOTIFICATION"].ToString();
                r.data = data;
                return Ok(r);
            }
            return BadRequest("Error creating employee type");
        }
        [HttpPost("[action]")]
        [SercurityToken]
        public async Task<IActionResult> CreatePosition([FromBody] EmpPositionModel ep)
        {
            ReponseModel r = new ReponseModel();
            if (ep == null)
            {
                r.status = "error";
                r.message = "please input position";
                return Ok(r);
            };
            DataTable data = await _context.CreatePosition_(user_login, ep);
            if (data.Rows.Count > 0)
            {
                r.status = "ok";
                r.message = data.Rows[0]["NOTIFICATION"].ToString();
                r.data = data;
                return Ok(r);
            }
            return BadRequest("Error creating employee position");
        }
        [HttpPost("[action]")]
        [SercurityToken]
        public async Task<IActionResult> CreateManager([FromBody] EmployeeManeger em)
        {
            ReponseModel r = new ReponseModel();
            if (em == null)
            {
                r.status = "error";
                r.message = "please input manager";
                return Ok(r);
            };
            DataTable data = await _context.CreateManager_(user_login, em);
            if (data.Rows.Count > 0)
            {
                r.status = "ok";
                r.message = data.Rows[0]["NOTIFICATION"].ToString();
                r.data = data;
                return Ok(r);
            }
            return BadRequest("Error creating employee manager");
        }

        [HttpPost("[action]")]
        [SercurityToken]
        public async Task<IActionResult> UpdateEmployee([FromBody] Employees e)
        {
            ReponseModel r = new ReponseModel();
            if (e == null)
            {
                r.status = "error";
                r.message = "please input employee";
                return Ok(r);
            };
            DataTable update = await _context.UpdateEmployee_(user_login, e);
            if (update.Rows.Count == 1)
            {
                r.status = "ok";
                r.message = "update successful";
                r.data = e;
                return Ok(r);
            }
            return BadRequest("Error update employee ");
        }

        [HttpPost("[action]")]
        [SercurityToken]
        public async Task<IActionResult> UpdateType([FromBody] EmpTypes et)
        {
            ReponseModel r = new ReponseModel();
            if (et == null)
            {
                r.status = "error";
                r.message = "please input position";
                return Ok(r);
            };
            DataTable updateposition = await _context.UpdateType_(user_login, et);
            if (updateposition.Rows.Count == 1)
            {
                r.status = "ok";
                r.message = "update successful";
                r.data = updateposition;
                return Ok(r);
            }
            return BadRequest("Error update employee position");
        }
    

        [HttpPost("[action]")]
        [SercurityToken]
        public async Task<IActionResult> UpdatePosition([FromBody] EmpPosition ep)
        {
            ReponseModel r = new ReponseModel();
            if (ep == null)
            {
                r.status = "error";
                r.message = "please input position";
                return Ok(r);
            };
            DataTable updateposition = await _context.UpdatePosition_(user_login, ep);
            if (updateposition.Rows.Count == 1)
            {
                r.status = "ok";
                r.message = "update successful";
                r.data = updateposition;
                return Ok(r);
            }
            return BadRequest("Error update employee position");
        }
        [HttpPost("[action]")]
        [SercurityToken]
        public async Task<IActionResult> DeletePosition([FromBody] EmpPositionDelete ep)
        {
            ReponseModel r = new ReponseModel();
            if (ep == null)
            {
                r.status = "error";
                r.message = "please input position";
                return Ok(r);
            };
            DataTable updateposition = await _context.DeletePosition_(user_login,ep);
            if (updateposition.Rows.Count == 1)
            {
                r.status = "ok";
                r.message = "deleted successful";
                r.data = updateposition;
                return Ok(r);
            }
            return BadRequest("Error deleted employee position");
        }
        [HttpPost("[action]")]
        [SercurityToken]
        public async Task<IActionResult> DeleteType([FromBody] EmpTypeDelete et)
        {
            ReponseModel r = new ReponseModel();
            if (et == null)
            {
                r.status = "error";
                r.message = "please input position";
                return Ok(r);
            };
            DataTable updateposition = await _context.DeleteType_(user_login, et);
            if (updateposition.Rows.Count == 1)
            {
                r.status = "ok";
                r.message = "deleted successful";
                r.data = updateposition;
                return Ok(r);
            }
            return BadRequest("Error deleted employee type");
        }
    }
}

