using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAdmin.Models;
using System.Data.Entity;
namespace WebAdmin.Controllers
{
    public class ProductController : Controller
    {
        OnlineShop db = new OnlineShop();

        [ChildActionOnly]
        public ActionResult ProductStyle1Partial()
        {
           // var listProduct = db.Products.ToList();
             //return PartialView(listProduct);
            return PartialView();
        }

        public ActionResult ProductStyle2Partial()
        {
            //var listProduct = db.Products.ToList();
            //return PartialView(listProduct);
            return PartialView();
        }
        public ActionResult ProductStyle3Partial()
        {
            //var listProduct = db.Products.ToList();
            //return PartialView(listProduct);
            return PartialView();
        }
        public ActionResult ProductStyle4Partial()
        {
            return PartialView();
        }
        //acction loadtion all sp
        public ActionResult AllPr()
        {
            var listProduct = db.Products.ToList();
            ViewBag.ListProduct = listProduct;
            return View(listProduct);
        }
       
            

            public ActionResult MenuPartial()
            {

            var listSP = db.ProductCategories;
                
                return PartialView(listSP);
            }


        public ActionResult CategoryPro(long ID )
        {
            if (ID == 0)
            {
                // Xử lý trường hợp categoryID không hợp lệ 
                return HttpNotFound();
            }
            var productsInCategory = db.Products.Where(n => n.CategoryID == ID).ToList();
            return View(productsInCategory);
        }


    }
}