using AutoMapper;
using DemoBlog2.Auth;
using DemoBlog2.DTOs;
using DemoBlog2.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoBlog2.Controllers
{
    [Logged]
    public class UserController : Controller
    {
        BlogSite_PracticeEntities db = new BlogSite_PracticeEntities();

        // GET: User

        public ActionResult Index()
        {
           var id  = ((User)Session["user"]).Id;


            var recnt =  db.Posts.OrderByDescending(x => x.PostTime).Take(1).ToList();

            ViewBag.recnt = recnt;
         

            var data1 = (from u in db.Posts
                         where u.UId.Equals(id) 
                         select u).ToList();
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Post, PostDTO>();
               cfg.CreateMap<Comment, CommentDTO>();
                cfg.CreateMap<User, UserDTO>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<List<PostDTO>>(data1);


            return View(data);
        }
    }
}