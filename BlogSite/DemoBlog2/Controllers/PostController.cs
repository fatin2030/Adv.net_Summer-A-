using AutoMapper;
using DemoBlog2.Auth;
using DemoBlog2.DTOs;
using DemoBlog2.EF;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace DemoBlog2.Controllers
{
    [Logged]

    public class PostController : Controller
    {
        // GET: Post

        BlogSite_PracticeEntities db = new BlogSite_PracticeEntities();


        public static Mapper getMapper()
         {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Post, PostDTO>();
                cfg.CreateMap<PostDTO, Post>();
               cfg.CreateMap<Comment, CommentDTO>();
              cfg.CreateMap<CommentDTO, Comment>();
                cfg.CreateMap<List<PostDTO>, List<Post>>();
            });
            return new Mapper(config);
        }
        public ActionResult Index()
        {
            return View();
        }



        [HttpGet]

        public ActionResult CreatePost()
        {

            return View(new PostDTO());
        }

        [HttpPost]
        public ActionResult CreatePost(PostDTO p)
        {
            p.UId = ((User)Session["user"]).Id;
            p.PostTime = DateTime.Now;
            var mapper = getMapper();
            var post = mapper.Map<Post>(p);
            db.Posts.Add(post);
            db.SaveChanges();


            return RedirectToAction("ViewPost", "Post");
        }

        [HttpGet]
        public ActionResult ViewPost()
        {
            var posts = db.Posts.ToList();
            var mapper = getMapper();
            var post = mapper.Map<List<PostDTO>>(posts);

            return View(post);
        }

        [HttpGet]
        public ActionResult EditPost(int id)
        {
            var postdata = db.Posts.Find(id);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Post, PostDTO>();

                cfg.CreateMap<Comment, CommentDTO>();
                cfg.CreateMap<User, UserDTO>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<PostDTO>(postdata);

            return View(data);
        }

        [HttpPost]

        public ActionResult EditPost(PostDTO pst)
        {
            var u = pst.UId;
            var userID = ((User)Session["user"]).Id;

            if (u == userID)
            {
                var post = db.Posts.Find(pst.id);
                post.Id = pst.id;
                post.Title = pst.Title;
                post.PostContent = pst.PostContent;
                post.PostTime = post.PostTime;

                db.SaveChanges();
                return RedirectToAction("Index", "user");
            }
            TempData["msg"] = "Wrong Instructions";
            return RedirectToAction("Index", "user");

        }



        public ActionResult Comments(int id)
        {

            var data = db.Posts.Find(id);
            var mapper = getMapper();
            var c = mapper.Map<PostDTO>(data);
            Session["post"] = c;
            return View(c);
           
        }


        [HttpGet]

        public ActionResult AddComment()
        {
            return View(new CommentDTO());
        }

        [HttpPost]

        public ActionResult AddComment(CommentDTO cmt)
        {
            cmt.UId = ((User)Session["user"]).Id;
            //cmt.PId = ((Post) Session["post"]).Id;

            cmt.CommentTime = DateTime.Now;



            var map = getMapper();
            var map1 = map.Map<Comment>(cmt);

            db.Comments.Add(map1);
            db.SaveChanges();

            return (null);


        }


        public ActionResult Like(int id)
        {
            var po = db.Posts.Find(id);
            var data = (from u in db.Reactions
                        where
                        u.UId.Equals(po.UId) && u.PId.Equals(id)
                        select u).FirstOrDefault();

            var userid = ((User)(Session["user"])).Id;
            if (data != null)
            {
                if (data.Likes == 0)
                {
                    data.Id = data.Id;
                    data.Likes = +1;
                    data.ReactionNumber = data.Likes + data.DisLikes;
                    data.UId = po.Id;
                    data.PId = id;
                    db.SaveChanges();
                    TempData["msg"] = "Liked";
                    return RedirectToAction("Index", "User");

                }
                else if (po.UId == data.UId)
                {
                    data.Likes = -1;
                    data.ReactionNumber = data.Likes + data.DisLikes;

                    db.SaveChanges();
                    TempData["msg"] = " DisLiked";

                    return RedirectToAction("Comments" + id, "Post");

                }
                db.Reactions.Remove(data);
                db.SaveChanges();
                return RedirectToAction("Index", "User");
            }

            var React = new Reaction
            {
                ReactionNumber = +1,
                UId = po.UId,
                PId = id,
                Likes = +1,
                DisLikes = 0,


            };

            db.Reactions.Add(React);
            db.SaveChanges();
            TempData["msg"] = "Liked";

            return RedirectToAction("ViewPost", "User"); ;

        }

        [HttpPost]
        public ActionResult DeletePost(int id)
                    {
            var pst = db.Posts.Find(id);

            if (pst != null)
            {
                var cmt = (from u in db.Comments
                           where
                           u.PId == id
                           select u).ToList();
                if (cmt != null)
                {
                    foreach (var q in cmt)
                    {
                        db.Comments.Remove(q);
                    }

                 

                }
                var lk = (from l in db.Reactions
                          where
                          l.PId == id
                          select l).ToList();
                if (lk != null)
                {
                    foreach (var u in lk)
                    {
                        db.Reactions.Remove(u);
                    }
                    db.Posts.Remove(pst);
                    db.SaveChanges();
                    return RedirectToAction("index", "user");


                }
                db.SaveChanges();
                return RedirectToAction("index", "user");


            }

            else
            {
                TempData["msg"] = "Unable to delete";
                return RedirectToAction("user", "index");
            }
            TempData["msg"] = "Unable to delete";
            return RedirectToAction("user", "index");

        }






    }

        
 }

   
