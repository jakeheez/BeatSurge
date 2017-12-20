using Heaserbeats.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Heaserbeats.Controllers
{
    public class HomePageController : Controller
    {
		BeatPageProvider _beatProvider = new BeatPageProvider();

		// GET: HomePage
		public ActionResult Home()
        {
			var producers = _beatProvider.GetAllProducerPages();

            return View(producers);
        }
    }
}