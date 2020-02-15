using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shopy.Models;
using ShopyEcomerce.ef;
using ShopyLibrary.Interface;

namespace Shopy.Controllers
{
    public class UsersController : Controller
    {
        private readonly ICarts _cartsdb;

        public UsersController(ICarts cartsdb)
        {
            _cartsdb = cartsdb;
        }
        // GET: Users
        [Authorize]
        public ActionResult Home()
        {
            var model =(User) Session["Id"];
            
            return View(model);
        }
        [Authorize]
        [HttpGet]
        public ActionResult Carts()
        {
            var model = _cartsdb.GetAllCarts();
            return View(model);
        }
        [Authorize]
        [HttpPost]
        public ActionResult Carts(int id)
        {


            return RedirectToAction("Delete", id);
        }
        [Authorize]
        [HttpPost]
        public ActionResult Delete(int id) 
        {

            var mo = _cartsdb.GetCart(id);
           _cartsdb.Delete(mo);
            
            if (_cartsdb.Commit())
            {
                return RedirectToAction("Index");
            }
            return View(mo);
        }
        public ActionResult Delete(int id ,FormCollection form)
        {

            var mo = _cartsdb.GetCart(id);
            
            return View(mo);
        }
        [Authorize]
        [HttpPost]
        public ActionResult Index(Cart cart)
        {
            var model = _cartsdb.AddCart(cart);
            _cartsdb.Commit();
            return RedirectToAction("Carts");
        }[Authorize]
        [HttpGet]
        public ActionResult Index()
        {
          
            return View();
        }
    }
}