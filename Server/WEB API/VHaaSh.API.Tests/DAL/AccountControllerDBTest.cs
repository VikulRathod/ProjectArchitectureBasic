using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VHaaSh.API.DAL.Account;

namespace VHaaSh.API.Tests.DAL
{
    [TestFixture]
    public class AccountControllerDBTest
    {
        // It is failing need to fix
        [Test]
        public void RegisterUser_WhenAllArgumentsPassed_ThenResultIsGreaterThanZero()
        {
            // arrange
            AccountControllerDB accountDB = new AccountControllerDB();

            // act
            int result = accountDB.RegisterUser("Atul", "Rathod", "8956890522", "atulsantoshrathod@gmail.com", "123456");

            // assert
            Assert.Greater(result, 0);
        }
    }
}
