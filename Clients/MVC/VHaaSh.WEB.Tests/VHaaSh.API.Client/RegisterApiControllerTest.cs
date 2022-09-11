using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using FakeItEasy;
using VHaaSh.API.Client.HttpClients.Account;
using VHaaSh.API.Client.Services.Account;
using VHaaShModals.Account;

namespace VHaaSh.WEB.Tests.VHaaSh.API.Client
{
    [TestFixture]
    public class RegisterApiControllerTest
    {
        [Test]
        public void RegisterUser_WhenUserInfoIsNotNull_ThenReturnsSuccessCode()
        {
            // arrange 
            var registerHttpClientFake = A.Fake<IRegisterHttpClient>();
            RegisterApiController registerApi =
                new RegisterApiController(registerHttpClientFake);

            UserInfo user = new UserInfo()
            {
                Id = 1,
                UserId = 1,
                FirstName = "Atul",
                LastName = "Rathod",
                Email = "vikul.rathod@gmail.com",
                Mobile = "7447788880",
                HighestQualification = "BCA",
                Occupation = "Self Employeed"
            };

            // act
            var result = registerApi.RegisterUser(user);

            // assert
            Assert.IsTrue(result.IsSuccessStatusCode);
        }
    }
}
