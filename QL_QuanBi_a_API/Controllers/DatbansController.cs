using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QL_QuanBi_a_API.Models;

namespace QL_QuanBi_a_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DatbansController : ControllerBase
    {
        private readonly QlBidaContext _context;

        public DatbansController(QlBidaContext context)
        {
            _context = context;
        }

        //GET: api/Bans
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Datban>>> GetDatBan()
        {
            return await _context.Datbans.ToListAsync();
        }

        //"madatban": 0,
        //"tenkh": "string",
        //"sdt": "string",
        //"ghichu": "string",
        //"trangthai": true,
        //"thoigianden": "2024-07-28T16:23:08.913Z",
        //"maban": 0,

        // Bước 1: Tạo đặt bàn
        // POST: api/Datbans
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        public class _Datban
        {
            public string Tenkh { get; set; }
            public string Sdt { get; set; }
            public string Ghichu { get; set; }
            public DateTime Thoigianden { get; set; }
            public int Maban { get; set; }
        }

        [HttpPost]
        public async Task<ActionResult<Datban>> PostDatban(_Datban _db)
        {
            Datban db = new Datban();

            db.Madatban = 0; //tự tăng
            db.Tenkh = _db.Tenkh;
            db.Sdt = _db.Sdt;
            db.Ghichu = _db.Ghichu;
            db.Trangthai = false; // trạng thái của đơn đặt bàn false chưa đến
            db.Thoigianden = _db.Thoigianden;
            db.Maban = _db.Maban;
            db.MabanNavigation = null;

            _context.Datbans.Add(db);

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDatban", new { id = db.Madatban }, db);
        }

        private bool DatbanExists(int id)
        {
            return _context.Datbans.Any(e => e.Madatban == id);
        }
    }
}
