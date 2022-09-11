using System.Web.Mvc;

namespace VHaaSh.WEB.Areas.staff
{
    public class staffAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "staff";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "staff_default",
                "staff/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}