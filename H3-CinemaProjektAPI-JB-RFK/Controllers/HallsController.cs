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
    public class HallsController : ControllerBase
    {
        private readonly IHallService _context;

        public HallsController(IHallService context)
        {
            _context = context;
        }

        // GET: api/Halls
        [HttpGet]
        public async Task<ActionResult<Hall>> GetHall(int Id)
        {
            return Ok(await _context.GetHall(Id));
        }

        [HttpGet("GetAllHalls")]
        public async Task<ActionResult> GetAllHalls()
        {
            try
            {
                List<Hall> hallList = await _context.GetAllHalls();
                if (hallList == null)
                {
                    return Problem("Nothing was returned");
                }
                if (hallList.Count == 0)
                {
                    return NoContent(); // 204
                }
                return Ok(hallList);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        // POST: api/Halls
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Hall>> PostHall(Hall hall)
        {
            return await _context.CreateHall(hall);
            //await _context.SaveChangesAsync();

            //return CreatedAtAction("GetHall", new { id = hall.HallId }, hall);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteHall(int id)
        {
            try
            {
                bool result = await _context.DeleteHall(id);
                if (!result)
                {
                    return Problem("Hall was not deleted, something went wrong");
                }
                return NoContent();
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        //    // GET: api/Halls/5
        //    [HttpGet("{id}")]
        //    public async Task<ActionResult<Hall>> GetHall(int id)
        //    {
        //        var hall = await _context.Hall.FindAsync(id);

        //        if (hall == null)
        //        {
        //            return NotFound();
        //        }

        //        return hall;
        //    }

        //    // PUT: api/Halls/5
        //    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //    [HttpPut("{id}")]
        //    public async Task<IActionResult> PutHall(int id, Hall hall)
        //    {
        //        if (id != hall.HallId)
        //        {
        //            return BadRequest();
        //        }

        //        _context.Entry(hall).State = EntityState.Modified;

        //        try
        //        {
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!HallExists(id))
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



        //    private bool HallExists(int id)
        //    {
        //        return _context.Hall.Any(e => e.HallId == id);
        //    }
    }
}
