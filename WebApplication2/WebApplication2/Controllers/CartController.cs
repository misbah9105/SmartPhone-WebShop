using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        Model1 db = new Model1();
        private const string CartSession = "CartSession";
        public ActionResult Cart()
        {
            var cart = Session[CartSession];
            var listCart = new List<Cart>();
            if(cart != null)
            {
                listCart = (List<Cart>)cart;
            }
            return View(listCart);
        }
        public ActionResult AddToCart(int id)
        {
            if (Session[CartSession]==null)
            {
                Session[CartSession] = new List<Cart>();
            }
            List<Cart> listcart = Session[CartSession] as List<Cart>;
            if(listcart.Exists(m=>m.IDPro==id))
            {
                // Nếu sản phẩm khách chọn đã có trong giỏ hàng thì không thêm vào giỏ nữa mà tăng số lượng lên.
                Cart card = listcart.FirstOrDefault(m => m.IDPro == id);
                card.Quan++;
            }
            else
            {
                Product pro = db.Products.Find(id);
                Cart newItem = new Cart()
                {
                    IDPro = id,
                    Name = pro.ProductName,
                    Quan = 1,
                    Image = pro.Image,
                    Price = pro.Price
                };//tao mot san pham moi trong gio hang
                listcart.Add(newItem);//them san pham vao gio hang
            }
            return RedirectToAction("Cart", "Cart", new { IDpro = id });//ve trang chu cua Cart
        }
        public ActionResult Deleted(int id)
        {
            List<Cart> cart = Session[CartSession] as List<Cart>;
            Cart cartitem = cart.FirstOrDefault(m => m.IDPro == id);
            if (cart != null)
            {
                cart.Remove(cartitem);
            }
            return RedirectToAction("Cart", "Cart");
        }
        public ActionResult Updated(int id, int newQuan)
        {
            // tìm carditem muon sua
            List<Cart> cart = Session["CartSession"] as List<Cart>;
            Cart cartItem = cart.FirstOrDefault(m => m.IDPro == id);
            if (cartItem != null)
            {
                cartItem.Quan = newQuan;
            }
            return RedirectToAction("Cart");
        }
        [ChildActionOnly]
        public PartialViewResult CartInfor()
        {
            var cart = Session[CartSession];
            var ListCart = new List<Cart>();
            if(cart != null)
            {
                ListCart = (List<Cart>)cart;
            }
            return PartialView(ListCart);
        }
        public ActionResult CheckOut()
        {
            var cart = Session[CartSession];
            var listCart = new List<Cart>();
            if (cart != null)
            {
                listCart = (List<Cart>)cart;
            }
            return View(listCart);
        }
        public ActionResult ProcessOrder(FormCollection frc)
        {
            List<Cart> listcart = (List < Cart >) Session[CartSession];
            Invoice invoice = new Invoice()
            {
                CustomerName = frc["cusName"],
                DeliveryAdd = frc["cusAddress"],
                DeliveryDate = DateTime.Now.AddDays(7),
                Status = "Processing..."
            };
            db.Invoices.Add(invoice);
            db.SaveChanges();

            foreach(Cart cart in listcart)
            {
                InvoiceDetail invoiceDetail = new InvoiceDetail()
                {
                    InvoiceCode=invoice.IDInvoice,
                    IDProduct=cart.IDPro,
                    Amount=cart.Quan,
                    ProductPrice=cart.Price,
                    ProductName=cart.Name
                };
                db.InvoiceDetails.Add(invoiceDetail);
                db.SaveChanges();
            }
            Session.Remove(CartSession);
            return View("OrderSuccess");
        }
    }
}