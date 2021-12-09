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
    public class ProfileTest
    {
        private readonly ProfilesController profilectrl;   // reaching contorller
        private readonly Mock<IProfileService> profileService = new(); 

        public ProfileTest()
        {
            profilectrl = new ProfilesController(profileService.Object);
        }

        #region return OK 200
        //The HTTP 200 OK success status response code indicates that the request has succeeded.
        [Fact]
        public async void getAllProfiles_WithStatusCode200()
        {
            //Arrange (setting up a list)
            List<Profile> list = new List<Profile>
            {
                new Profile
                {
                    ProfileId = 1,
                    Firstname = "Joseph",
                    Lastname = "Bali",
                    Address = "Testaddress 1",
                    Phone = 11224455,
                    Email = "Testmail@test.hu"
                },
                new Profile
                {
                    ProfileId = 2,
                    Firstname = "Jonas",
                    Lastname = "Ibsen",
                    Address = "Testaddress 2",
                    Phone = 55667785,
                    Email = "Testmail@test.dk"
                },
                new Profile
                {
                    ProfileId = 3,
                    Firstname = "Jessica",
                    Lastname = "Johanssen",
                    Address = "Testaddress 3",
                    Phone = 11445577,
                    Email = "Testmail@test.com"
                }
            };
            profileService.Setup(profile => profile.GetProfiles()).ReturnsAsync(list);

            //Act - Controller layer
            var result = await profilectrl.GetProfiles();

            //Assert - verficate the method
            var statusCode = (IStatusCodeActionResult)result;
            Assert.Equal(200, statusCode.StatusCode);
        }
        #endregion

        #region Nocontent
        //test NoContent
        //The HTTP 204 No Content success status response code indicates that a request has succeeded,
        //but that the client doesn't need to navigate away from its current page.
        [Fact]
        public async void getAllProfile_NoContent()
        {
            //Empty List
            //Arrange
            List<Profile> list = new(); //Empty list

            profileService.Setup(p => p.GetProfiles()).ReturnsAsync(list);

            //Act
            var result = await profilectrl.GetProfiles();

            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result; // should return 204 nocontent
            Assert.Equal(204, statusCodeResult.StatusCode);
        }
        #endregion

        #region 400 status
        //The HyperText Transfer Protocol(HTTP) 400 Bad Request response status code indicates that the server cannot
        //or will not process the request due to something
        //that is perceived to be a client error(for example, malformed request syntax, invalid request message framing, or deceptive request routing).
        [Fact]
        public async void getAllProfiles_WithException()
        {
            //Arrange
            profileService.Setup(p => p.GetProfiles()).ReturnsAsync(() => throw new Exception("This is the Exception on profiles"));

            //Act
            var result = await profilectrl.GetProfiles();

            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result; // waiting 200 code
            Assert.Equal(400, statusCodeResult.StatusCode); // but server throwing 400
        }
        #endregion
    }
}

