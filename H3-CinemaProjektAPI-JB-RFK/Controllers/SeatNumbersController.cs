using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using H3_CinemaProjektAPI_JB_RFK.DataBase;
using H3_CinemaProjektAPI_JB_RFK.Model;

namespace H3_CinemaProjektAPI_JB_RFK.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeatNumbersController : ControllerBase
    {
        private readonly DataBaseContext _context;

        public SeatNumbersController(DataBaseContext context)
        {
            _context = context;
        }

        // GET: api/SeatNumbers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SeatNumber>>> GetSeatNumber()
        {
            return await _context.SeatNumber.ToListAsync();
        }

        // GET: api/SeatNumbers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SeatNumber>> GetSeatNumber(int id)
        {
            var seatNumber = await _context.SeatNumber.FindAsync(id);

            if (seatNumber == null)
            {
                return NotFound();
            }

            return seatNumber;
        }

        // PUT: api/SeatNumbers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSeatNumber(int id, SeatNumber seatNumber)
        {
            if (id != seatNumber.SeatNumberId)
            {
                return BadRequest();
            }

            _context.Entry(seatNumber).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SeatNumberExists(id))
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

        // POST: api/SeatNumbers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SeatNumber>> PostSeatNumber(SeatNumber seatNumber)
        {
            _context.SeatNumber.Add(seatNumber);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSeatNumber", new { id = seatNumber.SeatNumberId }, seatNumber);
        }

        // DELETE: api/SeatNumbers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSeatNumber(int id)
        {
            var seatNumber = await _context.SeatNumber.FindAsync(id);
            if (seatNumber == null)
            {
                return NotFound();
            }

            _context.SeatNumber.Remove(seatNumber);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SeatNumberExists(int id)
        {
            return _context.SeatNumber.Any(e => e.SeatNumberId == id);
        }
    }
}
