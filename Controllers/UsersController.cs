using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shopy.Models;

namespace Shopy.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        [Authorize]
        public ActionResult Home()
        {
            var model =(User) Session["Id"];
            
            return View(model);
        }
    }
}