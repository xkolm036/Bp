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
            ViewBag.Background = "background";
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
            Stranka s =new Stranka { text = System.IO.File.ReadAllText(Server.MapPath(@"~/Stranky/Kontakty.txt")) };
            return View(s);
        }

        public ActionResult Kontakty_edit()
        {
            Stranka s = new Stranka { text = System.IO.File.ReadAllText(Server.MapPath(@"~/Stranky/Kontakty.txt")) };
            return View(s);
        }

        [HttpPost]
        public ActionResult Kontakty_edit_save(Stranka s)
        {
        System.IO.File.WriteAllText(Server.MapPath(@"~/Stranky/Kontakty.txt"), s.text);
            return RedirectToAction("Kontakty", "Home");
        }

    }
}