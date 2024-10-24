using empmanwebapi.CORE;
using empmanwebapi.Data;
using empmanwebapi.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace empmanwebapi.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("empmanweb_angular")]
    [ApiController]
    public class AccountsController : Controller
    {
        private readonly AccountDbContext _context;
        public AccountsController(AccountDbContext context, IConfiguration configuration)
        {
            _context = context;
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterModel account)
        {
            if (account == null) return BadRequest();


            DataTable data = await _context.RegisterAccountAsync_(account);

            if (data.Rows.Count > 0)
            {

                return Ok(data);
            }

            return BadRequest("Error creating account");
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> LoginAccount(LoginModel account)
        {
            ReponseModel r = new ReponseModel();
            if (account.username == "" || account.password == "")
            {
                r.status = "error";
                r.message = "please input account";
                return Ok(r);
            }

            DataTable data = await _context.LoginAccount_(account);
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
                p.account_id = Convert.ToInt32(data.Rows[0]["account_id"].ToString());
                p.username = data.Rows[0]["username"].ToString();
                string token = Security.GenerateJwtToken(p.account_id, p.username);
                p.token = "Bearer " + token;
                r.data = p;
                return Ok(r);
            }

            return BadRequest("Error creating acccount");
        }

    }
}
