using FakeItEasy;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VHaaSh.API.BLL.Account;
using VHaaSh.API.DAL.Account;
using VHaaSh.Notifications.Email;
using VHaaSh.Utilities;

namespace VHaaSh.API.Tests.BLL
{
    [TestFixture]
    public class AccountControllerBLTest
    {
        [Test]
        public void RegisterUser_WhenAllArgumentsPassed_ThenResultIsGreaterThanZero()
        {
            // arrange
            var accountControllerDBFake = A.Fake<IAccountControllerDB>();
            var loginHelper = A.Fake<ILoginHelper>();
            var emailNotifications = A.Fake<IEmailNotifications>();

            A.CallTo(() => loginHelper.GenerateRandomOtp()).Returns<string>("123456");

            A.CallTo(() => accountControllerDBFake.
            RegisterUser("Atul", "Rathod", "8956890522", "atulsantoshrathod@gmail.com", "123456"))
                .Returns<int>(1);

            AccountControllerBL accountBL =
                new AccountControllerBL(accountControllerDBFake, loginHelper, emailNotifications);

            // act 
            int result = accountBL.RegisterUser("Atul", "Rathod", "8956890522", "atulsantoshrathod@gmail.com");

            // assert
            Assert.Greater(result, 0);
        }
    }
}
