using log4net;
using System;

namespace VHaaSh.UI.Logging.Logs
{
    public class ApplicationLogsDB : IApplicationLogsDB
    {
        private static readonly ILog _logger;

        static ApplicationLogsDB()
        {
            _logger = LogManager.GetLogger(Environment.MachineName);
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
            _logger.Warn(message);
        }
    }
}
