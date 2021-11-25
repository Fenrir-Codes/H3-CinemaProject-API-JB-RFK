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
    public class HallRepositories :IHallRepositories
    {
        private readonly DataBaseContext context;

        public HallRepositories(DataBaseContext _context)
        {
            context = _context;
        }

        #region create hall
        public async Task<Hall> CreateHall(Hall hall)
        {
            context.Hall.Add(hall);
            await context.SaveChangesAsync();
            return hall;
        }
        #endregion

        #region update hall
        public async Task<Hall> UpdateHall(int id, Hall data)
        {
            var findHall = await context.Hall.Where(h => h.HallId == id).FirstOrDefaultAsync();
            if (findHall != null)
            {
                findHall.HallId = data.HallId;
                findHall.HAllName = data.HAllName;
                findHall.SeatNumberId = data.SeatNumberId;
                findHall.SeatNumbers = data.SeatNumbers;

                context.Entry(findHall).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return findHall;
            }
            return null;

        }
        #endregion

        #region delete hall (id)
        public async Task<Hall> DeleteHall(int Id)
        {
            var hall = context.Hall.Find(Id);
            if (hall != null)
            {
                context.Hall.Remove(hall);
                await context.SaveChangesAsync();
            }
            return hall;
        }
        #endregion

        #region get all hall
        public async Task<List<Hall>> GetAllHalls()
        {
            List<Hall> hallList = await context.Hall.ToListAsync();
            return hallList;
        }
        #endregion

        #region get hall (id)
        public async Task<Hall> GetHall(int Id)
        {
            return await context.Hall.FindAsync(Id);
        }
        #endregion
    }
}
