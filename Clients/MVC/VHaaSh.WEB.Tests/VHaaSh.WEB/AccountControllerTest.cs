using FakeItEasy;
using NUnit.Framework;
using VHaaSh.API.Client.Services.Account;
using VHaaSh.UI.BLL.Logs;
using VHaaSh.WEB.Controllers;

namespace VHaaSh.WEB.Tests.VHaaSh.WEB
{
    [TestFixture]
    public class AccountControllerTest
    {
        [Test]
        public void Register_WhenCalled_ThenReturnView()
        {
            // arrange 
            var registerApiControllerFake = A.Fake<IRegisterApiController>();
            var applicationLogsBLFake = A.Fake<IApplicationLogsBL>();

            AccountController accountController =
                new AccountController(registerApiControllerFake, applicationLogsBLFake);

            // act 
            var result = accountController.Register();

            // assert 
            Assert.IsNotNull(result);
        }
    }
}
