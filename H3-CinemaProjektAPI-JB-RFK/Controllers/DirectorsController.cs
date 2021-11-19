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
        [HttpGet("{id}")]
        public async Task<ActionResult> GetDirector(int Id)
        {
            return Ok(await _context.GetDirector(Id));
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
        public async Task<ActionResult> UpdateProfile(int id, Directors data)
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

    }
}
