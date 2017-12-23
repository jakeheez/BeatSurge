using Heaserbeats.DataAccess;
using Heaserbeats.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace Heaserbeats.Providers
{
	public class BeatPageProvider
	{
		BeatPageDAL _beatDAL = new BeatPageDAL();

		public ProducerViewModel GetPageInfoByProducer(string producerId) {
			return _beatDAL.GetPageInfoByProducer(producerId);
		}

		public List<ProducerViewModel> GetAllProducerPages() {
			return _beatDAL.GetAllProducerPages();
		}

		public BeatViewModel GetBeatByBeatAndProducer(int beatId, string producer) {
			return _beatDAL.GetBeatByBeatAndProducer(beatId, producer);
		}

		public List<BeatViewModel> GetAllActiveBeatsByProducer(string producerId) {

			List<BeatViewModel> beats = _beatDAL.GetAllBeatsByProducer(producerId);
			// filter out beats where active status = 0
			List<BeatViewModel> activeBeats = beats.Where(x => x.ActiveStatus == true).ToList();

			return activeBeats;
		}

		public byte[] GetBeatAudio(string producerId, int beatId) {
			return _beatDAL.GetBeatAudio(producerId, beatId);
		}

		public List<NewsViewModel> GetAllNewsItems() {
			return _beatDAL.GetAllNewsItems();
		}

		public string UploadBeat(string producerId, string title, string leasePrice, string buyPrice, HttpPostedFileBase beat) {

			double leasePriceDouble = double.Parse(leasePrice);
			double buyPriceDouble = double.Parse(buyPrice);

			if (!!title.Contains(',')) {
				return "Please do not use commas in the title.";
			}

			return _beatDAL.UploadBeat(producerId, title, leasePriceDouble, buyPriceDouble, beat);

		}

	}
}