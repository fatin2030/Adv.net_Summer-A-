using System;
using AutoMapper;

using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PMSDemo.Auth;
using SampleProject.EF;



namespace SampleProject.Controllers
{

  //  [AdminAccess]
    public class AdminController : Controller
    {
        DemoProjectEntities db = new DemoProjectEntities();

        // GET: Admin
        [AdminAccess]

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Orders()
        {


            return View(OrderController.Convert(db.Orders.ToList()));

        }

        public ActionResult Products()
        {
            return View(ProductController.Convert(db.Products.ToList()));
        }

        [HttpGet]
        public ActionResult Od(int id)
        {
            var data = (from order in db.OrderProducts
                        where order.OId == id
                        select order).ToList();

            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<OrderProduct, DTOs.OrderProductDTO>();
                cfg.CreateMap<Product, DTOs.ProductDTO>();

            });
            var mapper = new Mapper(config);
            var pd = mapper.Map<List<DTOs.OrderProductDTO>>(data);
            return View(pd);
        }
        public ActionResult Decline(int id)
        {
            var order = db.Orders.Find(id);
            order.Status = "Declined";
            db.SaveChanges();
            TempData["Msg"] = "Order Id " + id + " declined";
            return RedirectToAction("Orders");
        }    
        public ActionResult Accept(int id)
        {
            var order = db.Orders.Find(id);
            order.Status = "Accpted";
            db.SaveChanges();
            TempData["Msg"] = "Order Id " + id + " Accepted";
            return RedirectToAction("Orders");
        }
    }
}