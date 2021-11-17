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

        #region get hall with id
        // GET: api/Halls
        [HttpGet]
        public async Task<ActionResult<Hall>> GetHall(int Id)
        {
            return Ok(await _context.GetHall(Id));
        }
        #endregion

        #region get all halls
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
        #endregion

        #region delete hall (id)
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
        #endregion

    }
}
