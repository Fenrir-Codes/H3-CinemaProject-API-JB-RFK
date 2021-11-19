using H3_CinemaProjektAPI_JB_RFK.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace H3_CinemaProjektAPI_JB_RFK.Interfaces
{
    public interface ISeatNumberService
    {
        Task<SeatNumber> GetSeatNumber(int Id);

        Task<List<SeatNumber>> GetAllSeatNumbers();

        Task<bool> DeleteSeat(int Id);

        Task<SeatNumber> CreateSeat(SeatNumber seatNumber);

        Task<SeatNumber> UpdateSeatnumber(int id, SeatNumber data);

    }
}
