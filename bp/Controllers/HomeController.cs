using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using data.Model;
using data;

namespace bp.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View(Clanek.VseZDB());
        }

        public ActionResult Info()
        {
            return View();
        }


        public ActionResult Form(string FirstName)
        {
            ViewBag.jmeno = FirstName;
            return View();
        }

        public ActionResult Kontakty()
        {
            return View();
        }



    }
}