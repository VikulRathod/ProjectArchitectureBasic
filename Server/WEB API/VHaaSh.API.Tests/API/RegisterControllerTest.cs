using APIAuthentication.Controllers;
using FakeItEasy;
using NUnit.Framework;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Hosting;
using VHaaSh.API.BLL.Account;
using VHaaSh.API.BLL.Logs;
using VHaaShAPIModals.Account;

namespace VHaaSh.API.Tests.API
{
    // Arrange Act Assert

    [TestFixture]
    public class RegisterControllerTest
    {
        [Test]
        public void RegisterUser_WhenUserInfoIsNotNull_ThenOkResponse()
        {
            // 1 - arrange 
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

            // to provide dependency we need to mock dependent objects 
            // use fakeiteasy or moq 

            var accountControllerBLFake = A.Fake<IAccountControllerBL>();
            var applicationLogsBL = A.Fake<IApplicationLogsBL>();

            // 2 - act 

            RegisterController controller = new RegisterController
                (accountControllerBLFake, applicationLogsBL);
            var configuration = new HttpConfiguration();
            controller.Request = new HttpRequestMessage();
            controller.Request.Properties[HttpPropertyKeys.HttpConfigurationKey] = configuration;

            var result = controller.RegisterUser(user);

            // 3 - assert 

            Assert.AreEqual(result.StatusCode, HttpStatusCode.OK);
        }

        [Test]
        public void RegisterUser_WhenUserInfoIsNull_ThenBadRequest()
        {
            // 1 - arrange 
            UserInfo user = null;

            // to provide dependency we need to mock dependent objects 
            // use fakeiteasy or moq 

            var accountControllerBLFake = A.Fake<IAccountControllerBL>();
            var applicationLogsBL = A.Fake<IApplicationLogsBL>();

            // 2 - act 

            RegisterController controller = new RegisterController
                (accountControllerBLFake, applicationLogsBL);
            var configuration = new HttpConfiguration();
            controller.Request = new HttpRequestMessage();
            controller.Request.Properties[HttpPropertyKeys.HttpConfigurationKey] = configuration;

            var result = controller.RegisterUser(user);

            // 3 - assert 

            Assert.AreEqual(result.StatusCode, HttpStatusCode.BadRequest);
        }
    }
}
