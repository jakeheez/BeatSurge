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

		public List<NewsViewModel> GetAllActiveNewsItems() {
			List<NewsViewModel> news = _beatDAL.GetAllNewsItems();
			// filter out news where active status = 0
			List<NewsViewModel> activeNews = news.Where(x => x.ActiveStatus == true).ToList();

			return activeNews;
		}

		public string UploadBeat(string producerId, string title, string leasePrice, string buyPrice, HttpPostedFileBase beat) 
		{
			int leasePriceInt;
			int buyPriceInt;

			try {
				leasePriceInt = Int32.Parse(leasePrice);
				buyPriceInt = Int32.Parse(buyPrice);
			}
			catch (Exception) {
				return "Please only use whole numbers for prices (ex: $50 instead of $49.99).";
			}

			if (!!title.Contains(',')) {
				return "Please do not use commas in the title.";
			}
			return _beatDAL.UploadBeat(producerId, title, leasePriceInt, buyPriceInt, beat);
		}

		public string UploadNews(string title, string articleText, HttpPostedFileBase newsPic) {
			if (!!title.Contains(',') || articleText.Contains(',')) {
				return "Please do not use commas in the title or article text.";
			}
			return _beatDAL.UploadNews(title, articleText, newsPic);
		}

		public string GetProducerByPassword(string password) {
			return _beatDAL.GetProducerByPassword(password);
		}

		public string GetStripeApiKey() {
			return _beatDAL.GetStripeApiKey();
		}

		public void SendBeatToEmail(string email, int beatId, string producerId) {
			// send beat to email
			return;
		}

		public void EnterNewPurchaseRecord(string fullName, string email, string order, int beatId, string producerId, int price) {
			_beatDAL.EnterNewPurchaseRecord(fullName, email, order, beatId, producerId, price);
			return;
		}

		public void InactivateBeat(int beatId, string producerId) {
			_beatDAL.InactivateBeat(beatId, producerId);
			return;
		}

	}
}