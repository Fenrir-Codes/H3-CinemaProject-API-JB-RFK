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
    public class DirectorsRepositories : IDirectorsRepositories
    {
        private readonly DataBaseContext context;

        public DirectorsRepositories(DataBaseContext _context)
        {
            context = _context;
        }

        public async Task<Directors> CreateDirector(Directors directors)
        {
            context.Directors.Add(directors);
            await context.SaveChangesAsync();
            return directors;
        }

        public async Task<Directors> DeleteDirector(int Id)
        {
            var director = context.Directors.Find(Id);
            if (director != null)
            {
                context.Directors.Remove(director);
                await context.SaveChangesAsync();
            }
            return director;
        }

        public async Task<List<Directors>> GetAllDirectors()
        {
            List<Directors> directorList = await context.Directors.ToListAsync();
            return directorList;
        }

        public async Task<Directors> GetDirector(int Id)
        {
            return await context.Directors.FindAsync(Id);
        }
    }
}
