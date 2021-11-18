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

        public async Task<Hall> CreateHall(Hall hall)
        {
            context.Hall.Add(hall);
            await context.SaveChangesAsync();
            return hall;
        }

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

        public async Task<List<Hall>> GetAllHalls()
        {
            List<Hall> hallList = await context.Hall.ToListAsync();
            return hallList;
        }

        public async Task<Hall> GetHall(int Id)
        {
            return await context.Hall.FindAsync(Id);
        }
    }
}
