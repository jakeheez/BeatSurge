using Heaserbeats.Models;
using Heaserbeats.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Stripe;
using System.IO;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

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
		public ActionResult SendTransaction(string stripeToken) 
		{
			try 
			{
				// we need to snip out the parameters from the Url
				string fullPath = HttpContext.Request.Url.AbsolutePath;
				if (fullPath.StartsWith("/"))
				{
					fullPath = fullPath.Substring(1);
				}
				string[] urlParams = fullPath.Split('/');
				string producerId = urlParams[0];
				string order = urlParams[1];
				int beatId = Int32.Parse(urlParams[2]);

				BeatViewModel beat = _beatProvider.GetBeatByBeatAndProducer(beatId, producerId);
				// Grab the correct price (in cents)
				int price;
				if (order == "Lease" || order == "lease") {
					price = beat.LeasePrice * 100;
				}
				else if (order == "buy" || order == "Buy") {
					price = beat.BuyPrice * 100;
				}
				else {
					return new HttpStatusCodeResult(500);
				}

				var description = order + " beat from Beat Surge";

				StripeConfiguration.SetApiKey(_beatProvider.GetStripeApiKey());
				var charges = new StripeChargeService();
				var charge = charges.Create(new StripeChargeCreateOptions
				{
					Amount = price,
					Currency = "usd",
					Description = description,
					SourceTokenOrExistingSourceId = stripeToken
				});

				// Update db with any successful purchase information
				// Email buyer the beat
				// Return a 'thank you for your purchase' screen here
				return new HttpStatusCodeResult(200, "You successfully ordered " + beat.Title);
			}
			catch (Exception e) {
				return new HttpStatusCodeResult(500, e.Message);
			}
		}

	}
}