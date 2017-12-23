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

				switch (Password)
				{
					case "yousmen":
						ProducerId = "Yusf";
						break;
					case "summit":
						ProducerId = "Summit";
						break;
					case "heezner":
						ProducerId = "Heaser";
						break;
					default:
						ProducerId = "";
						break;
				}
			if (ProducerId == "")
				{
					return "What are you doing here UNAUTHORIZED ACCESS DETECTED SELF DESTRUCTING IN 10 SECONDS REEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE";
				}

				return _beatProvider.UploadBeat(ProducerId, Title, LeasePrice, BuyPrice, Beat);
			}
			catch (Exception e)
			{
				return "Lol dude you gave me garbage, fix your inputs.";
			}
		}
    }
}