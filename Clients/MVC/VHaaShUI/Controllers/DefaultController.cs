using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VHaaSh.WEB.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult About()
        {
            return View();
        }
        public ActionResult Blog()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Class()
        {
            return View();
        }
        public PartialViewResult BmiPartialView()
        {
            return PartialView("BMI");
        }

        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult feature()
        {
            return View();
        }
        public ActionResult Single()
        {
            return View();
        }
    }
}