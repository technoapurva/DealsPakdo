using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShareWeb.UI.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult GetAds()
        {
            return PartialView("Ads");
        }
        public PartialViewResult GetFlightForm()
        {
            return PartialView("FlightForm");
        }
        public PartialViewResult GetTrekkingForm()
        {
            return PartialView("TrekkingForm");
        }
        public PartialViewResult GetComingSoon()
        {
            return PartialView("ComingSoon");
        }
        public PartialViewResult GetNavbar()
        {
            return PartialView("Navbar");
        }

    }
}
