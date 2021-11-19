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

        #region delete booking
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
        #endregion

        #region get all bookings
        public async Task<List<Booking>> GetAllBookings()
        {
            List<Booking> bookingList = await context.Booking.ToListAsync();
            return bookingList;
        }
        #endregion

        #region get booking (id)
        public async Task<Booking> GetBooking(int Id)
        {
            return await context.Booking.FindAsync(Id);
        }
        #endregion

        #region crete booking
        //create booking data
        public async Task<Booking> CreateBooking(Booking booking)
        {
            context.Booking.Add(booking);
            await context.SaveChangesAsync();
            return booking;
        }
        #endregion

        #region update booking
        public async Task<Booking> UpdateBooking(int id, Booking data)
        {
            var findBooking = await context.Booking.Where(b => b.BookingId == id).FirstOrDefaultAsync();
            if (findBooking != null)
            {
                findBooking.BookingId = data.BookingId;
                findBooking.ProfileId = data.ProfileId;
                findBooking.MovieId = data.MovieId;
                findBooking.PaymentId = data.PaymentId;
                findBooking.SeatNumberId = data.SeatNumberId;
                findBooking.HallId = data.HallId;
                findBooking.DiscountCoupon = data.DiscountCoupon;
                findBooking.NumberOfSeats = data.NumberOfSeats;
                findBooking.OrderDate = data.OrderDate;
                findBooking.TimeStamp = data.TimeStamp;

                context.Entry(findBooking).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return findBooking;
            }
            return null;

        }
        #endregion
    }
}
