using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(RegisterModel user)
        {
            UserManage userM = new UserManage();
            Model1 db = new Model1();
            if (ModelState.IsValid)
            {
                if (userM.CheckEmail(user.email) == false && userM.CheckAccount(user.username) == false)
                {
                    User userDB = new User
                    {
                        Name = user.name,
                        Address=user.address,
                        PhoneNumber=user.phone,
                        Account = user.username,
                        Email = user.email,
                        Password = Encrypt.Encrypts(user.Password)
                    };
                    db.Users.Add(userDB);
                    db.SaveChanges();
                    return RedirectToAction("Login", "User");
                }
                else
                {
                    ModelState.AddModelError("RegisterFail", "Đăng ký không thành công");
                    ViewBag.notification = "Username or Email already exist";
                }
            }
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginModel user)
        {
            LoginManage userM = new LoginManage();
            Model1 db = new Model1();
            if (ModelState.IsValid)
            {
                User userDB = new User
                {
                    Account = user.username,
                    Password = user.Password
                };
                if((userM.CheckAccount(user.username) && userM.CheckPassword(Encrypt.Encrypts(user.Password))) == true)
                {
                    Session["user"] = user.username;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("LoginFail", "Login Fail");
                    ViewBag.notification = "Username or Password incorrect";
                }
            }
            return View();
        }
        public ActionResult Logout()
        {
            Session["user"] = null;
            return RedirectToAction("Index", "Home");
        }
    }
}