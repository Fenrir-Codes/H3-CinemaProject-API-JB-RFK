using H3_CinemaProjektAPI_JB_RFK.Controllers;
using H3_CinemaProjektAPI_JB_RFK.DTO;
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
    public class DirectorControllerTests
    {
        private readonly DirectorsController sut; //sut(System Under Test) kan hedde hvad som helst
        private readonly Mock<IDirectorsService> directorService = new();

        public DirectorControllerTests()
        {
            sut = new DirectorsController(directorService.Object);
        }

        #region getAllDirectors 200
        [Fact]
        public async void getAllDirectors_ShouldReturnCode200()
        {
            //Arrange
            List<Directors> listOfDirectors = new List<Directors>
            {
                // Man behøver ikke mere end 2 Responses for at teste
                new Directors
                {
                    DirectorsId = 1,
                   //DirectorId = 1,
                   FirstName = "Anders",
                   LastName = "Matthesen",
                   //Movie = List<Movie>
                },
                new Directors
                {
                    DirectorsId = 2,
                    FirstName = "Zack",
                    LastName = "Snyder",
                }
            };
            directorService.Setup(director => director.GetAllDirectors()).ReturnsAsync(listOfDirectors); // Hvis den hedder Task i Interfaces skal den .ReturnsAsync()

            //Act - Controller niveau
            var result = await sut.GetAllDirectors();

            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(200, statusCodeResult.StatusCode);
        }
        #endregion

        #region getAllDirectors 204
        [Fact]
        public async void getAllDirectors_WhenNoElementsExits()
        {
            //Arrange
            List<Directors> listOfDirectors = new();
            directorService.Setup(director => director.GetAllDirectors()).ReturnsAsync(listOfDirectors);

            //Act
            var result = await sut.GetAllDirectors();

            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(204, statusCodeResult.StatusCode); // 204 betyder at tabellen er tom
        }
        #endregion

        #region delete204
        [Fact]
        public async void delete_Return204_WhenDirectorIsDeleted()
        {
            //Arrange
            int directorId = 1;
            directorService.Setup(dir => dir.DeleteDirector(It.IsAny<int>())).ReturnsAsync(true);

            //Act - Controller niveau
            var result = await sut.DeleteDirectors(directorId);

            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result; // 204 betyder at tabellen er tom
            Assert.Equal(204, statusCodeResult.StatusCode);
        }
        #endregion
    }
}
