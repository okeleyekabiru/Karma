using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopyEcomerce;
using ShopyLibrary.Interface;

namespace Shopy.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProducts _dbProducts;
        private readonly ICarts _cartsDb;

        public HomeController(IProducts dbProducts, ICarts cartsDb)
        {
            _dbProducts = dbProducts;
            _cartsDb = cartsDb;
        }
        public ActionResult Index()
        {
            var model = _dbProducts.GetAllProducts();
            var newmodel = BusinessLogic.GetRandomCart(model);
            if (model != null)
            {
               
                return View(newmodel);
            }

            return RedirectToAction("NotFound", "Users");
        } 


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(string productname, string category)
        {

            if (category != "")
            {
                var model = _dbProducts.GetProductsByName(productname, int.Parse(category) + 1);
                if (model != null)
                {
                    return View(model);
                }
            }
            else
            {
                var model = _dbProducts.GetProductsByName(productname);
                return View(model);
            }

            return RedirectToAction("NotFound", "Users");
           
        }

        public ActionResult About(int id)
        {
           
                if (ModelState.IsValid)
                {
                    var model = _dbProducts.GetProduct(id);
                    return View(model);
                }

                return RedirectToAction("NotFound", "Users");
            
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}