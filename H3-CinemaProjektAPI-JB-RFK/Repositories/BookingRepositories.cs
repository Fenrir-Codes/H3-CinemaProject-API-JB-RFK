using H3_CinemaProjektAPI_JB_RFK.DataBase;
using H3_CinemaProjektAPI_JB_RFK.Interfaces;
using H3_CinemaProjektAPI_JB_RFK.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace H3_CinemaProjektAPI_JB_RFK.Repositories
{
    public class BookingRepositories : IBookingRepositories
    {
        private readonly DataBaseContext context;

        public BookingRepositories(DataBaseContext _context)
        {
            context = _context;
        }

        //getting the booking (all)
        public async Task<ActionResult<IEnumerable<Booking>>> GetBooking()
        {
            return await context.Booking.ToListAsync();
        }

        //getting the booking with id
        public async Task<List<Booking>> GetBooking(int id)
        {
            return await context.Booking.Where(i => i.BookingId == id).ToListAsync();
        }

        //create booking data
        public async Task<Booking> CreateBooking(Booking data)
        {
            context.Booking.Add(data);
            await context.SaveChangesAsync();
            return data;
        }


    }
}
