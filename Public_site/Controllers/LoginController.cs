using Public_site.Models;
using RwaLib.DAL;
using RwaLib.MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Public_site.Controllers
{
    public class LoginController : Controller
    {
        private IRepo _repo;
        public LoginController()
        {
            _repo = RepoFactory.GetRepo(); 
        }

        [HttpGet]
        public ActionResult Index()
        {
            if (Session["user"]!=null)
                return RedirectToAction("Index", "Home");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(UserLogin viewLogin)
        {
            if (ModelState.IsValid)
            {
                User user = _repo.AuthUser(viewLogin.UserName, Cryptography.HashPassword(viewLogin.Password));
                if (user != null)
                {
                    Session["user"] = user;
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(viewLogin);
        }

        [HttpGet]
        public ActionResult Logout()
        {
            Session.RemoveAll();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}