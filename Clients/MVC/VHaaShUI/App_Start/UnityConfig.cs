using System.Web.Mvc;
using Unity;
using Unity.Mvc5;
using VHaaSh.API.Client.HttpClients.Account;
using VHaaSh.API.Client.HttpClients.Payment;
using VHaaSh.API.Client.Services.Account;
using VHaaSh.API.Client.Services.Payment;
using VHaaSh.UI.BLL.Logs;
using VHaaSh.UI.Logging.Logs;

namespace VHaaSh.WEB
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            container.RegisterType<IRegisterApiController, RegisterApiController>();
            container.RegisterType<IRegisterHttpClient, RegisterHttpClient>();

            container.RegisterType<IPaymentApiController, PaymentApiController>();
            container.RegisterType<IPaymentHttpClient, PaymentHttpClient>();

            container.RegisterType<IApplicationLogsBL, ApplicationLogsBL>();
            container.RegisterType<IApplicationLogsDB, ApplicationLogsDB>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}