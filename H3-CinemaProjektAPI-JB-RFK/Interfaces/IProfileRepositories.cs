using H3_CinemaProjektAPI_JB_RFK.DTO;
using H3_CinemaProjektAPI_JB_RFK.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace H3_CinemaProjektAPI_JB_RFK.Interfaces
{
    public interface IProfileRepositories
    {
        //login
        Task<ProfileResponse> Login(string Email, string password);

        //getallprofiles
        Task<List<Profile>> GetProfiles();

        //get one with id
        Task<Profile> GetProfile(int id);

        Task<Profile> DeleteProfile(int Id);

    }
}
