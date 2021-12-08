using H3_CinemaProjektAPI_JB_RFK.Controllers;
using H3_CinemaProjektAPI_JB_RFK.DTO;
using H3_CinemaProjektAPI_JB_RFK.Interfaces;
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

        #region getDirector 200
        [Fact]
        public async void getAllDirectors_ShouldReturnCode200()
        {
            //Arrange
            List<DirectorsResponse> listOfDirectors = new List<DirectorsResponse>
            {
                // Man behøver ikke mere end 2 Responses for at teste
                new DirectorsResponse
                {
                   DirectorId = 1,
                   FirstName = "Anders",
                   LastName = "Matthesen",
                   //Movie = List<Movie>
                },
                new DirectorsResponse
                {
                    DirectorId = 2,
                    FirstName = "Zack",
                    LastName = "Snyder",
                }
            };
            directorService.Setup(director => director.GetAllDirectors()).ReturnsAsync(listOfDirectors); // Hvis den hedder Task i Interfaces skal den .ReturnsAsync()

            //Act - Controller niveau
            var result = await sut.GetAllDirectors();

            //Assert
            var statuscodeResult = (IStatusCodeActionResult)result;
        }
        #endregion

        #region getAllDirectors 204
        [Fact]
        public async void getAllDirectors_WhenNoElementsExits()
        {
            //Arrange
            List<DirectorsResponse> listOfDirectors = new();
            //directorService.Setup(director => director.GetAllDirectors()).ReturnsAsync(listOfDirectors);
        }
        #endregion
    }
}
