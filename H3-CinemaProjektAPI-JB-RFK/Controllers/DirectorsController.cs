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
    public class DirectorsController : ControllerBase
    {
        private readonly IDirectorsService _context;

        public DirectorsController(IDirectorsService context)
        {
            _context = context;
        }

        #region Get all directors
        [HttpGet("GetAllDirectors")]
        public async Task<ActionResult> GetAllDirectors()
        {
            try
            {
                List<Directors> directorList = await _context.GetAllDirectors();
                if (directorList == null)
                {
                    return Problem("Nothing was returned");
                }
                if (directorList.Count == 0)
                {
                    return NoContent(); // 204
                }
                return Ok(directorList);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }
        #endregion

        #region Get director with id
        // GET: api/Directors
        [HttpGet("{Id}")]
        public async Task<ActionResult> GetDirector(int Id)
        {
            return Ok(await _context.GetDirector(Id));
        }
        #endregion

        #region director by firstName
        [HttpGet("ByName/{firstName}")]
        public async Task<ActionResult> ByFirstName(string firstName)
        {
            try
            {
                return Ok(await _context.ByFirstName(firstName));
            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message);
            }
        }
        #endregion

        #region director by lastName
        [HttpGet("ByLastName/{lastName}")]
        public async Task<ActionResult> ByLastName(string lastName)
        {
            try
            {
                return Ok(await _context.ByLastName(lastName));
            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message);
            }
        }
        #endregion

        #region create directors
        // POST: api/Directors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Directors>> CreateDirector(Directors directors)
        {
            return await _context.CreateDirector(directors);
            //await _context.SaveChangesAsync();

            //return CreatedAtAction("GetDirectors", new { id = directors.DirectorsId }, directors);
        }
        #endregion

        #region update director
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateDirector(int id, Directors data)
        {
            if (id != data.DirectorsId)
            {
                return BadRequest("ID mismatch!");
            }

            try
            {
                await _context.UpdateDirector(id, data);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message);
            }

        }
        #endregion

        #region delete from directors
        // DELETE: api/Directors/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDirectors(int id)
        {
            try
            {
                bool result = await _context.DeleteDirector(id);
                if (!result)
                {
                    return Problem("Director was not deleted, something went wrong");
                }
                return NoContent();
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }
        #endregion

        #region Movie by director
        [HttpGet("MovieByDirector/{name}")]
        public async Task<ActionResult<List<MovieByDirectorResponse>>> MovieByDirector(string name)
        {

         
            try
            {
                if(name == null) {
                    return BadRequest();
                }

                //if(name != null)
                //{
                //    return Ok(await _context.MovieByDirector("", name));
                //}

                //if (name != null)
                //{
                //    return Ok(await _context.MovieByDirector(name, ""));
                //}
                //if (lname != null)
                //{
                //    return Ok(await _context.MovieByDirector(fname, lname));
                //}
                //if (fname != null && lname != null)
                //{
                //    return Ok(await _context.MovieByDirector(fname, lname));
                //}

                return Ok(await _context.MovieByDirector(name));
            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message);
            }            
        }
        #endregion

    }
}
