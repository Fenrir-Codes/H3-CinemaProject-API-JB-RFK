using H3_CinemaProjektAPI_JB_RFK.DTO;
using H3_CinemaProjektAPI_JB_RFK.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace H3_CinemaProjektAPI_JB_RFK.Interfaces
{
    public interface IMovieService
    {
        Task<Movie> GetMovie(int Id);

        Task<List<Movie>> GetAllMovies();

        Task<bool> DeleteMovie(int Id);

        Task<Movie> CreateMovie(Movie movie);

        Task<Movie> UpdateMovie(int id, Movie data);

        Task<List<Movie>> GetMovieTitle(string title);



    }
}
