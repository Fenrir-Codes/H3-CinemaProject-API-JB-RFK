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

        #region login function
        //Login
        public async Task<ProfileResponse> Login(string Email, string password)
        {
            return await _context.Login(Email,password);
        }
        #endregion

        #region get all profiles
        //getting all profiles to list
        public async Task<List<Profile>> GetProfiles()
        {
            return await _context.GetProfiles();
        }
        #endregion

        #region get one profile with id
        //get one profile with id
        public async Task<Profile> GetProfile(int id)
        {
            return await _context.GetProfile(id);
        }
        #endregion

        #region profile by name
        public async Task<Profile> ProfileByName(string name)
        {
            return await _context.ProfileByName(name);
        }
        #endregion

        #region create profile
        public async Task<Profile> CreateProfile(Profile data)
        {
            return await _context.CreateProfile(data);
        }
        #endregion

        #region update profile
        public async Task<Profile> UpdateProfile(int id, Profile data)
        {
            return await _context.UpdateProfile(id, data);
        }
        #endregion
        #region delete profile
        public async Task<bool> DeleteProfile(int Id)
        {
            var temp = await _context.DeleteProfile(Id);
            return temp != null;
        }
        #endregion



    }
}
