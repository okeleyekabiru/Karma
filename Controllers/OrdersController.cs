using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Shopy.Models;
using ShopyEcomerce;
using ShopyEcomerce.ef;
using ShopyLibrary;
using ShopyLibrary.Interface;

namespace Shopy.Controllers
{
    public class OrdersController : Controller
    {
        public ICarts _cartsdb { get; }
        private readonly IOrders _db;

        public OrdersController(IOrders _db, ICarts carts)
        {
            _cartsdb = carts;
            this._db = _db;
        }

        // GET: Orders
        [Authorize]
        public ActionResult Index()
        {
            var model = (User) Session["Id"];

            var view = BusinessLogic.LoadOrdersAndCarts(_db.GetAllOrder(model.Id));
            return View(view);
        }

        [Authorize]
        // GET: Orders/Details/5
        public ActionResult Details(int id)
        {

            var order = _db.GetOrder(id);


            return View(order);
        }

        // GET: Orders/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create(
            [Bind(Include = "Id,ProductsName,ProductPrice,DatePurchaced,Category,Quantity,User_Id")]
            FormCollection form) 
        {
             IEnumerable<Order> order = new List<Order>();

            if (ModelState.IsValid)
            {
                var session = (List<Cart>)Session["Carts"];
                order = BusinessLogic.MapCartToTher(session);
                _db.AddOrder(order);
                _db.Commit();
                return RedirectToAction("Index");
            }

            return View(order);
        }

        // GET: Orders/Edit/5
        [Authorize]
        public ActionResult Edit(int id)
        {


            var order = _db.GetOrder(id);
            if (order == null)
            {
                return HttpNotFound();
            }

            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(
            [Bind(Include = "Id,ProductsName,ProductPrice,DatePurchaced,Category,Quantity,User_Id")]
            Order order)
        {
            if (ModelState.IsValid)
            {
                _db.UpdateOrder(order);
                return RedirectToAction("Index");
            }

            return View(order);
        }

        // GET: Orders/Delete/5
        [Authorize]
        public ActionResult Delete()
        {

            var model = (User) Session["Id"];
            var order = _db.GetAllOrder(model.Id);
            var orders = BusinessLogic.LoadOrdersAndCarts(order);
            if (order == null)
            {
                return HttpNotFound();
            }

            return View(orders);
        }

        [Authorize]
        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(FormCollection collection)
        {

            var model = (User) Session["Id"];
            var order = _db.GetAllOrder(model.Id);
            BusinessLogic.LoadOrdersAndCarts(order);
            _db.cancelOrder(order);
            _db.Commit();
            return RedirectToAction("Index");



        }

        [Authorize]
        public ActionResult CheckOut()
        {
            var session = (List<Cart>) Session["Carts"];
            if (session != null)
            {
                if (User.Identity.IsAuthenticated)
                {
                    var userId = (User) Session["Id"];

                    foreach (var VARIABLE in session)
                    {
                        VARIABLE.User_Id = userId.Id;
                        _cartsdb.AddCart(VARIABLE);
                        _cartsdb.Commit();

                    }

                    var model = BusinessLogic.LoadOrdersAndCarts(_cartsdb.GetAllCarts());
                    ViewBag.totalprice = BusinessLogic.TotalPrice(model);
                    return View(model);
                }

            }

            return RedirectToAction("NotFound", "Users");
        }
        [HttpPost]
        public ActionResult CheckOut(FormCollection form)
        {
            var session = (List<Cart>)Session["Carts"]; 
            if (session != null)
            {
                if (User.Identity.IsAuthenticated)
                {
                    var userId = (User)Session["Id"];

                    foreach (var VARIABLE in session)
                    {
                        VARIABLE.User_Id = userId.Id;
                        _cartsdb.AddCart(VARIABLE);
                        _cartsdb.Commit();

                    }

                    var model = BusinessLogic.LoadOrdersAndCarts(_cartsdb.GetAllCarts());
                    ViewBag.totalprice = BusinessLogic.TotalPrice(model);
                    ShopyEcomerce.PayStack.PayStackApi(userId.Email, (int) BusinessLogic.TotalPrice(model));
                    return View(model);
                }

            }

            return RedirectToAction("NotFound", "Users");
        }
    }
}


