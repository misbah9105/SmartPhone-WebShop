using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class ProductController : Controller
    {
        Model1 db = new Model1();
        // GET: Product
        public ActionResult AllProduct()
        {
            List<Product> prolist = db.Products.ToList();
            return View(prolist);
        }
    }
}