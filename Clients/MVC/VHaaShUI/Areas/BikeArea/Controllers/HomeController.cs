using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VHaaSh.WEB.Areas.BikeArea.Controllers
{
    public class HomeController : Controller
    {
        // GET: BikeArea/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}