using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VHaaSh.WEB.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        // [AllowAnonymous]
        public ActionResult Index()
        {
            // returns view cotent
            return View();
        }

        public ActionResult Welcome()
        {
            return View();
        }
    }
}