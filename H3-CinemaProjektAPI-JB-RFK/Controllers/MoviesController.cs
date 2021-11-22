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
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _context;

        public MoviesController(IMovieService context)
        {
            _context = context;
        }

        #region Get movies by id
        // GET: api/Movies
        [HttpGet("{id}")]
        public async Task<ActionResult> GetMovie(int Id)
        {
            return Ok(await _context.GetMovie(Id));
        }
        #endregion

        #region Get all movies
        [HttpGet("AllMovies")]
        public async Task<ActionResult> GetAllMovies()
        {
            try
            {
                List<Movie> movieList = await _context.GetAllMovies();
                if (movieList == null)
                {
                    return Problem("Nothing was returned");
                }
                if (movieList.Count == 0)
                {
                    return NoContent(); // 204
                }
                return Ok(movieList);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
            //return Ok(await _context.GetAllMovies());

        }
        #endregion

        #region Get movie by title
        [HttpGet("MovieTitle/{title}")]
        public async Task<ActionResult> GetMovieTitle(string title)
        {
            return Ok(await _context.GetMovieTitle(title));
        }
        #endregion

        #region Create movie
        // POST: api/Movies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Movie>> PostMovie(Movie movie)
        {
            return await _context.CreateMovie(movie);
            //await _context.SaveChangesAsync();

            //return CreatedAtAction("GetMovie", new { id = movie.MovieId }, movie);
        }
        #endregion

        #region Delete movie
        // DELETE: api/Movies/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteMovie(int id)
        {
            try
            {
                bool result = await _context.DeleteMovie(id);
                if (!result)
                {
                    return Problem("Movie was not deleted, something went wrong");
                }
                return NoContent();
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }
        #endregion


        //    // GET: api/Movies/5
        //    [HttpGet("{id}")]
        //    public async Task<ActionResult<Movie>> GetMovie(int id)
        //    {
        //        var movie = await _context.Movie.FindAsync(id);

        //        if (movie == null)
        //        {
        //            return NotFound();
        //        }

        //        return movie;
        //    }

        //    // PUT: api/Movies/5
        //    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //    [HttpPut("{id}")]
        //    public async Task<IActionResult> PutMovie(int id, Movie movie)
        //    {
        //        if (id != movie.MovieId)
        //        {
        //            return BadRequest();
        //        }

        //        _context.Entry(movie).State = EntityState.Modified;

        //        try
        //        {
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!MovieExists(id))
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



        //    private bool MovieExists(int id)
        //    {
        //        return _context.Movie.Any(e => e.MovieId == id);
        //    }
    }
}
