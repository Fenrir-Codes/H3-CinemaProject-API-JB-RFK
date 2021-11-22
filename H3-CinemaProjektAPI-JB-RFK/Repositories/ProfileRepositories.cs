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

        #region delete profile
        public async Task<Profile> DeleteProfile(int Id)
        {
            var profile = await context.Profile.FindAsync(Id);
            if (profile != null)
            {
                context.Profile.Remove(profile);
                await context.SaveChangesAsync();
            }
            return profile;
        }
        #endregion

        #region getting all profiles function
        //getting the profiles (all)
        public async Task<List<Profile>> GetProfiles()
        {
            return await context.Profile.ToListAsync();
        }
        #endregion

        #region getting profile with id function
        //getting the profile with id
        public async Task<Profile> GetProfile(int id)
        {
            return await context.Profile.FindAsync(id);
        }
        #endregion

        #region create profile function
        //create profile data
        public async Task<Profile> CreateProfile(Profile data)
        {
            context.Profile.Add(data);
            await context.SaveChangesAsync();
            return data;
        }
        #endregion

        #region update profile
        public async Task<Profile> UpdateProfile(int id, Profile data)
        {
            var findProfile = await context.Profile.Where(p => p.ProfileId == id).FirstOrDefaultAsync();
            if (findProfile != null)
            {
                findProfile.ProfileId = data.ProfileId;
                findProfile.Firstname = data.Firstname;
                findProfile.Lastname = data.Lastname;
                findProfile.Address = data.Address;
                findProfile.Email = data.Email;
                findProfile.Phone = data.Phone;

                context.Entry(findProfile).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return findProfile;
            }
            return null;

            #region outcommented
            //var update = new Profile();
            //{
            //  //  update.ProfileId = data.ProfileId;
            //    update.Firstname = data.Firstname;
            //    update.Lastname = data.Lastname;
            //    update.Address = data.Address;
            //    update.Email = data.Email;
            //    update.Phone = data.Phone;
            //}
            //context.Entry(findProfile).State = EntityState.Modified; // den her virker ikke
            //context.Profile.Add(update);
            //await context.SaveChangesAsync();
            //return update;
            #endregion
        }
        #endregion

        #region login function
        //Login
        public async Task<ProfileResponse> Login(string mail, string password)
        {
            //En Task er et objekt, der repræsenterer noget arbejde, skal udføres.
            //Opgaven kan fortælle dig, om arbejdet er afsluttet, og hvis operationen returnerer et resultat, giver opgaven dig resultatet.

            //user object (Profile)
            var user = await context.Profile.Where(user => user.Email == mail && user.Password == password).FirstOrDefaultAsync();
            //if the object is not empty ->   
            if (user != null)
            {
                //fill the response object with values ->
                var response = new ProfileResponse();
                {
                    response.ProfileId = user.ProfileId;
                    response.Firstname = user.Firstname;
                    response.Lastname = user.Lastname;
                    response.Address = user.Address;
                    response.Email = user.Email;
                    response.Phone = user.Phone;
                    response.Role = user.Role;
                }
                //then return the object ->
                return response;
            }
            // else return null (empty object)
            return null;

            // jeg skal fylde data i profile fra mit api
            //profile.Email = mail;


            //return profile.(obj => new ProfileResponse
            //{
            //    ProfileId = obj.ProfileId,
            //    Email = obj.Email,
            //    Firstname = obj.Firstname,
            //    Lastname = obj.Lastname,
            //    Address = obj.Address,
            //    Phone = obj.Phone,
            //    Role = obj.Role

            //}).ToList();

            //var profile = await context.Profile.Where(e => e.Email == mail && e.Password == password).ToListAsync();
            //return profile.Select(obj => new ProfileResponse
            //{
            //    ProfileId = obj.ProfileId,
            //    Email = obj.Email,
            //    Firstname = obj.Firstname,
            //    Lastname = obj.Lastname,
            //    Address = obj.Address,
            //    Phone = obj.Phone,
            //    Role = obj.Role

            //}).ToList();

        }
        #endregion

    }
}
