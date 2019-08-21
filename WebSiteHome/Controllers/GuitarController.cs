using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebSiteHome.Controllers
{
    public class GuitarController : Controller
    {
        // GET: Guitar
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Strat()
        {
            return View();
        }
    }
}