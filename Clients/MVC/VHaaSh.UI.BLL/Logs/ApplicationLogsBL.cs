using VHaaSh.UI.Logging.Logs;

namespace VHaaSh.UI.BLL.Logs
{
    public class ApplicationLogsBL : IApplicationLogsBL
    {
        private IApplicationLogsDB _logger;

        public ApplicationLogsBL(IApplicationLogsDB logger)
        {
            _logger = logger;
        }

        public void Debug(string message)
        {
            _logger.Debug(message);
        }

        public void Error(string message)
        {
            _logger.Error(message);
        }

        public void Fatal(string message)
        {
            _logger.Fatal(message);
        }

        public void Info(string message)
        {
            _logger.Info(message);
        }

        public void Warning(string message)
        {
            _logger.Warning(message);
        }
    }
}
