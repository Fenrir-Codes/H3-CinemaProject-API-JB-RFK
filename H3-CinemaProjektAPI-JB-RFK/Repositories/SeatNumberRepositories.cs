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

        public async Task<List<SeatNumber>> GetAllSeatNumbers()
        {
            List<SeatNumber> seatNumberList = await context.SeatNumber.ToListAsync();
            return seatNumberList;
        }

        public async Task<SeatNumber> GetSeatNumber(int Id)
        {
            return await context.SeatNumber.FindAsync(Id);
        }
    }
}
