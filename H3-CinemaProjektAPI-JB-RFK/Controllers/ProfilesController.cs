using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using H3_CinemaProjektAPI_JB_RFK.DataBase;
using H3_CinemaProjektAPI_JB_RFK.Model;
using H3_CinemaProjektAPI_JB_RFK.Interfaces;
using H3_CinemaProjektAPI_JB_RFK.DTO;

namespace H3_CinemaProjektAPI_JB_RFK.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfilesController : ControllerBase
    {
        private readonly IProfileService _context;

        public ProfilesController(IProfileService context)
        {
            _context = context;
        }

        #region login function
        //Login via profile with email and password
        [HttpPost("Login")]
        public async Task<ActionResult> Login(string Email, string password)
        {
            try
            {
                var user = await _context.Login(Email, password);

                //this if statement grabbing the object from the ProfileRepositories
                if (user != null)
                {
                    return Ok(user);
                }
                else
                {

                    //if the login was not successfull or returned empty object. 
                    //So the shit api wont crash and exit. fuck yeah i am bloody tired...........
                    return BadRequest(400 + " -  Wrong email and/or password or not registered profile!");
                }

            }
            catch (Exception ex)
            {

                return StatusCode(400, ex.Message);
            }

        }
        #endregion

        #region get all profiles
        //getting all profiles to list
        [HttpGet]
        public async Task<ActionResult<List<Profile>>> GetProfiles()
        {
            try
            {
                return await _context.GetProfiles();
            }
            catch (Exception ex)
            {

                return StatusCode(400, ex.Message);
            }

        }
        #endregion

        #region get profile with id
        //Get profile with id
        [HttpGet("{id}")]
        public async Task<ActionResult> GetProfile(int id)
        {
            try
            {
                return Ok(await _context.GetProfile(id));
            }
            catch (Exception ex)
            {

                return StatusCode(400, ex.Message);
            }

        }
        #endregion

        #region create profile
        [HttpPost]
        public async Task<ActionResult<Profile>> CreateProfile(Profile data)
        {
            try
            {
                return await _context.CreateProfile(data) ;
            }
            catch (Exception ex)
            {

                return StatusCode(400, ex.Message);
            }

        }
        #endregion

        #region update profile
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProfile(int id, Profile data)
        {
            if (id != data.ProfileId)
            {
                return BadRequest();
            }
           // _context.UpdateProfile(data) = EntityState.Modified;
            try
            {
                await _context.UpdateProfile(id, data);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message);
            }

        }
        #endregion

        #region delete profile
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProfile(int Id)
        {
            try
            {
                bool result = await _context.DeleteProfile(Id);
                if (!result)
                {
                    return Problem("Profile was not deleted, something went wrong");
                }
                return NoContent();
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }
        #endregion



        #region generated code commented out
        // GET: api/Profiles
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Profile>>> GetProfile()
        //{
        //    return await _context.Profile.ToListAsync();
        //}

        //// GET: api/Profiles/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Profile>> GetProfile(int id)
        //{
        //    var profile = await _context.Profile.FindAsync(id);

        //    if (profile == null)
        //    {
        //        return NotFound();
        //    }

        //    return profile;
        //}

        //// PUT: api/Profiles/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutProfile(int id, Profile profile)
        //{
        //    if (id != profile.ProfileId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(profile).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ProfileExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/Profiles
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Profile>> PostProfile(Profile profile)
        //{
        //    _context.Profile.Add(profile);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetProfile", new { id = profile.ProfileId }, profile);
        //}

        //// DELETE: api/Profiles/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteProfile(int id)
        //{
        //    var profile = await _context.Profile.FindAsync(id);
        //    if (profile == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Profile.Remove(profile);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool ProfileExists(int id)
        //{
        //    return _context.Profile.Any(e => e.ProfileId == id);
        //}
    }
    #endregion
}

