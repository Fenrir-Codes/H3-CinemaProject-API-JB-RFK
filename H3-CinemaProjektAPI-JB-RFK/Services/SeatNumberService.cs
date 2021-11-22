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

        #region create seatnumber
        public async Task<SeatNumber> CreateSeat(SeatNumber seatNumber)
        {
            return await context.CreateSeat(seatNumber);
        }
        #endregion

        #region update seatnumber
        public async Task<SeatNumber> UpdateSeatnumber(int id, SeatNumber data)
        {
            return await context.UpdateSeatnumber(id, data);
        }
        #endregion

        #region delete seatnumber (id)
        public async Task<bool> DeleteSeat(int Id)
        {
            var temp = await context.DeleteSeat(Id);
            return temp != null;
        }
        #endregion

        #region get all seat numbers
        public async Task<List<SeatNumber>> GetAllSeatNumbers()
        {
            return await context.GetAllSeatNumbers();
        }
        #endregion

        #region get seatnumber (id)
        public async Task<SeatNumber> GetSeatNumber(int Id)
        {
            return await context.GetSeatNumber(Id);
        }
        #endregion
    }
}
