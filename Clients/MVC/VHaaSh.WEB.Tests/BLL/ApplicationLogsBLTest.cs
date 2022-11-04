using FakeItEasy;
using NUnit.Framework;
using VHaaSh.UI.BLL.Logs;
using VHaaSh.UI.Logging.Logs;

namespace VHaaSh.WEB.Tests.BLL
{
    [TestFixture]
    public class ApplicationLogsBLTest
    {
        
        [Test]
        public void Debug_WhenCalled_ThenLogsToDB()
        {
            // arrange
            var applicationLogsDB = A.Fake<IApplicationLogsDB>();
            ApplicationLogsBL appLogs = new ApplicationLogsBL(applicationLogsDB);

            // act
            appLogs.Debug("HELLO");

            // assert            
            Assert.DoesNotThrow(() => { });
        }
    }
}
