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

        public async Task<bool> DeleteHall(int Id)
        {
            var temp = await context.DeleteHall(Id);
            return temp != null;
        }

        public async Task<List<Hall>> GetAllHalls()
        {
            return await context.GetAllHalls();
        }

        public async Task<Hall> GetHall(int Id)
        {
            return await context.GetHall(Id);
        }
    }
}
