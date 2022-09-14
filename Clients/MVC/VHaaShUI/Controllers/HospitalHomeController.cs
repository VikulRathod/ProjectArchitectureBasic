using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VHaaSh.WEB.Controllers
{
    public class HospitalHomeController : Controller
    {

        // GET: HospitalHome
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Doctors()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult Blog_Details()
        {
            return View();
            
        }
        public ActionResult Blog()
        {
            return View();
            
        }
        public ActionResult About()
        {
            return View();

        }
    }
}