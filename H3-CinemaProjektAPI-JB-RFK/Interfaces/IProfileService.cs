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
        //login
        Task<ProfileResponse> Login(string Email, string password);

        //get all profiles
        Task<List<Profile>> GetProfiles();

        //get one profile with id
        Task<Profile> GetProfile(int id);

        Task<Profile> CreateProfile(Profile data);

        Task<Profile> UpdateProfile(int id, Profile data);

        Task<bool> DeleteProfile(int Id);
        Task<Profile> ProfileByName(string name);

    }
}
