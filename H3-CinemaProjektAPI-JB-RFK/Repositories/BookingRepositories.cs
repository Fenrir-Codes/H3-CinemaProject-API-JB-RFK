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

        public async Task<Booking> DeleteBooking(int Id)
        {
            var booking = context.Booking.Find(Id);
            if (booking != null)
            {
                context.Booking.Remove(booking);
                await context.SaveChangesAsync();
            }
            return booking;
        }

        public async Task<List<Booking>> GetAllBookings()
        {
            List<Booking> bookingList = await context.Booking.ToListAsync();
            return bookingList;
        }

        public async Task<Booking> GetBooking(int Id)
        {
            return await context.Booking.FindAsync(Id);
        }

        //create booking data
        public async Task<Booking> CreateBooking(Booking booking)
        {
            context.Booking.Add(booking);
            await context.SaveChangesAsync();
            return booking;
        }


    }
}
