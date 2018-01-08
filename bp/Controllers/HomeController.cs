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
        /// <summary>
        /// Vraci mac adresu zařízení
        /// </summary>
        public static PhysicalAddress GetMacAddress()
        {
            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                // Only consider Ethernet network interfaces
                if (nic.NetworkInterfaceType == NetworkInterfaceType.Ethernet &&
                    nic.OperationalStatus == OperationalStatus.Up)
                {
                    return nic.GetPhysicalAddress();
                }
            }
            return null;
        }




        // GET: Home
        public ActionResult Index()
        {
            if ((ViewBag.mac=GetMacAddress().ToString().Trim())== "001CC0B17D95")
            {
                return RedirectToAction("Login","Home");
            }
            
       
            return View(Clanek.VseZDB());
        }

        public ActionResult Info()
        {
            return View();
        }

        public ActionResult Login()
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