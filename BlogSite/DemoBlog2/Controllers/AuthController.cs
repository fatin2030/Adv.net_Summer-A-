using AutoMapper;
using DemoBlog2.Auth;
using DemoBlog2.DTOs;
using DemoBlog2.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using System.Xml.Linq;

namespace DemoBlog2.Controllers
{
    public class AuthController : Controller
    {
        // GET: Auth
        BlogSite_PracticeEntities db = new BlogSite_PracticeEntities();

        public ActionResult Index()
        {
            return View();
        }

        public static UserDTO convert(User user)
        {
            return new UserDTO
            {
                Id = user.Id,
                Uname = user.Uname,
                FName = user.Name.Split(' ')[0],
                LName = user.Name.Split(' ')[1],
                Gender = user.Gender,
                Type = user.Type,
                Password = user.Password,
                Status = user.Status,
                LogTime = user.Logtime
            };
        }
        [HttpGet]

        public ActionResult Login()
        {
            if (Request["ReturnUrl"] != null) {
                ViewBag.URL = Request["ReturnUrl"];
            }
            return View(new LoginDTO());
        }


        [HttpPost]
        
        public ActionResult Login(LoginDTO l,string URL)
        {

            var user = (from u in db.Users where 
                        u.Uname==l.uname && u.Password ==l.Password
                        select u).FirstOrDefault();
            if(user !=null)
            {
                if (URL != null && !URL.Equals(""))
                {
                    Session["user"] = user;
                    TempData["msg"] = "Welcome " + user.Name;
                    return Redirect(URL);

                }

                else
                {
                  
                    Session["user"] = user;
                    TempData["msg"] = "Welcome " + user.Name;
                   
                    return RedirectToAction("Index", "User");
                }


            }
            else
            {
                TempData["Msg"] = "Please Check your Credensial";

                TempData["msg"] = "Login Failed";
                return View(l);
            }
        }

        [HttpGet]

        public ActionResult Registration()
        {

           return View(new UserDTO());
        }

        [HttpPost]
         public ActionResult Registration(UserDTO u)
        {
            var user = (from l in db.Users where
                        u.Uname.Equals(l.Uname)
                        select l).FirstOrDefault();

            if (user != null)
            {
                TempData["msg"] = "User Already Exists";
                return View(u);
            }
            else
            {


                u.LogTime = DateTime.Now;
                u.Status = 1;
                u.Type = "User";
                var config = new MapperConfiguration(cfg => {
                    cfg.CreateMap<UserDTO, User>();

                });
                var mapper = new Mapper(config);
                var pd = mapper.Map<User>(u);
                pd.Name = u.FName.Trim() + " " + u.LName.Trim();
               
                db.Users.Add(pd);
                db.SaveChanges();
                TempData["msg"] = "Registration Successful";
                return RedirectToAction("Login", "Auth");
            }
           
         
        }

        public ActionResult LogOut()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Auth");
        }


    }
}