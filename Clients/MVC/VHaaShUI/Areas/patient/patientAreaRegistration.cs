using System.Web.Mvc;

namespace VHaaSh.WEB.Areas.patient
{
    public class patientAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "patient";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "patient_default",
                "patient/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}