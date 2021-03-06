﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Shopy.Models;
using ShopyEcomerce;
using ShopyLibrary;

namespace Shopy.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProducts _dbProducts;
        private readonly ICarts _cartsDb;
        private static int? pageindex;

        public ProductsController(IProducts dbProducts, ICarts cartsDb)
        {
            _dbProducts = dbProducts;
            _cartsDb = cartsDb;
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
                product.Photos = CloudinaryUploader.Upload(photo);
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
        public ActionResult AllProduct(string productname, string category)
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

        public ActionResult AllProduct()
        {
            var model = _dbProducts.GetAllProducts();
            if (model != null)
            {
                return View(model);
            }

            return RedirectToAction("NotFound", "Users");
        }

        public ActionResult ProductsPage(int? pageNumber, int? pageIndex)
        {
            IEnumerable<Product> model = _dbProducts.GetAllProducts();
            if (pageIndex.HasValue && pageIndex.HasValue)
            {
                pageindex = pageIndex += 1;
             var page = model.Skip(
                    pageNumber.Value *(pageIndex.Value - 1)).Take(pageNumber.Value);
                return Json(page, JsonRequestBehavior.AllowGet);
            }

            if (model != null)
            {
                return Json(model.Take(6), JsonRequestBehavior.AllowGet);
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

            var photo = Request.Files["photo"];
            _dbProducts.UpdateProduct(product);
            if (_dbProducts.Commit())
            {
                return RedirectToAction("AllProduct");
            }

            return View();
        }

        [HttpPost]
        public ActionResult Details(int id, int quantity)
        {
           
            
            if (!ModelState.IsValid)
            {
                TempData["message"] = "please please specify a valid quantity";
                return RedirectToAction("Details");
            }

            var model = _dbProducts.GetProduct(id);
            if (model == null)
            {
                return RedirectToAction("NotFound", "Users");
            }

            var cart = BusinessLogic.MapCart(model);
            cart.Quantity = quantity;
            if (User.Identity.IsAuthenticated)
            {
                var userId = (User)Session["Id"];
                cart.User_Id = userId.Id;
               
                _cartsDb.AddCart(cart);


                if (_cartsDb.Commit())
                {

                    BusinessLogic.ListingCarts.Add(cart);
                    Session["Carts"] = BusinessLogic.ListingCarts;
                    return RedirectToAction("Index", "Home");
                }



            }
            else
            {
                BusinessLogic.ListingCarts.Add(cart);
                Session["Carts"] = BusinessLogic.ListingCarts;

                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("NotFound", "Users");


        }

        public ActionResult LoadAllProduct(string sorted ="name")
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("NotFound", "Users");
            }
            var model =_dbProducts.SortedProducts(sorted);
            return Json(
                model, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Pagination(int numberview = 6, int index = 1)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("NotFound", "Users");
            }

            var  count = 0;
           count  += index;
           var model = _dbProducts.Pagination(count, numberview);
           return Json(model, JsonRequestBehavior.AllowGet);
        }

        public ActionResult LoadCategory(int category)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("NotFound", "Users");
            }
        
            var model = _dbProducts.GetProductsByCatergory(category);
            return Json(model,JsonRequestBehavior.AllowGet);
        }
    }
}