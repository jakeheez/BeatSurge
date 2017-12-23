using Heaserbeats.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;

namespace Heaserbeats.DataAccess
{
	public class BeatPageDAL
	{

		public ProducerViewModel GetPageInfoByProducer(string producerId)
		{
			string connectionString = HostingEnvironment.ApplicationPhysicalPath + String.Format("/Producers/{0}/PageInfo.txt", producerId);
			ProducerViewModel model = new ProducerViewModel();
			using (StreamReader sr = new StreamReader(connectionString))
			{
				string line = sr.ReadLine();
				string[] values = line.Split(',');
				model.Title = values[0];
				model.Subtitle = values[1];
				model.PrimaryColor = values[2];
				model.SecondaryColor = values[3];
				model.TextColor = values[4];
			}
			return model;
		}

		public List<ProducerViewModel> GetAllProducerPages() 
		{
			List<ProducerViewModel> producers = new List<ProducerViewModel>();

			// get list of producer folders
			string connectionString = HostingEnvironment.ApplicationPhysicalPath + "/Producers/ProducerList.txt";
			string[] values;
			using (StreamReader sr = new StreamReader(connectionString))
			{
				string line = sr.ReadLine();
				values = line.Split(',');
			}
			// get producer info for each producer
			foreach (string x in values)
			{
				producers.Add(GetPageInfoByProducer(x));
			}
			return producers;
		}

		public BeatViewModel GetBeatByBeatAndProducer(int beatId, string producerId)
		{
			string connectionString = HostingEnvironment.ApplicationPhysicalPath + String.Format("/Producers/{0}/BeatInfo.txt", producerId);
			BeatViewModel beat = new BeatViewModel();

			using (StreamReader sr = new StreamReader(connectionString))
			{
				while (sr.Peek() >= 0) {
					string line = sr.ReadLine();
					string[] values = line.Split(',');
					if (values[0] == beatId.ToString())
					{
						beat.BeatId = Int32.Parse(values[0]);
						beat.Title = values[1];
						beat.LeasePrice = Double.Parse(values[2]);
						beat.BuyPrice = Double.Parse(values[3]);
						beat.ActiveStatus = (values[4] == "1");
					}
					break;
				}

			}
			if (beat.ActiveStatus == false) {
				return new BeatViewModel();
			}
			return beat;
		}

		public List<BeatViewModel> GetAllBeatsByProducer(string producerId)
		{
			List<BeatViewModel> beats = new List<BeatViewModel>();

			string connectionString = HostingEnvironment.ApplicationPhysicalPath + String.Format("/Producers/{0}/BeatInfo.txt", producerId);
			using (StreamReader sr = new StreamReader(connectionString)) {
				while (sr.Peek() >= 0)
				{
					BeatViewModel beat = new BeatViewModel();
					string line = sr.ReadLine();
					string[] values = line.Split(',');

					beat.BeatId = Int32.Parse(values[0]);
					beat.Title = values[1];
					beat.LeasePrice = Double.Parse(values[2]);
					beat.BuyPrice = Double.Parse(values[3]);
					beat.ActiveStatus = (values[4] == "1");

					beats.Add(beat);
				}
			}
			// flip them to descending order to display most recent beats first
			List<BeatViewModel> beatListSorted = beats.OrderByDescending(x => x.BeatId).ToList();

			return beatListSorted;
		}

		public byte[] GetBeatAudio(string producerId, int beatId) {
			string connectionString = HostingEnvironment.ApplicationPhysicalPath + String.Format("/Producers/{0}/Beats/{1}.mp3", producerId, beatId);

			var bytes = new byte[0];

			using (var fs = new FileStream(connectionString, FileMode.Open, FileAccess.Read)) {
				var br = new BinaryReader(fs);
				long numBytes = new FileInfo(connectionString).Length;
				bytes = br.ReadBytes((int)numBytes);
			}

			return bytes;
		}

		public List<NewsViewModel> GetAllNewsItems() {
			List<NewsViewModel> newsList = new List<NewsViewModel>();

			string connectionString = HostingEnvironment.ApplicationPhysicalPath + "/News/NewsItems.txt";
			using (StreamReader sr = new StreamReader(connectionString))
			{
				while (sr.Peek() >= 0)
				{
					NewsViewModel news = new NewsViewModel();
					string line = sr.ReadLine();
					string[] values = line.Split(',');

					news.NewsId = Int32.Parse(values[0]);
					news.Title = values[1];
					news.ArticleText = values[2];
					news.ActiveStatus = (values[3] == "1");

					newsList.Add(news);
				}
			}
			// flip them to descending order to display most recent news first
			List<NewsViewModel> newsListSorted = newsList.OrderByDescending(x => x.NewsId).ToList();

			return newsListSorted;
		}

		public string UploadBeat(string producerId, string title, double leasePrice, double buyPrice, HttpPostedFileBase beat) {
			// Grab the next index
			int beatIndex = GetNextBeatIndexForProducer(producerId);

			if (beat.ContentLength > 0)
			{
				// Create the path to store
				string pathToSave = HostingEnvironment.ApplicationPhysicalPath + String.Format("/Producers/{0}/Beats/", producerId);
				// Save the beat file
				var fileName = beatIndex + ".mp3";
				beat.SaveAs(pathToSave + fileName);
			}

			// Update the file we just read to store the beat info
			string connectionString = HostingEnvironment.ApplicationPhysicalPath + String.Format("/Producers/{0}/BeatInfo.txt", producerId);

			using (StreamWriter file = File.AppendText(connectionString))
			{
				file.WriteLine(beatIndex + "," + title + "," + leasePrice + "," + buyPrice + ",1");
			}

			return "The beat was successfully uploaded.";
		}

		public int GetNextBeatIndexForProducer(string producerId) {
			List<BeatViewModel> beats = GetAllBeatsByProducer(producerId);
			// Index starts at 1 in the text file.  Add 1 to count.
			return beats.Count() + 1;

		}

	}
}