using Heaserbeats.Models;
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
			List<ProducerViewModel> producers = _beatProvider.GetAllProducerPages();

			List<NewsViewModel> news = _beatProvider.GetAllNewsItems();

			HomePageDataViewModel data = new HomePageDataViewModel() { News = news, Producers = producers };

			return View(data);
		}
    }
}