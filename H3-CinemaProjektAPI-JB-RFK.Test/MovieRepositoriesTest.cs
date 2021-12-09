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
    public class MovieRepositoriesTest
    {
        private readonly MovieRepositories sut;
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
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
            Assert.IsType<List<Movie>>(result);

        }
    }
}
