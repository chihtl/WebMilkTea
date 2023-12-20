using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAdmin.Models;

namespace WebAdmin.Controllers
{
    public class ShoppingCartController : Controller
    {
        OnlineShop _db = new OnlineShop();

        // GET: Cart
        public Cart GetCart()
        {
            Cart cart = Session["Cart"] as Cart;
            if (cart == null || Session["Cart"] == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }
        // phuoung thuc add
        public ActionResult AddToCart(int id)
        {
            var pro = _db.Products.SingleOrDefault(s => s.ID == id);
            if (pro != null)
            {
                GetCart().Add(pro);
            }
            return RedirectToAction("ShowToCartt", "ShoppingCart");

        }
        //phuong thuc hien thi
        public ActionResult ShowToCartt()
        {
            if (Session["Cart"] == null)
                return RedirectToAction("ShowToCartt", "ShoppingCart");
            Cart cart = Session["Cart"] as Cart;
            return View(cart);
        }
        public ActionResult Update_Quantity_Cart(FormCollection form)
        {
            Cart cart = Session["Cart"] as Cart;
            int id_pro = int.Parse(form["ID_Product"]);
            int quantity = int.Parse(form["Quantity"]);
            cart.Update_Quantity_Shopping(id_pro, quantity);
            return RedirectToAction("ShowToCartt", "ShoppingCart");
        }
        public ActionResult RemoveCart(int id)
        {
            Cart cart = Session["Cart"] as Cart;
            cart.Remove_CartItem(id);
            return RedirectToAction("ShowToCartt", "ShoppingCart");
        }
        public PartialViewResult BagCart()
        {
            int total_item = 0;
            Cart cart = Session["Cart"] as Cart;
            if (cart != null)

                total_item = cart.Total_Qiantity_in_Cart();
            ViewBag.QuantityCart = total_item;
            return PartialView("BagCart");

        }
        public ActionResult Shooping_Success()
        {
            return View();
        }
        public ActionResult oder()
        {
            return View();
        }

        // POST: YourController/YourAction
        [HttpPost]
        public ActionResult CheckOut()
        {
            try {

                
                // Tạo một đơn đặt hàng mới
                Order _order = new Order();

              
                _order.Date = DateTime.Now;
                _order.Address = Request.Form["address"];
                _order.Phone_number = Request.Form["phone"];
                _order.Username = Request.Form["name"];

                //// Thêm đơn đặt hàng vào cơ sở dữ liệu
                _db.Orders.Add(_order);
              //  int orderId = _order.ID;
                _db.SaveChanges();
                
                //// Lặp qua từng sản phẩm trong giỏ hàng và tạo chi tiết đơn đặt hàng
                Cart cart = Session["Cart"] as Cart;
                foreach (var item in cart.Items)
                {
                    //Order_Detail _order_Detail = new Order_Detail();
                    //_order_Detail.Order_id = orderId;
                    //_order_Detail.Product_id = item._shopping_product.ID;
                    //_order_Detail.Quantity = item._shopping_quantity;

                    

                    //// Thêm chi tiết đơn đặt hàng vào cơ sở dữ liệu
                    //_db.Order_Details.Add(_order_Detail);
                }





                // Lưu các thay đổi vào cơ sở dữ liệu
                _db.SaveChanges();

                // Xóa giỏ hàng sau khi thanh toán thành công
                cart.ClearCart();

                // Chuyển hướng đến trang thành công
                return RedirectToAction("Shooping_Success", "ShoppingCart");

            }
            catch
            {
                // Xử lý các ngoại lệ và trả về kết quả nội dung với thông báo lỗi
                return Content("looixxxx....");
            }
        }
    }

}



