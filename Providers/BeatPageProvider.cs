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

		public List<BeatViewModel> GetAllBeatsByProducer(string producerId) {
			return _beatDAL.GetAllBeatsByProducer(producerId);
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