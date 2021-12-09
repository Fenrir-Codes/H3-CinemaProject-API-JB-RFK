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
    public class ProfileControllerTest
    {
        private readonly ProfilesController sut;
        private readonly Mock<IProfileService> profileService = new();

        public ProfileControllerTest()
        {
            sut = new ProfilesController(profileService.Object);
        }

        #region getAllProfiles 200
        [Fact]
        public async void getAllProfiles_ShouldReturnStatusCode200()
        {
            //Arrange
            List<Profile> listOfProfiles = new List<Profile>
            {
                new Profile
                {
                    ProfileId = 1,
                    Firstname = "Karl",
                    Lastname = "Den Store",
                    Phone = 87654321
                },
                new Profile
                {
                    ProfileId = 2,
                    Firstname = "Knud",
                    Lastname = "Den Store",
                    Phone = 12345678
                }

            };
            profileService.Setup(prof => prof.GetProfiles()).ReturnsAsync(listOfProfiles);

            //Act
            var result = await sut.GetProfiles();

            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(200, statusCodeResult.StatusCode);
        }
        #endregion

        #region deleteProfile ExceptionIsRaised 500
        [Fact]
        public async void deleteProfile_ExceptionIsRaised()
        {
            //Arrange
            int ProfileId = 1;
            profileService.Setup(prof => prof.DeleteProfile(ProfileId)).ReturnsAsync(() => throw new Exception("Exception thrown here"));

            //Act
            var result = await sut.DeleteProfile(ProfileId);

            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(500, statusCodeResult.StatusCode);
        }
        #endregion
    }
}
