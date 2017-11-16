using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using data.Model;

namespace bp.Controllers
{
    public class ClankyController : Controller
    {
        // GET: Clanky
        public ActionResult Pridat()
        {
            return View();

        }
        [HttpPost]
        public ActionResult pridej(Clanek cl)
        {
            if (ModelState.IsValid)
            {
                Clanek.pridejDoDB(cl);
                TempData["msg-succes"] = "Clanek byl uspěšně přidán";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["msg-error"] = "Vyplňte všechna data";
                return View("pridat", cl);
            }
        }

        public ActionResult Seznam()
        {
            return View(Clanek.VseZDB());
        }

        public ActionResult Smazat(int id)
        {
            Clanek.odeberZDB(id);
            TempData["msg-succes"] = "Článek byl úspěšně smazán";
            return RedirectToAction("seznam", "Clanky");
        }

        public ActionResult Upravit(int id)
        {
            Clanek cl = new Clanek();
            cl = Clanek.vyberZDb(id);
            return View(cl);

        }


        public ActionResult Edit(Clanek cl,int id)
        {
            cl.id = id;
            Clanek.update(cl);
            TempData["msg-succes"] = "Článek byl úspěšně upraven";
            return RedirectToAction("seznam", "Clanky");
        }

        public ActionResult Detail(int id)
        {
            /* var dotaz = from c in database.vratClanky()
                         where c.id == id
                         select c;

             Clanek cl = null;
             foreach (Clanek c in dotaz)
                 cl = c;*/

            Clanek.vyberZDb(id);


            return View(Clanek.vyberZDb(id));
        }
    }
}