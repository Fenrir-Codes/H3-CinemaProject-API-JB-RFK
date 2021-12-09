using H3_CinemaProjektAPI_JB_RFK.DataBase;
using H3_CinemaProjektAPI_JB_RFK.Model;
using H3_CinemaProjektAPI_JB_RFK.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace H3_CinemaProjektAPI_JB_RFK.Test
{
    public class MovieRepositoriesTest  // Inheritance (hvor skal der arves fra)
    {
        private readonly MovieRepositories sut; // sut (System Under Test)
        private readonly DataBaseContext context;
        private readonly DbContextOptions<DataBaseContext> options;

        // Her simuleres databasen
        public MovieRepositoriesTest() 
        {
            options = new DbContextOptionsBuilder<DataBaseContext>()
                .UseInMemoryDatabase(databaseName: "Et DatabaseNavn")
                .Options;
            //Association - Det der skal testes på
            context = new DataBaseContext(options);
            sut = new MovieRepositories(context); // Denpendecy injection
        }

        #region getAllMovies check if exits
        [Fact]
        public async Task getAll_listOfMovies_CheckIfDataExits()
        {
            //Arrange - Testen sættes op (define)
            await context.Database.EnsureCreatedAsync();
            context.Movie.AddRange(new Movie
            {
                Title = "Jaws",
                Country = "USA",
                Genre = "Horror"
            },
            new Movie
            {
                Title = "Deep blue sea",
                Country = "USA",
                Genre = "Horror"
            });
            await context.SaveChangesAsync();

            //Act
            var result = await sut.GetAllMovies();

            //Assert
            Assert.NotNull(result); // Kan også laves med Null(result); Så får man en fejl i testen og får new Author tilbage
            Assert.Equal(2, result.Count);  // Hvor mange data indeholder min test, 2 er det forventede antal
            Assert.IsType<List<Movie>>(result); // Tjekker typen af den forventede data

        }
        #endregion

        #region getById If movie exits
        [Fact]
        public async Task getByID_IfMovieNotExits()
        {
            //Arrange
            await context.Database.EnsureDeletedAsync(); // Sikre at dataen(cachen) fra tidligere er tom

            //Act
            int movieId = 1;
            var result = await sut.GetMovie(movieId);

            //Assert
            Assert.NotNull(result);
        }
        #endregion

    }
}
