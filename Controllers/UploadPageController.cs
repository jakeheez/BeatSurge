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
    public class UploadPageController : Controller
    {
		BeatPageProvider _beatProvider = new BeatPageProvider();

		// GET: UploadPage
		public ActionResult Upload()
        {
            return View();
        }

		[HttpPost]
		public string UploadBeat(string Title, string LeasePrice, string BuyPrice, HttpPostedFileBase Beat, string Password) {
			try
			{
				string ProducerId = "";
				ProducerId = _beatProvider.GetProducerByPassword(Password);

				if (ProducerId == "")
				{
					return "What are you doing here UNAUTHORIZED ACCESS DETECTED SELF DESTRUCTING IN 10 SECONDS REEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE";
				}

				return _beatProvider.UploadBeat(ProducerId, Title, LeasePrice, BuyPrice, Beat);
			}
			catch
			{
				return "Lol dude you gave me garbage, fix your inputs.";
			}
		}

		[HttpPost]
		public string UploadNews(string Title, string ArticleText, HttpPostedFileBase NewsPic, string Password)
		{
			try
			{
				string ProducerId = "";
				ProducerId = _beatProvider.GetProducerByPassword(Password);

				if (ProducerId == "")
				{
					return "What are you doing here UNAUTHORIZED ACCESS DETECTED SELF DESTRUCTING IN 10 SECONDS REEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE";
				}

				return _beatProvider.UploadNews(Title, ArticleText, NewsPic);
			}
			catch
			{
				return "Lol dude you gave me garbage, fix your inputs.";
			}
		}

	}
}