using LabTask2.DTOs;
using LabTask2.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace LabTask2.Controllers
{
    public class CourseController : Controller
    {
        // GET: Course
        public ActionResult Index()
        {
            LabTask2Entities db = new LabTask2Entities();
            var data = db.Courses.ToList();
            return View(data);
        }

        public static CourseDTO Convert(Cours c)
        {
            return new CourseDTO()
            {
                Title = c.Title,
                CreditHour = c.CreditHour,
                Type = c.Type
            };
        }
        public static Cours Convert(CourseDTO c)
        {
            return new Cours()
            {

                Title = c.Title,
                CreditHour = c.CreditHour,
                Type = c.Type
            };
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CourseDTO c)
        {
            LabTask2Entities db = new LabTask2Entities();

            if (ModelState.IsValid)
            {
                var cr = Convert(c);
                db.Courses.Add(cr);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            LabTask2Entities db = new LabTask2Entities();
            var exobj = db.Courses.Find(id);
            return View(exobj);

        }
        [HttpPost]
        public ActionResult Edit(Cours c)
        {
            LabTask2Entities db = new LabTask2Entities();
            var exobj = db.Courses.Find(c.Id);
            exobj.Title = c.Title;
            exobj.CreditHour = c.CreditHour;
            exobj.Type = c.Type;

          
            db.SaveChanges();

            return RedirectToAction("Index");
        } 
        
        [HttpGet]
        public ActionResult Delete(int id)
        {
            LabTask2Entities db = new LabTask2Entities();
            var exobj = db.Courses.Find(id);
            return View(exobj);

        }
        [HttpPost]
        public ActionResult Delete(Cours c)
        {
            LabTask2Entities db = new LabTask2Entities();
            var exobj = db.Courses.Find(c.Id);
            db.Courses.Remove(exobj);
           

          
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Details(int? id)
        {
            LabTask2Entities db = new LabTask2Entities();

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cours course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }


    }
}