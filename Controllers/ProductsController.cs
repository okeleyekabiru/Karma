using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopyEcomerce.ef;
using ShopyLibrary.Interface;

namespace Shopy.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProducts _dbProducts;

        public ProductsController(IProducts dbProducts)
        {
            _dbProducts = dbProducts;
        }

        // GET: Products
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Product product)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    //   ViewBag
                    return View();
                }

                var photo = Request.Files["photo"];

                Byte[] Content = new BinaryReader(photo.InputStream).ReadBytes(photo.ContentLength);

                product.Photos = Content;
                _dbProducts.AddProduct(product);
                if (_dbProducts.Commit())
                {
                    return View();
                }
            }
            catch (Exception ex)
            {
                var message = ex.Message;
                ViewBag.ErrorMessage = message;
                return View();
            }

            return View();
        }
        [HttpPost]
        public ActionResult AllProduct( string productname, string category)
        {
            var model = _dbProducts.GetProductsByName(productname,int.Parse(category));
            if (model != null)
            {
                return View(model);
            }

            return RedirectToAction("NotFound", "Users");
        }
        public ActionResult AllProduct()
        {
            var model = _dbProducts.GetAllProducts();
            if (model != null)
            {
                return View(model);
            }

            return RedirectToAction("NotFound", "Users");
        }

        public ActionResult Details(int id)
        {
            if (ModelState.IsValid)
            {
                var model = _dbProducts.GetProduct(id);
                return View(model);
            }

            return RedirectToAction("NotFound", "Users");
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection form)
        {
            var getProduct = _dbProducts.GetProduct(id);
            _dbProducts.DeleteProduct(getProduct);

            if (_dbProducts.Commit())
            {
                return RedirectToAction("AllProduct");
            }

            return RedirectToAction("NotFound", "Users");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var getProduct = _dbProducts.GetProduct(id);
            if (getProduct == null)
            {
                return RedirectToAction("NotFound", "Users");
            }

            return View(getProduct);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = _dbProducts.GetProduct(id);
            if (model != null)
            {
                return View(model);
            }

            return RedirectToAction("NotFound", "Users");
        }
        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("NotFound", "Users");
            }
         var photo =   Request.Files["photo"];
         Byte[] Content = new BinaryReader(photo.InputStream).ReadBytes(photo.ContentLength);
         product.Photos = Content;
        _dbProducts.UpdateProduct(product);
        if (_dbProducts.Commit())
         {
             return RedirectToAction("AllProduct");
         }


         return View();

        }
    }
}