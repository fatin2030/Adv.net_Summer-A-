using SampleProject.DTOs;
using SampleProject.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SampleProject.Controllers
{
    public class AuthController : Controller
    {
        DemoProjectEntities db = new DemoProjectEntities();

        // GET: Auth
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost] 
        public ActionResult Login(LoginDTO l)
        {
            if (ModelState.IsValid)
            {
                var user = (from u in db.Users
                            where u.Uname.Equals(l.Uname) &&
                            u.Pass.Equals(l.Pass)
                            select u).SingleOrDefault();
                if (user == null)
                {
                    TempData["Msg"] = "User not found / Uname pass mismatch";
                    return RedirectToAction("Index");
                }
                Session["user"] = user;
                TempData["Msg"] = "Login Successfull";
                if (user.Role.Equals("Admin"))
                {
                    return RedirectToAction("Index", "Admin");
                }
                return RedirectToAction("Index", "User");
            }
            return View(l);
        }

    }
}