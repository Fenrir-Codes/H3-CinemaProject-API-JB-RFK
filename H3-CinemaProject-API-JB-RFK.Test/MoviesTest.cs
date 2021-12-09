using H3_CinemaProjektAPI_JB_RFK.Controllers;
using H3_CinemaProjektAPI_JB_RFK.Interfaces;
using H3_CinemaProjektAPI_JB_RFK.Model;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace H3_CinemaProject_API_JB_RFK.Test
{
    public class MoviesTest
    {
        private readonly MoviesController _ctrl;   // reaching contorller
        private readonly Mock<IMovieService> _moviesService = new(); 

        public MoviesTest()
        {
            _ctrl = new MoviesController(_moviesService.Object);
        }


        #region return OK 200
        //The HTTP 200 OK success status response code indicates that the request has succeeded.
        [Fact]
        public async void getAllMovies_ShouldStatusCode200()
        {
            //Arrange (setting up a list)
            List<Movie> list = new List<Movie>
            { 
                new Movie
                {
                    MovieId = 1111,
                    Title = "Justic League"
                },
                new Movie
                {
                      MovieId = 22,
                    Title = "Spider Man"
                },
                new Movie
                {
                     MovieId = 5,
                    Title = "XXX"
                }
            };
            _moviesService.Setup(movie => movie.GetAllMovies()).ReturnsAsync(list);

            //Act - Controller layer
            var result = await _ctrl.GetAllMovies();

            //Assert - verficate the method
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(200, statusCodeResult.StatusCode);
        }
        #endregion

        #region nocontent
        //The HTTP 204 No Content success status response code indicates that a request has succeeded,
        //but that the client doesn't need to navigate away from its current page.
        [Fact]
        public async void getAllMovie_NoContent()
        {
            //Empty List
            //Arrange
            List<Movie> listOfMovies = new(); //List<Movie>

            _moviesService.Setup(movie => movie.GetAllMovies()).ReturnsAsync(listOfMovies);

            //Act
            var result = await _ctrl.GetAllMovies();

            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result; // should return 204 nocontent
            Assert.Equal(204, statusCodeResult.StatusCode);
        }
        #endregion

        #region exception is raised, 500 status
        //The HyperText Transfer Protocol(HTTP) 500 Internal Server Error server error response code
        //indicates that the server encountered an unexpected condition that prevented it from fulfilling the request.
        [Fact]
        public async void getAllMovies_WithException()
        {
            //Arrange
            _moviesService.Setup(m => m.GetAllMovies()).ReturnsAsync(() => throw new Exception("This is the Exception on Movies"));

            //Act
            var result = await _ctrl.GetAllMovies();

            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result; // waiting 200 code
            Assert.Equal(500, statusCodeResult.StatusCode); // but server throwing 500
        }
        #endregion
    }
}
