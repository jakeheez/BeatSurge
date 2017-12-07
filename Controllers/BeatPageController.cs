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

		public ActionResult Index(int producerId = 1) {

			//List<BeatViewModel> testBeats = _beatProvider.GenerateTestBeats(producerId);
			//ProducerViewModel testProducer = _beatProvider.GenerateProducerSettings(producerId);
			//ViewDataViewModel data = new ViewDataViewModel() { Beats = testBeats, Producer = testProducer};

			ProducerViewModel producer = _beatProvider.GetProducerById(producerId);
			List<BeatViewModel> beats = _beatProvider.GetAllBeatsByProducerId(producerId);

			ViewDataViewModel data = new ViewDataViewModel() { Beats = beats, Producer = producer };

			return View(data);
		}
		
    }
}