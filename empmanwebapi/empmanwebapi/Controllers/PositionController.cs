using empmanwebapi.Data;
using empmanwebapi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace empmanwebapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionController : Controller
    {
        private readonly PositionDbContext _context;
        public PositionController(PositionDbContext context)
        {
            _context = context;
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllPosition()
        {
            DataTable data = await _context.GetAllPosition_();
            if (data.Rows.Count > 0)
            {
                return Ok(data);
            }
            return BadRequest("no position created");
        }
        [HttpPost("[action]")]
        [Authorize]
        public async Task<IActionResult> CreatePosition([FromBody] Position position)
        {
            if (position == null) { return BadRequest(); }
            DataTable data = await _context.CreatePosition_(position);
            if (data.Rows.Count > 0)
            {

                return Ok(data);
            }

            return BadRequest("Error creating position");
        }
    }
}
