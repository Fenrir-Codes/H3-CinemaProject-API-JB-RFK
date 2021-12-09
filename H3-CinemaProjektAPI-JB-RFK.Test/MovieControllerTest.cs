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

namespace H3_CinemaProjektAPI_JB_RFK.Test
{
    public class MovieControllerTest
    {
        private readonly MoviesController sut; //sut(System Under Test) kan hedde hvad som helst
        private readonly Mock<IMovieService> movieService = new();

        public MovieControllerTest()
        {
            sut = new MoviesController(movieService.Object);
        }

        #region getAlMovies 200
        [Fact]
        public async void getAllMovies_ShouldReturnCode200()
        {
            //Arrange
            List<Movie> listOfMovies = new List<Movie>
            {
                new Movie
                {
                    Title = "Dune",
                    Genre = "Sci-fi",
                    Country = "USA"
                },
                 new Movie
                {
                    Title = "Pulp fiction",
                    Genre = "Action",
                    Country = "USA"
                }
            };
            movieService.Setup(movie => movie.GetAllMovies()).ReturnsAsync(listOfMovies);

            //Act
            var result = await sut.GetAllMovies();

            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(200, statusCodeResult.StatusCode);

        }
        #endregion
    }
}
