using Lab1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Information info = new Information()
            {
                Name ="Fatin Noor",
                Email = "fatin@gmail.com",
                Phone = "0100000000",
                Degree ="Bsc Cse",
                Expertise ="Nai"

            };
            ViewBag.myInfo = new Information[] { info};
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Education()
        {
            Education ssc = new Education()
            {
                Title = "SSC",
                Year ="2018",
                Group ="Science",
                Ins = "CMHS"  

            }; Education hsc = new Education()
            {
                Title ="HSC",
                Year ="2020",
                Group ="Science",
                Ins = "ADC"  

            };

            ViewBag.Educations = new Education[] { ssc, hsc };

            return View();

        }

        public ActionResult Projects()
        {
            Project web = new Project() { 
                Title ="Plan My Trip",
                Description ="gdgduywafy",
                Course = "Web tech"
            }; Project sqt = new Project() { 
                Title ="Title1",
                Description ="abc",
                Course = "SQT"
            }; Project java = new Project() { 
                Title ="Title 3",
                Description ="abcd",
                Course = "Java"
            };

            ViewBag.Projects = new Project[] { web, sqt, java };



            return View();
        }

        public ActionResult Reference() { 

            return View();
        
        }

    }
}