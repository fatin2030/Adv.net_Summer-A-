using SampleProject.DTOs;
using SampleProject.EF;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SampleProject.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            return View();
        }

        public static Category convert(CategoryDTO c)
        {
            return new Category
            {
                Id = c.Id,
                Name = c.Name
            };
        }

        public static CategoryDTO convert(Category c)
        {
            return new CategoryDTO
            {
                Id = c.Id,
                Name = c.Name
            };
        }


    }
}