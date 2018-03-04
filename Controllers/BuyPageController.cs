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
				return new HttpStatusCodeResult(400, "Invalid Url.  Please try again from our home page, BeatSurge.com.");
			}
        }

		[HttpPost]
		public ActionResult SendTransaction(string stripeToken, string fullName, string email) 
		{
			try 
			{
				fullName = fullName.Replace(",", "");
				email = email.Replace(",", "");

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

				var description = order + " " + beat.Title + " by " + producerId + ", customer: " + fullName + ", email: " + email;

				StripeConfiguration.SetApiKey(_beatProvider.GetStripeApiKey());
				var charges = new StripeChargeService();
				var charge = charges.Create(new StripeChargeCreateOptions
				{
					Amount = price,
					Currency = "usd",
					Description = description,
					SourceTokenOrExistingSourceId = stripeToken
				});

				if (charge.Status == "succeeded") {
					// Format price to dollars again for storage purposes
					price = price / 100;

					_beatProvider.EnterNewPurchaseRecord(fullName, email, order, beatId, producerId, price);
					_beatProvider.SendBeatToEmail(email, beatId, producerId);

					if (order == "buy" || order == "Buy") {
						_beatProvider.InactivateBeat(beatId, producerId);
					}
					return View("PurchaseSucceeded");
				}
				else {
					return View("PurchaseFailed");
				}
			}
			catch (Exception e) {
				return new HttpStatusCodeResult(500, e.Message);
			}
		}

	}
}