using Heaserbeats.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;

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
				return beats;
		}


	}
}