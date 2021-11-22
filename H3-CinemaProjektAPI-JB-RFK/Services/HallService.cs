using H3_CinemaProjektAPI_JB_RFK.Interfaces;
using H3_CinemaProjektAPI_JB_RFK.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace H3_CinemaProjektAPI_JB_RFK.Services
{
    public class HallService : IHallService
    {
        private readonly IHallRepositories context;

        public HallService(IHallRepositories _context)
        {
            context = _context;
        }

        #region create hall
        public async Task<Hall> CreateHall(Hall hall)
        {
            return await context.CreateHall(hall);
        }
        #endregion

        #region update hall
        public async Task<Hall> UpdateHall(int id, Hall data)
        {
            return await context.UpdateHall(id, data);
        }

        #endregion

        #region delete hall (id)
        public async Task<bool> DeleteHall(int Id)
        {
            var temp = await context.DeleteHall(Id);
            return temp != null;
        }
        #endregion

        #region get all halls
        public async Task<List<Hall>> GetAllHalls()
        {
            return await context.GetAllHalls();
        }
        #endregion

        #region get hall (id)
        public async Task<Hall> GetHall(int Id)
        {
            return await context.GetHall(Id);
        }
        #endregion
    }
}
