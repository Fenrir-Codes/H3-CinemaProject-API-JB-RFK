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

namespace H3_CinemaProject_API_JB_RFK.Test
{
    public class DirectorsTest
    {
        private readonly DirectorsController _ctrl;   // reaching contorller
        private readonly Mock<IDirectorsService> _directorsService = new(); // Moqing IDirectorsservice

        public DirectorsTest()
        {
            _ctrl = new DirectorsController(_directorsService.Object);
        }


        #region OK test 200
        //The HTTP 200 OK success status response code indicates that the request has succeeded.
        [Fact]// FACT decorator means, this is a test methode
        public async void getAllDirectors_ShouldBeStatusCode200()
        {
            //Arrange (setting up a list)
            List<Directors> listDirectors = new List<Directors>
            { //hardcoded persons to fill up List
                new Directors
                {
                    DirectorsId = 1,
                    FirstName = "Test1"
                },
                new Directors
                {
                    DirectorsId = 2,
                    FirstName = "Test2"
                },
                new Directors
                {
                    DirectorsId =3,
                    FirstName ="Test3"
                }
            };
            _directorsService.Setup(directors => directors.GetAllDirectors()).ReturnsAsync(listDirectors); // Service layer

            //Act - Controller layer
            var result = await _ctrl.GetAllDirectors();

            //Assert - verficate the method
            var statusCodeResult = (IStatusCodeActionResult)result; // should return 200 OK status
            Assert.Equal(200, statusCodeResult.StatusCode);
        }
        #endregion

        #region nocontenttest
        //The HTTP 204 No Content success status response code indicates that a request has succeeded,
        //but that the client doesn't need to navigate away from its current page.

        [Fact]
        public async void getAllDirectors_NoContent()
        {
            //Empty List
            //Arrange
            List<Directors> list = new();

            _directorsService.Setup(d => d.GetAllDirectors()).ReturnsAsync(list);

            //Act
            var result = await _ctrl.GetAllDirectors();

            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result; // should return 204 nocontent
            Assert.Equal(204, statusCodeResult.StatusCode);
        }

        #endregion

        #region exception is raised, 500 status
        //The HyperText Transfer Protocol(HTTP) 500 Internal Server Error server error response code
        //indicates that the server encountered an unexpected condition that prevented it from fulfilling the request.
       [Fact]
        public async void getAllDirectors_WithException()
        {
            //Arrange
            _directorsService.Setup(d => d.GetAllDirectors()).ReturnsAsync(() => throw new Exception("Exception on Directors"));

            //Act
            var result = await _ctrl.GetAllDirectors();

            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result; // waitung 200 code
            Assert.Equal(500, statusCodeResult.StatusCode); // but server returns 500
        }
        #endregion

    }
}
