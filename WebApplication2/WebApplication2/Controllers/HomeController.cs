using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        Random random = new Random();
        Model1 db = new Model1();
        public ActionResult Index()
        {
            List<Product> prolist = db.Products.Take(3).ToList();
            return View(prolist);
        }
        [ChildActionOnly]
        public ActionResult Category()
        {
            List<Category> Category = db.Categories.ToList();
            return PartialView(Category);
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
    }
}