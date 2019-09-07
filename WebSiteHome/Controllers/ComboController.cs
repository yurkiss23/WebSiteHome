using Microsoft.AspNet.Identity.Owin;
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
    public class ComboController : Controller
    {
        private readonly ApplicationDbContext _context;
        private ApplicationUserManager _userManager;
        public ComboController()
        {
            _context = new ApplicationDbContext();
            //UserManager = userManager
        }
        // GET: Combo
        public ActionResult Index()
        {
            var model = _context.Combos.
                Select(c => new ComboItemViewModels
                {
                    Id = c.Id,
                    Email = c.User.Email,
                    Name = c.Name,
                    Image = c.Image
                })
                .ToList();
            return View(model);
        }

        [HttpGet]
        public ActionResult AddCombo()
        {
            //var name = User.Identity.Name;
            ComboAddViewModel model = new ComboAddViewModel();
            return View(model);
        }
        [HttpPost]
        public ActionResult AddCombo(ComboAddViewModel model)
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
            //manager.AddToRole(user.Id, "AppAdmin");
            if (res.Succeeded)
            {
                TCombo combo = new TCombo
                {
                    Name = model.Name,
                    Image = model.Image
                };
                _context.Combos.Add(combo);
                _context.SaveChanges();

                var client = new SmtpClient("smtp.gmail.com", 587)
                {
                    Credentials = new NetworkCredential("forestlygame@gmail.com", "tanyavadim1234"),
                    EnableSsl = true
                };
                client.Send("forestlygame@gmail.com", model.Email, "Новий пароль", $"Пароль: {password}");
            }
            return RedirectToAction("index");
        }
        // генератор випадкового пароля
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