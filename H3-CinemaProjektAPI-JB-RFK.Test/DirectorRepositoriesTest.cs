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
    public class DirectorRepositoriesTest // Inheritance (hvor skal der arves fra)
    {
        //Aggregering
        private readonly DirectorsRepositories sut; // sut(System Under Test) kan hedde hvad som helst
        private readonly DataBaseContext context;
        private readonly DbContextOptions<DataBaseContext> options;

        public DirectorRepositoriesTest()
        {
            // Her simulerer vi databasen
            options = new DbContextOptionsBuilder<DataBaseContext>()
                .UseInMemoryDatabase(databaseName: "nogetSkulleDenHedde")
                .Options;
            //Association - Det der skal testes på
            context = new DataBaseContext(options);
            sut = new DirectorsRepositories(context);
        }

        [Fact]
        public async Task getAll_listOfDirectors_CheckIfDataExits()
        {
            //Arrange - sætter testen op (define)
            await context.Database.EnsureCreatedAsync();
            context.Directors.AddRange(new Directors
            {
                DirectorsId = 1,
                FirstName = "Anders",
                LastName = "Matthesen"
            },
            new Directors
            {
                DirectorsId = 2,
                FirstName = "Zack",
                LastName = "Snyder"
            });
            await context.SaveChangesAsync();

            //Act
            var result = await sut.GetAllDirectors(); 


            //Assert
            Assert.NotNull(result); // Kan også laves med Null(result); Så får man en fejl i testen og får new Directors tilbage
            Assert.Equal(2, result.Count);
            Assert.IsType<List<Directors>>(result);
        }


    }
}
