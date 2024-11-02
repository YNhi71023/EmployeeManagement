using empmanwebapi.CORE;
using empmanwebapi.Data;
using empmanwebapi.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using storeworkingapi.Models;
using System.Data;

namespace empmanwebapi.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("empmanweb_angular")]
    [ApiController]
    public class UsersController : APIController
    {
        private readonly UsersDbContext _context;
        public UsersController(UsersDbContext context)
        {
            _context = context;
        }

        [HttpPost("[action]")]
        [SercurityToken]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserModel u)
        {
            ReponseModel r = new ReponseModel();
            if (u == null)
            {
                r.status = "error";
                r.message = "please input position";
                return Ok(r);
            };
            DataTable data = await _context.CreateUser(user_login, u);
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
        public async Task<IActionResult> LoginUser(LoginModel u)
        {
            ReponseModel r = new ReponseModel();
            if (u.username == "" || u.password == "")
            {
                r.status = "error";
                r.message = "please input account";
                return Ok(r);
            }

            DataTable data = await _context.LoginUser(u);
            if (data.Rows.Count == 0)
            {
                r.status = "error";
                r.message = "username or password incorrect";
                return Ok(r);
            }

            if (data.Rows.Count > 0)
            {
                r.status = "ok";
                r.message = "login successful";
                reponseLogin p = new reponseLogin();
              
                p.employee_id = Convert.ToInt32( data.Rows[0]["employee_id"].ToString());
                p.employee_name = data.Rows[0]["employee_name"].ToString();
                p.employee_type_id = Convert.ToInt32(data.Rows[0]["employee_type_id"].ToString());
                p.position_id = Convert.ToInt32(data.Rows[0]["position_id"].ToString());

                string token = Security.GenerateJwtToken(p.employee_id,u.username,p.employee_type_id, p.position_id);
                p.token = "Bearer " + token;
                r.data = p;
                return Ok(r);
            }

            return BadRequest("Error creating acccount");
        }

    }
}
