using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using data.Model;
using data;
using System.Net.NetworkInformation;

namespace bp.Controllers
{
    public class HomeController : Controller
    {

        // GET: Home
        public ActionResult Index()
        {
            ViewBag.background = "background"; //nastavení obrazku na stance aktuality
       
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


    }
}