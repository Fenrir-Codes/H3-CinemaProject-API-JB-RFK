using H3_CinemaProjektAPI_JB_RFK.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace H3_CinemaProjektAPI_JB_RFK.Interfaces
{
    public interface ISeatNumberRepositories
    {
        Task<SeatNumber> GetSeatNumber(int Id);
        Task<List<SeatNumber>> GetAllSeatNumbers();
    }
}
