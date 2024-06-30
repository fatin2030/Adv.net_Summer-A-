using PMSDemo.Auth;
using SampleProject.DTOs;
using SampleProject.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SampleProject.Controllers
{
    [Customer]
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            
            return View();

        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register (RegistrationDTO rgt)
        {
            var db = new DemoProjectEntities();


            if (ModelState.IsValid)
            {
                var check = (from u in db.Users
                             where u.Uname == rgt.Uname
                             select u).FirstOrDefault();

                if (check != null)
                {
                    TempData["Msg"] = "Username Already Exists";
                    return View();
                }
                rgt.Role = "User";
                var user = Convert(rgt);

                db.Users.Add(user);
                db.SaveChanges();
                TempData["Msg"] = "rEGISTRATION Placed Successfully";
                return RedirectToAction("Index", "Home");

            }

            return View();
        }

      

        public static User Convert(RegistrationDTO rgt)
        {
            return new User()
            {
               Uname = rgt.Uname,
               Pass = rgt.Pass,
               Role = rgt.Role
            };
        }

        [HttpPost]
        public ActionResult Cancle(int id)
        {
            var db = new DemoProjectEntities();
            var order = db.Orders.Find(id);
            order.Status = "Cancelled";
            db.SaveChanges();
            TempData["Msg"] = "Order Id " + id + " Cancelled";
            return RedirectToAction("Orders");


        }




    }
}