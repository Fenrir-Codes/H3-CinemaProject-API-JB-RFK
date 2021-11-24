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

        #region create Movie
        public async Task<Movie> CreateMovie(Movie movie)
        {
            context.Movie.Add(movie);
            await context.SaveChangesAsync();
            return movie;
        }
        #endregion

        #region update Movie
        public async Task<Movie> UpdateMovie(int id, Movie data)
        {
            var movie = await context.Movie.Where(p => p.MovieId == id).FirstOrDefaultAsync();
            if (movie != null)
            {
                movie.MovieId = data.MovieId;
                movie.DirectorsId = data.DirectorsId;
                movie.Title = data.Title;
                movie.Description = data.Description;
                movie.Language = data.Language;
                movie.Country = data.Country;
                movie.Genre = data.Genre;
                movie.Duration = data.Duration;
                movie.ReleaseDate = data.ReleaseDate;

                context.Entry(movie).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return movie;
            }
            return null;

        }
        #endregion

        #region delete Movie (id)
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
        #endregion

        #region outcommented code
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
        #endregion

        #region get all movies
        public async Task<List<Movie>> GetAllMovies()
        {
            List<Movie> movieList = await context.Movie.ToListAsync();
            return movieList;
        }
        #endregion

        #region get movie (id)
        public async Task<Movie> GetMovie(int Id)
        {
            return await context.Movie.FindAsync(Id);
        }
        #endregion

        #region get by title
        public async Task<List<Movie>> GetMovieTitle(string title)
        {
            var book = await context.Movie.Where(t => t.Title!.Contains(title)).ToListAsync();
            return book;
        }
        #endregion
    }
}
