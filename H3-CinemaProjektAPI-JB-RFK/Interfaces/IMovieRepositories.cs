using H3_CinemaProjektAPI_JB_RFK.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace H3_CinemaProjektAPI_JB_RFK.Interfaces
{
    public interface IMovieRepositories
    {
        Task<Movie> GetMovie(int Id);
        Task<List<Movie>> GetAllMovies();
        Task<Movie> DeleteMovie(int Id);
        Task<Movie> CreateMovie(Movie movie);
        Task<Movie> GetMovieTitle(string title);
    }
}
