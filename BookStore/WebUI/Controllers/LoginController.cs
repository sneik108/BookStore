using Domain.Abstract;
using Domain.Entities;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUI.Global.Auth;
using WebUI.Models;

namespace WebUI.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login

        [Inject]
        public IAuthentication Auth { get; set; }
        [Inject]
        public IRepository sqlRepository { get; set; }

        [HttpGet]
        public ActionResult Index()
        {
            return View(new LoginView());
        }

        public User CurrentUser
        {
            get
            {
                return ((IUserProvider)Auth.CurrentUser.Identity).User;
            }
        }
        public ActionResult UserLogin()
        {
            var test = CurrentUser;
            return View(CurrentUser);
        }

        [HttpPost]
        public ActionResult Index(LoginView loginView)
        {
            if (ModelState.IsValid)
            {
                var user = Auth.Login(loginView.Email, loginView.Password, loginView.IsPersistent);
                if (user != null)
                {
                    return RedirectToRoute(new { controller = "Books", action = "List" });
                }
                ModelState["Password"].Errors.Add("Не существует такого пользователя");
            }
            return View(loginView);
        }
        public ActionResult Logout()
        {
            Auth.LogOut();
            return RedirectToAction("Index", "Login");
        }

        public ActionResult Register()
        {
            var newUserView = new UserView();
            return View(newUserView);
        }
        [HttpPost]
        public ActionResult Register(UserView userView)
        {
            var anyUser = sqlRepository.Users.Any(p => string.Compare(p.Email, userView.Email) == 0);
            if (anyUser)
            {
                ModelState.AddModelError("Email", "Пользователь с таким email уже зарегистрирован");
            }

            if (ModelState.IsValid)
            {
                List<Role> roles = new List<Role>(new[] { new Role { Name = "Пользователь", Code = "User" } });
                User user = new User()
                {
                    Email = userView.Email,
                    Password = userView.Password,
                    Roles = roles,
                    AddedDate = DateTime.Now,
                };
                sqlRepository.CreateUser(user);
                IEnumerable<User> users = sqlRepository.Users;

                return RedirectToAction("Index");
            }
            return View(userView);
        }
    }
}
