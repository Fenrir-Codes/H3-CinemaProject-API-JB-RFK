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

        // GET: api/Directors
        [HttpGet]
        public async Task<ActionResult> GetDirector(int Id)
        {
            return Ok(await _context.GetDirector(Id));
        }

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

        // POST: api/Directors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Directors>> CreateDirector(Directors directors)
        {
            await _context.CreateDirector(directors);
            //await _context.SaveChangesAsync();

            return CreatedAtAction("GetDirectors", new { id = directors.DirectorsId }, directors);
        }

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

        //    // GET: api/Directors/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Directors>> GetDirectors(int id)
        //{
        //    var directors = await _context.Directors.FindAsync(id);

        //    if (directors == null)
        //    {
        //        return NotFound();
        //    }

        //    return directors;
        //}

        //    // PUT: api/Directors/5
        //    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //    [HttpPut("{id}")]
        //    public async Task<IActionResult> PutDirectors(int id, Directors directors)
        //    {
        //        if (id != directors.DirectorsId)
        //        {
        //            return BadRequest();
        //        }

        //        _context.Entry(directors).State = EntityState.Modified;

        //        try
        //        {
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!DirectorsExists(id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }

        //        return NoContent();
        //    }       


        //    private bool DirectorsExists(int id)
        //    {
        //        return _context.Directors.Any(e => e.DirectorsId == id);
        //    }
    }
}
