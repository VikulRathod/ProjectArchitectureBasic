using System.Web.Mvc;

namespace VHaaSh.API.Areas.Receptionist
{
    public class ReceptionistAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Receptionist";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Receptionist_default",
                "Receptionist/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}