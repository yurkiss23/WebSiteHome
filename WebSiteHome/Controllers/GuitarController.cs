using Microsoft.AspNet.Identity.Owin;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using WebSiteHome.Entities;
using WebSiteHome.Models;

namespace WebSiteHome.Controllers
{
    public class GuitarController : Controller
    {
        private readonly ApplicationDbContext _context;
        private ApplicationUserManager _userManager;
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
            ComborAddViewModel model = new ComborAddViewModel();
            return View(model);
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Add(ComborAddViewModel model)
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
        //[Authorize(Roles = "Admin")]
        public ActionResult AddUser()
        {
            UserAddViewModel model = new UserAddViewModel();
            return View(model);
        }
        [HttpPost]
        //[Authorize(Roles = "Admin")]
        public ActionResult AddUser(UserAddViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = new ApplicationUser
            {
                Email = model.Email,
                UserName = model.Email
            };
            string password = RandomPassword();
            string regex = @"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?!.*\s).{6,9}$";
            var match = Regex.Match(password, regex, RegexOptions.IgnoreCase);
            if (!match.Success)
            {
                //Console.WriteLine($"Поганий пароль - {str}");
            }
            var res = UserManager.CreateAsync(user, "Qwerty1-").Result;
            if (res.Succeeded)
            {
                User newUser = new User
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    DateBirth = Convert.ToDateTime(model.DateBirth),
                    DateAdd = DateTime.Now,
                    Email = model.Email,
                    Phone = model.Phone,
                    Status = 0,
                };
                _context.SiteUsers.Add(newUser);
                _context.SaveChanges();

                var client = new SmtpClient("smtp.gmail.com", 587)
                {
                    Credentials = new NetworkCredential("yurec.centr@gmail.com", "terranet"),
                    EnableSsl = true
                };
                client.Send("yurec.centr@gmail.com", model.Email, "Новий пароль", $"Пароль: {password}");
            }

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

        private string RandomPassword()
        {
            const string valid = "abcdefghjkmnpqrstuvwxyz";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random(Guid.NewGuid().GetHashCode());
            int length = rnd.Next(5, 8);
            while (0 <= length--)
            {
                res.Append(valid[rnd.Next(0, valid.Length)]);
                //Thread.Sleep(30);
            }
            return CheckPassword(res.ToString());
        }
        private string CheckPassword(string pass)
        {
            const string BigLeter = "ABCDEFGHJKMNPQRSTUVWXYZ";
            const string number = "23456789";
            const string symb = "-";
            int countNum = 0, countBigLet = 0, countSymb = 0;
            Random random = new Random(Guid.NewGuid().GetHashCode());
            char[] pas = pass.ToCharArray();

            for (int i = random.Next(0, pas.Length); i < pas.Length; i = random.Next(0, pas.Length))
            {
                if (Char.IsLower(pas[i]))
                {
                    pas[i] = number[random.Next(number.Length)];
                    //Thread.Sleep(30);
                    countNum++;
                }
                if (countNum == 2)
                    break;
            }
            for (int i = random.Next(0, pas.Length); i < pas.Length; i = random.Next(0, pas.Length))
            {
                if (Char.IsLower(pas[i]))
                {
                    pas[i] = BigLeter[random.Next(BigLeter.Length)];
                    //Thread.Sleep(30);
                    countBigLet++;
                }
                if (countBigLet == pas.Length - 5)
                    break;
            }
            for (int i = random.Next(0, pas.Length); i < pas.Length; i = random.Next(0, pas.Length))
            {
                if (Char.IsLower(pas[i]) || Char.IsUpper(pas[i]))
                {
                    pas[i] = symb[random.Next(symb.Length)];
                    //Thread.Sleep(30);
                    countSymb++;
                }
                if (countSymb == 1)
                    break;
            }
            pass = new string(pas);
            return pass;
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
    }
}