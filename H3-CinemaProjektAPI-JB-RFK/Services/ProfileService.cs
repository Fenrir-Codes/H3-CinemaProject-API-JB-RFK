﻿using H3_CinemaProjektAPI_JB_RFK.DTO;
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



    }
}
