using Heaserbeats.Models;
using Heaserbeats.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Heaserbeats.Controllers
{
    public class BeatPageController : Controller
    {
		BeatPageProvider _beatProvider = new BeatPageProvider();	

		public ActionResult Index(string producerId = "Heaser") {

			BeatViewModel beat = _beatProvider.GetBeatByBeatAndProducer(1, producerId);
			ProducerViewModel producer = _beatProvider.GetPageInfoByProducer(producerId);

			List<BeatViewModel> beats = _beatProvider.GetAllBeatsByProducer(producerId);
			List<ProducerViewModel> producers = _beatProvider.GetAllProducerPages();

			ViewDataViewModel data = new ViewDataViewModel() { Beats = beats, Producer = producer };

			return View(data);
		}
		
    }
}