using Dapper;
using empmanwebapi.Data;
using empmanwebapi.Models;
using empmanwebapi.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace empmanwebapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IJWTAuthManager _authentication;

        public AccountController(IJWTAuthManager authentication)
        {
            _authentication = authentication;
        }
        private readonly UsersDbContext _context;
        public AccountController(UsersDbContext context)
        {
            _context = context;
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public IActionResult login([FromBody] LoginModel user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Parameter is missing");
            }

            DynamicParameters dp_param = new DynamicParameters();
            dp_param.Add("email", user.UserName, DbType.String);
            dp_param.Add("password", user.Password, DbType.String);
            dp_param.Add("retVal", DbType.String, direction: ParameterDirection.Output);
            var result = _authentication.Execute_Command<Users>("[dbo].[LoginUser]", dp_param);
            if (result.code == 200)
            {
                var token = _authentication.GenerateJWT(result.Data);
                return Ok(token);
            }
            return NotFound(result.Data);
        }

        [HttpGet("UserList")]
        [AllowAnonymous]
        public async Task<IActionResult> getAllUsers()
        {

            DataTable data = await _context.GetAllUser_();

            if (data.Rows.Count > 0)
            {
                return Ok(data);
            }

            return BadRequest("Error creating employee");
        }

        [HttpPost("Register")]
        public IActionResult Register([FromBody] Users user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Parameter is missing");
            }

            DynamicParameters dp_param = new DynamicParameters();
            dp_param.Add("email", user.email, DbType.String);
            dp_param.Add("username", user.user_name, DbType.String);
            dp_param.Add("password", user.password, DbType.String);
            dp_param.Add("role", user.role, DbType.String);
            dp_param.Add("retVal", DbType.String, direction: ParameterDirection.Output);
            var result = _authentication.Execute_Command<Users>("[dbo].[RegisterUser]", dp_param);
            if (result.code == 200)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("Delete")]
        [Authorize(Roles = "admin")]
        public IActionResult Delete(string id)
        {
            if (id == string.Empty)
            {
                return BadRequest("Parameter is missing");
            }

            DynamicParameters dp_param = new DynamicParameters();
            dp_param.Add("userid", id, DbType.String);

            dp_param.Add("retVal", DbType.String, direction: ParameterDirection.Output);
            var result = _authentication.Execute_Command<Users>("[dbo].[DeleteUser]", dp_param);
            if (result.code == 200)
            {
                return Ok(result);
            }
            return NotFound(result);
        }
    }
}
