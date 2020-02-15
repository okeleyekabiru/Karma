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

        public ActionResult AllProduct()
        {
            var model = _dbProducts.GetAllProducts();
            if (model != null)
            {
                return View(model);
            }

            return RedirectToAction("NotFound", "Users");
        }
        }
    }
