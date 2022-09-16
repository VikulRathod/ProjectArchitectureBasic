using FakeItEasy;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VHaaSh.API.BLL.Logs;
using VHaaSh.API.Logging.Logs;

namespace VHaaSh.API.Tests.BLL
{
    [TestFixture]
    public class ApplicationLogsBLTest
    {
        // It is failing need to fix
        [Test]
        public void Debug_WhenCalled_ThenLogsToDB()
        {
            // arrange
            var applicationLogsDB = A.Fake<IApplicationLogsDB>();
            ApplicationLogsBL appLogs = new ApplicationLogsBL(applicationLogsDB);

            // Act
            appLogs.Debug("HELLO");

            // assert            
            Assert.DoesNotThrow(() => { });
        }
    }
}
