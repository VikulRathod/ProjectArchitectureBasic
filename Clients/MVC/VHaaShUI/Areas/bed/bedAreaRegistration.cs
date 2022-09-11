using System.Web.Mvc;

namespace VHaaSh.WEB.Areas.bed
{
    public class bedAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "bed";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "bed_default",
                "bed/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}