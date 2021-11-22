using H3_CinemaProjektAPI_JB_RFK.DTO;
using H3_CinemaProjektAPI_JB_RFK.Interfaces;
using H3_CinemaProjektAPI_JB_RFK.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace H3_CinemaProjektAPI_JB_RFK.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepositories context;

        public MovieService(IMovieRepositories _context)
        {
            context = _context;
        }

        #region Create/post movie
        public async Task<Movie> CreateMovie(Movie movie)
        {
            return await context.CreateMovie(movie);
        }
        #endregion

        #region Delete movie
        public async Task<bool> DeleteMovie(int Id)
        {
            var temp = await context.DeleteMovie(Id);
            return temp != null;
        }
        #endregion

        #region Get all movies
        public async Task<List<Movie>> GetAllMovies()
        {
            return await context.GetAllMovies();
        }
        #endregion

        #region Get movie by id
        public async Task<Movie> GetMovie(int Id)
        {
            return await context.GetMovie(Id);
        }
        #endregion

        #region Get movie by title
        public async Task<Movie> GetMovieTitle(string title)
        {
            return await context.GetMovieTitle(title);
        }
        #endregion
    }
}
