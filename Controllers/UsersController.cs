using Shopy.Models;
using ShopyEcomerce;
using ShopyEcomerce.ef;
using ShopyLibrary.Interface;
using System.Web.Mvc;

namespace Shopy.Controllers
{
    public class UsersController : Controller
    {
        private readonly ICarts _cartsdb;

        public UsersController(ICarts cartsdb)
        {
            _cartsdb = cartsdb;
        }

        [HttpGet]
        public ActionResult Details( int id)
        {
            var model = _cartsdb.GetCart(id);
            if (model != null)
            {
                var enModel = BusinessLogic.LoadOrdersAndCarts(_cartsdb.ShowMultipleCarts(model.ProductName,model.User_Id));

                return View(enModel);
            }

            return View("NotFound");
        }
        // GET: Users
        [Authorize]
        public ActionResult Home()
        {
            var model = (User) Session["Id"];
            return View(model);
        }

        [Authorize]
        [HttpGet]
        public ActionResult Carts()
        {
            var model = BusinessLogic.LoadOrdersAndCarts(_cartsdb.GetAllCarts());
            if (model == null)
            {
                return RedirectToAction("NotFound");
            }
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
        public ActionResult Carts(string name)
        {
            return RedirectToAction("Delete", new {name = name});
        }

        [Authorize]
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var mo = _cartsdb.GetCart(id);
            if (mo == null)
            {
                return View();
            }
            _cartsdb.Delete(mo);
            if (_cartsdb.Commit())
            {
                return RedirectToAction("Index");
            }

            return View(mo);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Remove(int id,FormCollection form)
        {

           
            var getCart = _cartsdb.GetCart(id);
            if (getCart== null)
            {
                return View();
            }
            _cartsdb.DeleteMutiple(getCart.ProductName, getCart.User_Id);
            if (_cartsdb.Commit())
            {
                return RedirectToAction("Index");
            }

            return View();
        }
        [HttpGet]
        public ActionResult Remove(int id)
        {
            var model = _cartsdb.GetCart(id);
            
            return View(model);
        }

        public ActionResult Delete(int id, FormCollection form)
        {
            var mo = _cartsdb.GetCart(id);
            if (mo == null)
            {
                return RedirectToAction("NotFound");
            }
            return View(mo);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Index(Cart cart)
        {
            var id = (User) Session["Id"];
            cart.User_Id = id.Id;
            var model = _cartsdb.AddCart(cart);
            _cartsdb.Commit();
            return RedirectToAction("Carts");
        }

        [Authorize]
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult NotFound()
        {
            return View();
        }
    }
}