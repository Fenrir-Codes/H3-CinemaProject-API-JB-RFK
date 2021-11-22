using H3_CinemaProjektAPI_JB_RFK.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace H3_CinemaProjektAPI_JB_RFK.Interfaces
{
    public interface IBookingRepositories
    {
        Task<Booking> GetBooking(int Id);

        Task<List<Booking>> GetAllBookings();

        Task<Booking> DeleteBooking(int Id);

        Task<Booking> CreateBooking(Booking booking);

        Task<Booking> UpdateBooking(int id, Booking data);



    }
}
