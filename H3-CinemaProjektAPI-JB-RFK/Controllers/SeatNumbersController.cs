using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using H3_CinemaProjektAPI_JB_RFK.DataBase;
using H3_CinemaProjektAPI_JB_RFK.Model;
using H3_CinemaProjektAPI_JB_RFK.Interfaces;

namespace H3_CinemaProjektAPI_JB_RFK.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeatNumbersController : ControllerBase
    {
        private readonly ISeatNumberService _context;

        public SeatNumbersController(ISeatNumberService context)
        {
            _context = context;
        }

        #region get all seatnumbers
        [HttpGet("GetAllSeatNumbers")]
        public async Task<ActionResult> GetAllSeatNumbers()
        {
            try
            {
                List<SeatNumber> seatList = await _context.GetAllSeatNumbers();
                if (seatList == null)
                {
                    return Problem("Nothing was returned");
                }
                if (seatList.Count == 0)
                {
                    return NoContent(); // 204
                }
                return Ok(seatList);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }
        #endregion

        #region get seatnumber (id)
        // GET: api/SeatNumbers
        [HttpGet("{Id}")]
        public async Task<ActionResult<IEnumerable<SeatNumber>>> GetSeatNumber(int Id)
        {
            return Ok(await _context.GetSeatNumber(Id));
        }
        #endregion

        #region create seatnumber
        // POST: api/SeatNumbers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SeatNumber>> PostSeatNumber(SeatNumber seatNumber)
        {
            return await _context.CreateSeat(seatNumber);
            //await _context.SaveChangesAsync();

            //return CreatedAtAction("GetSeatNumber", new { id = seatNumber.SeatNumberId }, seatNumber);
        }
        #endregion

        #region update seatnumber
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateSeatnumber(int id, SeatNumber data)
        {
            if (id != data.SeatNumberId)
            {
                return BadRequest("ID mismatch!");
            }

            try
            {
                await _context.UpdateSeatnumber(id, data);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message);
            }

        }
        #endregion

        #region delete seatnumber (id)
        // DELETE: api/SeatNumbers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSeatNumber(int id)
        {
            try
            {
                bool result = await _context.DeleteSeat(id);
                if (!result)
                {
                    return Problem("Seatnumber was not deleted, something went wrong");
                }
                return NoContent();
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }
        #endregion



        #region commented out code
        //        // GET: api/SeatNumbers/5
        //        [HttpGet("{id}")]
        //        public async Task<ActionResult<SeatNumber>> GetSeatNumber(int id)
        //        {
        //            var seatNumber = await _context.SeatNumber.FindAsync(id);

        //            if (seatNumber == null)
        //            {
        //                return NotFound();
        //            }

        //            return seatNumber;
        //        }

        //        // PUT: api/SeatNumbers/5
        //        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //        [HttpPut("{id}")]
        //        public async Task<IActionResult> PutSeatNumber(int id, SeatNumber seatNumber)
        //        {
        //            if (id != seatNumber.SeatNumberId)
        //            {
        //                return BadRequest();
        //            }

        //            _context.Entry(seatNumber).State = EntityState.Modified;

        //            try
        //            {
        //                await _context.SaveChangesAsync();
        //            }
        //            catch (DbUpdateConcurrencyException)
        //            {
        //                if (!SeatNumberExists(id))
        //                {
        //                    return NotFound();
        //                }
        //                else
        //                {
        //                    throw;
        //                }
        //            }

        //            return NoContent();
        //        }


        //        private bool SeatNumberExists(int id)
        //        {
        //            return _context.SeatNumber.Any(e => e.SeatNumberId == id);
        //        }
        #endregion
    }
}
