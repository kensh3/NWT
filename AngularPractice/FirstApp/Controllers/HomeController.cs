using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstApp.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Cars()
        {
            return View();
        }

        public ActionResult Users()
        {
            return View();
        }

        public ActionResult CreateCar()
        {
            return View();
        }

        public ActionResult CreateUser()
        {
            return View();
        }

    }
}
