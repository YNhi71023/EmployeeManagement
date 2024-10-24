using empmanwebapi.CORE;
using empmanwebapi.Data;
using empmanwebapi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using storeworkingapi.Models;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace empmanwebapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly UsersDbContext _context;
        public UsersController(UsersDbContext context, IConfiguration configuration)
        {
            _context = context;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllUser()
        {
            DataTable data = await _context.GetAllUser_();
            if (data.Rows.Count > 0)
            {
                return Ok(data);
            }
            return BadRequest("no user created");
        }
        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteUser(int user_id)
        {
            try
            {
                bool isDeleted = await _context.DeleteUser_(user_id);

                if (isDeleted)
                {
                    return Ok(new { message = "User deleted successfully" });
                }
                else
                {
                    return NotFound(new { message = "User not found" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred", error = ex.Message });
            }
        }

    }
}
