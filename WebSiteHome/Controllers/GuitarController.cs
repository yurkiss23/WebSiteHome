using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
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
        [Authorize(Roles = "Admin")]
        public ActionResult Add()
        {
            var name = User.Identity.Name;
            GuitarAddViewModel model = new GuitarAddViewModel();
            return View(model);
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
        public ActionResult AddUser()
        {
            UserAddViewModel model = new UserAddViewModel();
            return View(model);
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult AddUser(UserAddViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            User user = new User
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                DateBirth = Convert.ToDateTime(model.DateBirth),
                DateAdd = DateTime.Now,
                Email = model.Email,
                Phone = model.Phone,
                Status = 0,
                Password = model.Password
            };
            _context.SiteUsers.Add(user);
            _context.SaveChanges();

            //using (WebClient client=new WebClient())
            //{
            //    string url = "http://localhost:56927/api/Message";
            //    client.Encoding = Encoding.UTF8;
            //    client.Headers.Add("Content-Type", "application/json");
            //    //string method = "POST";
            //    string data = JsonConvert.SerializeObject(new
            //    {
            //        FirstName = model.FirstName,
            //        LastName = model.LastName,
            //        Email = model.Email
            //        //Body = "user added"
            //    });
            //    var result = client.UploadString(url, "POST", data);
            //}

            return RedirectToAction("users");
        }
        [HttpGet]
        public ActionResult Block()
        {
            UserBlockViewModel model = new UserBlockViewModel();
            return View(model);
        }
        [HttpPost]
        public ActionResult Block(UserBlockViewModel model)
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