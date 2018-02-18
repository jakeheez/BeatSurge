using Heaserbeats.Models;
using Heaserbeats.Providers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Heaserbeats.Controllers
{
    public class BeatPageController : Controller
    {
		BeatPageProvider _beatProvider = new BeatPageProvider();	

		public ActionResult Index(string producerId) {
			try 
			{
				ProducerViewModel producer = _beatProvider.GetPageInfoByProducer(producerId);
				List<BeatViewModel> beats = _beatProvider.GetAllActiveBeatsByProducer(producerId);

				ViewDataViewModel data = new ViewDataViewModel() { Beats = beats, Producer = producer };

				return View(data);
			}
			catch (Exception) 
			{
				return new HttpStatusCodeResult(400, "Invalid Url.  Please try again from our home page, BeatSurge.com.");
			}
		}

		[HttpGet]
		public ActionResult GetBeatAudio(string producerId, int beatId) {
			try 
			{
				var bytes = _beatProvider.GetBeatAudio(producerId, beatId);
				var result = File(bytes, "audio/mpeg", String.Format("{0}.mp3", beatId));
				return result;
			}
			catch (Exception e)
			{
				return new HttpStatusCodeResult(500, e.Message);
			}
		}

    }
}