﻿using System;
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
    public class BookingsController : ControllerBase
    {
      //  private readonly DataBaseContext _context;

        private readonly IBookingService _context;

        public BookingsController(IBookingService context)
        {
            _context = context;

        }

        // GET: api/Bookings
        [HttpGet]
        public async Task<ActionResult<Booking>> GetBooking(int Id)
        {
            return Ok(await _context.GetBooking(Id));
        }

        [HttpGet("GetAllBookings")]
        public async Task<ActionResult> GetAllBookings()
        {
            try
            {
                List<Booking> bookingList = await _context.GetAllBookings();
                if (bookingList == null)
                {
                    return Problem("Der kom ikke noget");
                }
                if (bookingList.Count == 0)
                {
                    return NoContent(); // 204
                }
                return Ok(bookingList);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        //    // GET: api/Bookings/5
        //    [HttpGet("{id}")]
        //    public async Task<ActionResult<Booking>> GetBooking(int id)
        //    {
        //        var booking = await _context.Booking.FindAsync(id);

        //        if (booking == null)
        //        {
        //            return NotFound();
        //        }

        //        return booking;
        //    }

        //    // PUT: api/Bookings/5
        //    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //    [HttpPut("{id}")]
        //    public async Task<IActionResult> PutBooking(int id, Booking booking)
        //    {
        //        if (id != booking.BookingId)
        //        {
        //            return BadRequest();
        //        }

        //        _context.Entry(booking).State = EntityState.Modified;

        //        try
        //        {
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!BookingExists(id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }

        //        return NoContent();
        //    }

        //    // POST: api/Bookings
        //    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //    [HttpPost]
        //    public async Task<ActionResult<Booking>> PostBooking(Booking booking)
        //    {
        //        _context.Booking.Add(booking);
        //        await _context.SaveChangesAsync();

        //        return CreatedAtAction("GetBooking", new { id = booking.BookingId }, booking);
        //    }

        //    // DELETE: api/Bookings/5
        //    [HttpDelete("{id}")]
        //    public async Task<IActionResult> DeleteBooking(int id)
        //    {
        //        var booking = await _context.Booking.FindAsync(id);
        //        if (booking == null)
        //        {
        //            return NotFound();
        //        }

        //        _context.Booking.Remove(booking);
        //        await _context.SaveChangesAsync();

        //        return NoContent();
        //    }

        //    private bool BookingExists(int id)
        //    {
        //        return _context.Booking.Any(e => e.BookingId == id);
        //    }
    }
}
