using H3_CinemaProjektAPI_JB_RFK.DataBase;
using H3_CinemaProjektAPI_JB_RFK.Interfaces;
using H3_CinemaProjektAPI_JB_RFK.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace H3_CinemaProjektAPI_JB_RFK.Repositories
{
    public class SeatNumberRepositories : ISeatNumberRepositories
    {
        private readonly DataBaseContext context;

        public SeatNumberRepositories(DataBaseContext _context)
        {
            context = _context;
        }

        #region create seat
        public async Task<SeatNumber> CreateSeat(SeatNumber seatNumber)
        {
            context.SeatNumber.Add(seatNumber);
            await context.SaveChangesAsync();
            return seatNumber;
        }
        #endregion

        #region update seatnumber
        public async Task<SeatNumber> UpdateSeatnumber(int id, SeatNumber data)
        {
            var findSeat = await context.SeatNumber.Where(sn => sn.SeatNumberId == id).FirstOrDefaultAsync();
            if (findSeat != null)
            {
                findSeat.SeatNumberId = data.SeatNumberId;
                findSeat.SeatRow = data.SeatRow;
                findSeat.SeatColumn = data.SeatColumn;

                context.Entry(findSeat).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return findSeat;
            }
            return null;

        }
        #endregion

        #region delete seat (id)
        public async Task<SeatNumber> DeleteSeat(int Id)
        {
            var seatnumb = context.SeatNumber.Find(Id);
            if (seatnumb != null)
            {
                context.SeatNumber.Remove(seatnumb);
                await context.SaveChangesAsync();
            }
            return seatnumb;
        }
        #endregion

        #region get all seats
        public async Task<List<SeatNumber>> GetAllSeatNumbers()
        {
            List<SeatNumber> seatNumberList = await context.SeatNumber.ToListAsync();
            return seatNumberList;
        }
        #endregion

        #region get seat (id)
        public async Task<SeatNumber> GetSeatNumber(int Id)
        {
            return await context.SeatNumber.FindAsync(Id);
        }
        #endregion
    }
}
