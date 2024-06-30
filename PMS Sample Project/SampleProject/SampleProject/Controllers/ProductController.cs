using SampleProject.DTOs;
using SampleProject.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SampleProject.Controllers
{
    public class ProductController : Controller
    {
        public static Product Convert(ProductDTO c)
        {
            return new Product
            {
                Id = c.Id,
                Name = c.Name,
                Qty = c.Qty,
                Price = (double)c.Price,
                CId = c.CId,
            };  
        }
        public static ProductDTO Convert(Product c)
        {
            return new ProductDTO
            {
                Id = c.Id,
                Name = c.Name,
                Qty = c.Qty,
                Price = (decimal)c.Price,
                CId = c.CId,
            };
        }


        public static List<ProductDTO> Convert(List<Product> cs)
        {
            var list = new List<ProductDTO>();
            foreach (var c in cs)
            {
                list.Add(Convert(c));
            }
            return list;
        }
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }
    }
}