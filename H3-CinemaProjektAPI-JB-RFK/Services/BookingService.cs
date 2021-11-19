using H3_CinemaProjektAPI_JB_RFK.Interfaces;
using H3_CinemaProjektAPI_JB_RFK.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace H3_CinemaProjektAPI_JB_RFK.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepositories context;

        public BookingService(IBookingRepositories _context)
        {
            context = _context;
        }

        #region create booking
        public async Task<Booking> CreateBooking(Booking booking)
        {
            return await context.CreateBooking(booking);
        }
        #endregion

        #region update booking
        public async Task<Booking> UpdateBooking(int id, Booking data)
        {
            return await context.UpdateBooking(id, data);
        }
        #endregion

        #region delete booking (id
        public async Task<bool> DeleteBooking(int Id)
        {
            var temp = await context.DeleteBooking(Id);
            return temp != null;
        }
        #endregion

        #region get all bookings
        public async Task<List<Booking>> GetAllBookings()
        {
            return await context.GetAllBookings();
        }
        #endregion

        #region get booking (id)
        public async Task<Booking> GetBooking(int Id)
        {
            return await context.GetBooking(Id);
        }
        #endregion
    }
}
