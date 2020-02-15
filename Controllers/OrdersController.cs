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
using ShopyLibrary.Interface;

namespace Shopy.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IOrders _db;

        public OrdersController(IOrders _db)
        {
            this._db = _db;
        }

        // GET: Orders
        [Authorize]
        public ActionResult Index()
        {
            var model = (User)Session["Id"];
           var m =  _db.GetAllOrder(model.Id);
            return View(m);
        }
        [Authorize]
        // GET: Orders/Details/5
        public ActionResult Details(int id)
        {
           
         var order =  _db.GetOrder(id);
            
           
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
        public ActionResult Create([Bind(Include = "Id,ProductsName,ProductPrice,DatePurchaced,Category,Quantity,User_Id")] Order order)
        {
            if (ModelState.IsValid)
            {
                var model = (User)Session["Id"];
                order.User_Id = model.Id;
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
        public ActionResult Edit([Bind(Include = "Id,ProductsName,ProductPrice,DatePurchaced,Category,Quantity,User_Id")] Order order)
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

            var model = (User)Session["Id"];
            var order = _db.GetAllOrder(model.Id);
           var  orders = BusinessLogic.LoadOrdersAndCarts(order);
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
           
                var model = (User)Session["Id"];
                var order = _db.GetAllOrder(model.Id);
                BusinessLogic.LoadOrdersAndCarts(order);
                _db.cancelOrder(order);
                _db.Commit();
                return RedirectToAction("Index");
          

            return View();
        }

      
    }
}
