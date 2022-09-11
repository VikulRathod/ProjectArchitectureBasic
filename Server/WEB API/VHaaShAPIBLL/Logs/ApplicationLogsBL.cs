using VHaaSh.API.Logging.Logs;

namespace VHaaSh.API.BLL.Logs
{
    public class ApplicationLogsBL : IApplicationLogsBL
    {
        IApplicationLogsDB _log;

        public ApplicationLogsBL(IApplicationLogsDB log)
        {
            _log = log;
        }

        public void Debug(string message)
        {
            _log.Debug(message);
        }

        public void Error(string message)
        {
            _log.Error(message);
        }

        public void Fatal(string message)
        {
            _log.Fatal(message);
        }

        public void Info(string message)
        {
            _log.Info(message);
        }

        public void Warning(string message)
        {
            _log.Warning(message);
        }
    }
}
