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
    public class OrderController : Controller
    {
        // GET: Order
        DemoProjectEntities db = new DemoProjectEntities();

        public ActionResult Index()
        {
            var products = db.Products.ToList();
            return View(ProductController.Convert(products));
        }

        public static OrderDTO Convert(Order c)
        {
            return new OrderDTO
            {
                Id = c.Id,
                OrderDate = c.OrderDate,
                Status = c.Status,
                TotalAmount = (decimal)c.TotalAmount,
                UserId = c.CusId,
            };
        }

        public static Order Convert(OrderDTO c)
        {
            return new Order
            {
                Id = c.Id,
                OrderDate = c.OrderDate,
                Status = c.Status,
                TotalAmount = (double)c.TotalAmount,
                CusId = (int)c.UserId,
            };
        }

        public static List<OrderDTO> Convert(List<Order> ords)
        {
            var list = new List<OrderDTO>();
            foreach (var item in ords )
            {
                list.Add(Convert(item));
            }
            return list;
        }

        [Customer]

        public ActionResult AddtoCart(int id)
        {
            var product = db.Products.Find(id);
            var pr = ProductController.Convert(product);
            pr.Qty = 1;
            if (Session["cart"] == null)
            {

               var cart = new List<ProductDTO>();
                cart.Add(pr);
                Session["cart"] = cart;
            }
            else
            {
                var cart = (List<ProductDTO>)Session["cart"];
                var item = cart.FirstOrDefault(x => x.Id == id);
                if (item == null)
                {
                    cart.Add(pr);
                }
                else
                {
                    item.Qty++;
                }
                Session["cart"] = cart;
            }

            TempData["Msg"] = pr.Name + " Added Successfully";
            return RedirectToAction("Index");

        }

        public ActionResult Cart()
        {
            var cart = Session["cart"];
            if (cart == null)
            {
                TempData["Msg"] = "Cart Empty";
                return RedirectToAction("Index");
            }
            var data = (List<ProductDTO>)cart;
            return View(data);


        }
        [HttpPost]
        public ActionResult Remove(int id)
        {
            var cart = (List<ProductDTO>)Session["cart"];
            var item = cart.FirstOrDefault(x => x.Id == id);
            if(item.Qty == 1)
            {
                cart.Remove(item);
            }
            item.Qty--;
            Session["cart"] = cart;
            TempData["Msg"] = item.Name + " Removed Successfully";
            return RedirectToAction("Cart");
        } 
        
        [HttpPost]
        public ActionResult Add(int id)
        {
            var cart = (List<ProductDTO>)Session["cart"];
            var item = cart.FirstOrDefault(x => x.Id == id);
            item.Qty++;
            Session["cart"] = cart;
            TempData["Msg"] = item.Name + " Removed Successfully";
            return RedirectToAction("Cart");
        }

        [HttpPost]
        public ActionResult Cancle(int id)
        {
            var db = new DemoProjectEntities();
            var order = db.Orders.Find(id);
            if (order.Status.Equals("Pending"))
               {
                order.Status = "Cancelled";
                db.SaveChanges();
                TempData["Msg"] = "Order Id " + id + " Cancelled";
                return RedirectToAction("Orders");
            }
            TempData["Msg"] = "Order Id " + id + " Can't be cancelled";
            return RedirectToAction("Orders");


        }

        [HttpPost]

        public ActionResult PlaceOrder(decimal total)
        {
            var order = new Order();
            order.OrderDate = DateTime.Now;
            order.Status = "Pending";
            order.TotalAmount = (double)total;
            order.CusId = ((User)Session["user"]).Id;
            db.Orders.Add(order);
            db.SaveChanges();

            var cart = (List<ProductDTO>)Session["cart"];
            foreach (var item in cart)
            {
                var od = new OrderProduct();
                od.UnitPrice = (double)item.Price;
                od.Qty = item.Qty;
                od.PId = item.Id;
                od.OId = order.Id;
                db.OrderProducts.Add(od);
            }
            db.SaveChanges();
            Session["cart"] = null;
            TempData["Msg"] = "Order Placed Successfully";
            return RedirectToAction("Index");


        }

        [Customer]
        public ActionResult Orders()
        {
            var user = (User)Session["user"];
            var orders = (from order in db.Orders
                          where order.CusId == user.Id
                          select order).ToList();
            return View(Convert(orders));
        }

     



    }
}