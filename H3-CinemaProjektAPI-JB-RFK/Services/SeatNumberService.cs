using H3_CinemaProjektAPI_JB_RFK.Interfaces;
using H3_CinemaProjektAPI_JB_RFK.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace H3_CinemaProjektAPI_JB_RFK.Services
{
    public class SeatNumberService : ISeatNumberService
    {
        private readonly ISeatNumberRepositories context;

        public SeatNumberService(ISeatNumberRepositories _context)
        {
            context = _context;
        }

        public async Task<List<SeatNumber>> GetAllSeatNumbers()
        {
            return await context.GetAllSeatNumbers();
        }

        public async Task<SeatNumber> GetSeatNumber(int Id)
        {
            return await context.GetSeatNumber(Id);
        }
    }
}
