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
    public class RegistrationController : Controller
    {
        private IRepo _repo;
        public RegistrationController()
        {
            _repo = RepoFactory.GetRepo(); 
        }

        // GET: Registration
        public ActionResult Index()
        {
            if (Session["user"] != null)
                return RedirectToAction("Index", "Home");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(User u)
        {
            if (ModelState.IsValid)
            {
                _repo.CreateUser(u);
                Session["user"] = u;
                return RedirectToAction("Index", "Home");
            }
            return Index();
        }
    }
}