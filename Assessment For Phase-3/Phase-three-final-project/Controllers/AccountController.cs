using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Phase_three_final_project.Helpers;
using Phase_three_final_project.Models;

namespace Phase_three_final_project.Controllers
{
    public class AccountController : Controller
    {
        ApplicationDBContext context;
         List<SelectListItem> UserType { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "Admin", Text = "Admin" },
            new SelectListItem { Value = "User", Text = "User" },
        };

        public AccountController()
        {
            context = new ApplicationDBContext();
        }
        public IActionResult Index()
        {
            ViewData["UserType"] = UserType;
            return View();
        }

        [HttpPost]

        public IActionResult Login(User user)
        {
            var userObj = context.User.Where(u => u.Username == user.Username
              && u.Password == user.Password
              && u.UserType == user.UserType).SingleOrDefault();
            if (userObj != null)
            {

                SessionHelper.setObjectasJson(HttpContext.Session, "user", userObj);
                // HttpContext.Session.SetString("username", "admin");
                User usr = SessionHelper.GetObjectFromJson<User>(HttpContext.Session, "user");
                if (usr.UserType == "Admin")
                    return RedirectToAction("Index", "Home");

                return RedirectToAction("Index", "Home");


            }

            else
            {
                ViewBag.Error = ("Invalid Credentials.");
                ViewData["UserType"] = UserType;
                return View("Index");
            }
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }

        public IActionResult RegisterForm()
        {
            ViewData["UserType"] = UserType;
            return View("Register");
        }
            public IActionResult Register(string username, string password, string confirmPassword, string userType)
        {
            if (password != confirmPassword)
            {
                ViewBag.Error = "Passowrds do not match";
                ViewData["UserType"] = UserType;
                return View("Register");
            }
            else
            {
                User userModel = new User
                {
                    Username = username,
                    Password = password,
                    UserType = userType
                };
                context.User.Add(userModel);
                context.SaveChanges();

                SessionHelper.setObjectasJson(HttpContext.Session, "user", userModel);
                return RedirectToAction("Index", "Product");
            }
        }


    }
}


