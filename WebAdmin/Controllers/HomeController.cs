using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAdmin.Models;

namespace WebAdmin.Controllers
{
    public class HomeController : Controller
    {
        OnlineShop db = new OnlineShop();
        // GET: Home
        public ActionResult Index()
        {
           
            HomeModel x = new HomeModel();
            x.newProducts = db.Products
                                  .Where(p => p.Tooping != 1)
                                  .OrderByDescending(p => p.NewProduct)
                                  .ThenByDescending(p => p.ID)
                                  .Take(2)
                                  .ToList();
            x.categories = db.ProductCategories.ToList();
            x.popularItems = db.Products.Take(6).ToList();
            x.toppings = db.Products.Where(i => i.Tooping == 1);
 
            ViewBag.homeModel = x;  
            return View();
            //var listProduct = db.Products.Where(x => x.ID == 11 ).ToList();
            //ViewBag.ListProduct = listProduct;

            //var listNewProduct = db.Products.Take(6).ToList();
            //ViewBag.ListNewProduct = listNewProduct;


            //var listNewProducts = db.Products
            //                      .Where(p => p.Tooping != 1)
            //                      .OrderByDescending(p => p.NewProduct )
            //                      .ThenByDescending(p => p.ID)
            //                      .Take(2)
            //                      .ToList();
            //ViewBag.ListNewProducts = listNewProducts;

            //var listTopping = db.Products.Where(x => x.Tooping == 1)
            //    .Take(4).ToList();
            //ViewBag.ListTopping = listTopping;
        }


    }
}