using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSiteHome.Entities;
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
            var model = _context.Guitars.
                Select(g => new GuitarItemViewModels
                {
                    Id = g.Id,
                    Name = g.Name,
                    Image = g.Image
                })
                .ToList();
            return View(model);
        }

        [HttpGet]
        public ActionResult Add()
        {
            GuitarAddViewModel model = new GuitarAddViewModel();
            return View(model);
        }
        [HttpPost]
        public ActionResult Add(GuitarAddViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            TGuitar guitar = new TGuitar
            {
                Name = model.Name,
                Image = model.Image
            };
            _context.Guitars.Add(guitar);
            _context.SaveChanges();
            return RedirectToAction("index");
        }

        public ActionResult Users()
        {
            var model = _context.SiteUsers.
                Select(u => new UserItemViewModels
                {
                    Id = u.Id,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    DateAdd = u.DateAdd.ToString(),
                    Email = u.Email,
                    Phone = u.Phone,
                    Status = u.Status
                }).ToList();
            return View(model);
        }
        [HttpGet]
        public ActionResult AddUser()
        {
            UserAddViewModels model = new UserAddViewModels();
            return View(model);
        }
        [HttpGet]
        public ActionResult Block()
        {
            UserBlockViewModels model = new UserBlockViewModels();
            return View(model);
        }
        [HttpPost]
        public ActionResult Block(UserBlockViewModels model)
        {
            Console.WriteLine(model.FirstName);
            return RedirectToAction("users");
        }

        public ActionResult Strat()
        {
            return View();
        }
    }
}