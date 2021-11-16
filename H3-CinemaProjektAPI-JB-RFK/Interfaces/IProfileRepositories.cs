﻿using H3_CinemaProjektAPI_JB_RFK.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace H3_CinemaProjektAPI_JB_RFK.Interfaces
{
    public interface IProfileRepositories
    {
        Task<Profile> GetProfile(int Id);
        Task<List<Profile>> Login(string Email, string password);
    }
}
