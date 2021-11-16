using H3_CinemaProjektAPI_JB_RFK.DTO;
using H3_CinemaProjektAPI_JB_RFK.Interfaces;
using H3_CinemaProjektAPI_JB_RFK.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace H3_CinemaProjektAPI_JB_RFK.Services
{
    public class ProfileService : IProfileService
    {
        private readonly IProfileRepositories _context;
        
        public ProfileService(IProfileRepositories context)
        {
            _context = context;
        }

        //Login
        public async Task<List<ProfileResponse>> Login(string Email, string password)
        {
            return await _context.Login(Email,password);
        }

        public async Task<List<Profile>> GetProfile(int id)
        {
            return await _context.GetProfile(id);
        }



    }
}
