using H3_CinemaProjektAPI_JB_RFK.DataBase;
using H3_CinemaProjektAPI_JB_RFK.Interfaces;
using H3_CinemaProjektAPI_JB_RFK.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace H3_CinemaProjektAPI_JB_RFK.Repositories
{
    public class MovieRepositories : IMovieRepositories
    {
        private readonly DataBaseContext context;

        public MovieRepositories(DataBaseContext _context)
        {
            context = _context;
        }

        public async Task<Movie> CreateMovie(Movie movie)
        {
            context.Movie.Add(movie);
            await context.SaveChangesAsync();
            return movie;
        }

        public async Task<Movie> DeleteMovie(int Id)
        {
            var movie = await context.Movie.FindAsync(Id);
            if (movie != null)
            {
                context.Movie.Remove(movie);
                await context.SaveChangesAsync();
            }
            return movie;
        }

        //public async Task<List<MovieResponse>> GetAllMovies()
        //{
        //    var movies = await context.Movie.Where(t => t.Title == title).ToListAsync();

        //    return movies.Select(obj => new MovieResponse
        //    {
        //        MovieId = obj.MovieId,
        //        Title = obj.Title,
        //        Genre = obj.Genre,
        //        Language = obj.Language

        //    }).ToList();
        //}

        public async Task<List<Movie>> GetAllMovies()
        {
            List<Movie> movieList = await context.Movie.ToListAsync();
            return movieList;
        }


        public async Task<Movie> GetMovie(int Id)
        {
            return await context.Movie.FindAsync(Id);
        }

        public async Task<Movie> GetMovieTitle(string title)
        {
            return await context.Movie.Where(i => i.Title == title).FirstOrDefaultAsync();
            

        }
    }
}
