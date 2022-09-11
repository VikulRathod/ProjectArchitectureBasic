using System.Web.Http;
using Unity;
using Unity.WebApi;
using VHaaSh.API.BLL.Account;
using VHaaSh.API.BLL.Logs;
using VHaaSh.API.DAL.Account;
using VHaaSh.API.Logging.Logs;
using VHaaSh.Notifications.Email;
using VHaaSh.Notifications.Sms;
using VHaaSh.Notifications.WhatsApp;
using VHaaSh.Utilities;

namespace VHaaSh.API
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            container.RegisterType<IAccountControllerBL, AccountControllerBL>();
            container.RegisterType<IAccountControllerDB, AccountControllerDB>();

            container.RegisterType<IEmailNotifications, EmailNotifications>();
            container.RegisterType<ISMSNotifications, SMSNotifications>();
            container.RegisterType<IWhatsAppNotifications, WhatsAppNotifications>();

            container.RegisterType<ILoginHelper, LoginHelper>();
            container.RegisterType<IApplicationLogsBL, ApplicationLogsBL>();
            container.RegisterType<IApplicationLogsDB, ApplicationLogsDB>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}