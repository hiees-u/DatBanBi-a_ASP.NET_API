using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QL_QuanBi_a_API.Models;

namespace QL_QuanBi_a_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BansController : ControllerBase
    {
        private readonly QlBidaContext _context;

        public BansController(QlBidaContext context)
        {
            _context = context;
        }


        //lấy tât cả bàn
        // GET: api/Bans
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ban>>> GetBans()
        {
            return await _context.Bans.ToListAsync();
        }

        // GET: api/Bans/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ban>> GetBan(int id)
        {
            var ban = await _context.Bans.FindAsync(id);

            if (ban == null)
            {
                return NotFound();
            }

            return ban;
        }

        // PUT: api/Bans/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBan(int id, Ban ban)
        {
            if (id != ban.Maban)
            {
                return BadRequest();
            }

            _context.Entry(ban).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BanExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        private bool BanExists(int id)
        {
            return _context.Bans.Any(e => e.Maban == id);
        }
    }
}
