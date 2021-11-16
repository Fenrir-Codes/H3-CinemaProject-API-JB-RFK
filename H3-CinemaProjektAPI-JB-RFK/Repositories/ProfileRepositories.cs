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
    public class ProfileRepositories  : IProfileRepositories 
    {
        private readonly DataBaseContext context;

        public ProfileRepositories(DataBaseContext _context)
        {
            context = _context;
        }

        public async Task<Profile> GetProfile(int Id)
        {
            return await context.Profile.FindAsync(Id);
        }

        //Login
        public async Task<List<Profile>> Login(string Email, string password)
        {
            //var profile = await context.Profile.Where(e => e.Email == Email && e.Password == password).ToListAsync();            

            return await context.Profile.Where(e => e.Email == Email && e.Password == password).ToListAsync();

        }
    }
}
