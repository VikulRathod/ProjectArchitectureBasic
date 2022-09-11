namespace VHaaSh.UI.BLL.Logs
{
    public interface IApplicationLogsBL
    {
        void Info(string message);
        void Debug(string message);
        void Warning(string message);
        void Error(string message);
        void Fatal(string message);
    }
}
