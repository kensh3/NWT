using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eDrvenija.eDrvenija.Helpers;

namespace eDrvenija.eDrvenija.Controllers
{
    public class HomeController : BaseController
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Admin()
        {
            return View();
        }

        public ActionResult KomentTemp()
        {
            return View();
        }

        public ActionResult PaginationTemp()
        {
            return View();
        }

        public ActionResult Pocetna()
        {
            return View();
        }

        public ActionResult PregledOglasa()
        {
            return View();
        }

        public ActionResult UrediProfil()
        {
            return View();
        }

        public ActionResult SlanjePorukeTemp()
        {
            return View();
        }

        public ActionResult PregledPoruka()
        {
            return View();
        }

        public ActionResult RezultatPretrage()
        {
            return View();
        }

        public ActionResult UrediOglas()
        {
            return View();
        }

        public ActionResult DodajOglas()
        {
            return View();
        }

        public ActionResult SetCulture(string culture)
        {
            // Validate input
            culture = CultureHelper.GetImplementedCulture(culture);
            // Save culture in a cookie
            HttpCookie cookie = Request.Cookies["_culture"];
            if (cookie != null)
                cookie.Value = culture;   // update cookie value
            else
            {
                cookie = new HttpCookie("_culture");
                cookie.Value = culture;
                cookie.Expires = DateTime.Now.AddYears(1);
            }
            Response.Cookies.Add(cookie);
            return RedirectToAction("Index", "Home");
        }

    }
}