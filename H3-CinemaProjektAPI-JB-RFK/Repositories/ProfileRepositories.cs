using H3_CinemaProjektAPI_JB_RFK.DataBase;
using H3_CinemaProjektAPI_JB_RFK.DTO;
using H3_CinemaProjektAPI_JB_RFK.Interfaces;
using H3_CinemaProjektAPI_JB_RFK.Model;
using Microsoft.AspNetCore.Mvc;
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

        //getting the profiles (all)
        public async Task<ActionResult<IEnumerable<Profile>>> GetProfile()
        {
            return await context.Profile.ToListAsync();
        }

        //getting the profile with id
        public async Task<Profile> GetProfile(int id)
        {
            return await context.Profile.FindAsync(id);
        }

        //create profile data
        public async Task<Profile> CreateProfile(Profile data)
        {
            context.Profile.Add(data);
            await context.SaveChangesAsync();
            return data;
        }

        //Login
        public async Task<List<ProfileResponse>> Login(string mail, string password)
        {
            var profile = await context.Profile.Where(e => e.Email == mail && e.Password == password).ToListAsync();
            return profile.Select(obj => new ProfileResponse
            {
                ProfileId = obj.ProfileId,
                Email = obj.Email,
                Firstname = obj.Firstname,
                Lastname = obj.Lastname,
                Address = obj.Address,
                Phone = obj.Phone,
                Role = obj.Role

            }).ToList();
    
          
        }
    }
}
