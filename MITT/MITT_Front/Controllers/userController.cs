using Microsoft.AspNetCore.Mvc;
using MITT_Front.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MITT_Front.Controllers.user
{
    public class userController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            User_Identity user_identity = new User_Identity();
            return View(user_identity);
        }

        [HttpGet]
        public ActionResult Register()
        {
            UserProfile user = new UserProfile
            {
                user_identity = new User_Identity()
            };
            return View(user);
        }
    }
}
