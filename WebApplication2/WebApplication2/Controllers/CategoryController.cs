using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class CategoryController : Controller
    {
        Model1 db = new Model1();
        // GET: Category
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Category(int cateId)
        {
            List<Product> procateid = db.Products.Where(p=>p.IDCategory == cateId).ToList();
            return View(procateid);
        }
        public ActionResult Detail (int productId)
        {
            Product proid = db.Products.Where(p => p.IDProduct == productId).SingleOrDefault();
            return View(proid);
        }
    }
}