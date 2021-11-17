using H3_CinemaProjektAPI_JB_RFK.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace H3_CinemaProjektAPI_JB_RFK.Interfaces
{
    public interface IBookingService
    {
        Task<Booking> GetBooking(int Id);
        Task<List<Booking>> GetAllBookings();
        Task<bool> DeleteBooking(int Id);

    }
}
