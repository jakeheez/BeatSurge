using Heaserbeats.Models;
using Heaserbeats.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Heaserbeats.Controllers
{
    public class BuyPageController : Controller
    {
		BeatPageProvider _beatProvider = new BeatPageProvider();

		// GET: BuyPage
		public ActionResult Buy(string producerId, string orderId, int beatId)
        {
			ProducerViewModel producer = _beatProvider.GetPageInfoByProducer(producerId);
			BeatViewModel beat = _beatProvider.GetBeatByBeatAndProducer(beatId, producerId);

			TransactionViewModel data = new TransactionViewModel() { Beat = beat, Producer = producer, Order = orderId };

			if ((orderId.ToLower() == "buy" || orderId.ToLower() == "lease") && beat.ActiveStatus == true)
			{
				return View(data);
			}
			else {
				throw new Exception("Invalid Url.  Please try again from our home page, BeatSurge.com.");
			}
        }

		[HttpPost]
		public string UploadBeat() {
			return "hi";
		}

	}
}