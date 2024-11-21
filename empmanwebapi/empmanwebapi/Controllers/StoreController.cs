using empmanwebapi.CORE;
using empmanwebapi.Data;
using empmanwebapi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using storeworkingapi.Models;
using System.Data;

namespace empmanwebapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class StoreController:APIController
    {
        private readonly StoreDbContext _context;
        public StoreController(StoreDbContext context)
        {
            _context = context;
        }
        [HttpPost("[action]")]
        [SercurityToken]
        public async Task<IActionResult> FilterLocation([FromBody] LocationFilter l)
        {
            ReponseModel r = new ReponseModel();
            DataTable data = await _context.FilterLocation_(user_login, l);
            if (data.Rows.Count == 0)
            {
                r.status = "error";
                r.message = "location not found";
                return Ok(r);
            }
            if (data.Rows.Count > 0)
            {
                r.status = "ok";
                r.message = "filter successful";
                r.data = data;
                return Ok(r);
            }

            return BadRequest("Error filter location");
        }
        [HttpPost("[action]")]
        [SercurityToken]
        public async Task<IActionResult> FilterLocationType([FromBody] LocationType t)
        {
            ReponseModel r = new ReponseModel();
            DataTable data = await _context.FilterLocationType_(user_login, t);
            if (data.Rows.Count == 0)
            {
                r.status = "error";
                r.message = "location type not found";
                return Ok(r);
            }
            if (data.Rows.Count > 0)
            {
                r.status = "ok";
                r.message = "filter successful";
                r.data = data;
                return Ok(r);
            }

            return BadRequest("Error filter location type");
        }
        [HttpPost("[action]")]
        [SercurityToken]
        public async Task<IActionResult> CreateLocationType([FromBody] LocationType l)
        {
            ReponseModel r = new ReponseModel();
            if (l == null)
            {
                r.status = "error";
                r.message = "please input Location type";
                return Ok(r);
            };
            DataTable data = await _context.CreateLocationType_(user_login, l);
            if (data.Rows.Count > 0)
            {
                r.status = "ok";
                r.message = data.Rows[0]["NOTIFICATION"].ToString();
                r.data = data;
                return Ok(r);
            }
            return BadRequest("Error creating Location type");
        }
        [HttpPost("[action]")]
        [SercurityToken]
        public async Task<IActionResult> UpdateLocationType([FromBody] LocationTypeUpdate l)
        {
            ReponseModel r = new ReponseModel();
            if (l == null)
            {
                r.status = "error";
                r.message = "please input Location type";
                return Ok(r);
            };
            DataTable update = await _context.UpdateLocationType_(user_login, l);
            if (update.Rows.Count == 1)
            {
                r.status = "ok";
                r.message = "update successful";
                r.data = l;
                return Ok(r);
            }
            return BadRequest("Error update Location type ");
        }
    }
    
}
