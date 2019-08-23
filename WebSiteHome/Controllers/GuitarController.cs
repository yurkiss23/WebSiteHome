using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSiteHome.Models;

namespace WebSiteHome.Controllers
{
    public class GuitarController : Controller
    {
        private readonly ApplicationDbContext _context;
        public GuitarController()
        {
            _context = new ApplicationDbContext(); 
        }
        // GET: Guitar
        public ActionResult Index()
        {
            var model = _context.Guitars.ToList();
            return View(model);
        }

        public ActionResult Strat()
        {
            return View();
        }
    }
}