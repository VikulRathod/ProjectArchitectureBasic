using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VHaaSh.WEB.Controllers
{
    public class HotelUiController : Controller
    {
        // GET: HotelUi
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult services()
        {
            return View();
        }

        public ActionResult gallery()
        {
            return View();
        }
        public ActionResult restaurant()
        {
            return View();
        }
        public ActionResult testimonials()
        {
            return View();
        }
        public ActionResult booking()
        {
            return View();
        }
    }
}