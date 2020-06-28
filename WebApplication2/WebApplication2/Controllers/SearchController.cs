using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        Model1 db = new Model1();
        public ActionResult SearchProd(string keyword)
        {
            List<Product> product = db.Products.Where(s => s.ProductName.Contains(keyword)).ToList();
            return View(product);
        }
        [ChildActionOnly]
        public PartialViewResult SearchBox()
        {
            Product pro = new Product();
            string keyword = pro.ProductName;
            return PartialView(keyword);
            //return PartialView();
        }
    }
}