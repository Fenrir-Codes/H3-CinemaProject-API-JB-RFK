using H3_CinemaProjektAPI_JB_RFK.DTO;
using H3_CinemaProjektAPI_JB_RFK.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace H3_CinemaProjektAPI_JB_RFK.Interfaces
{
    public interface IProfileService
    {
        Task<List<ProfileResponse>> Login(string Email, string password);

        Task<Profile> GetProfile(int id);
    }
}
