using Heaserbeats.DataAccess;
using Heaserbeats.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Heaserbeats.Providers
{
	public class BeatPageProvider
	{
		BeatPageDAL _beatDAL = new BeatPageDAL();

		public ProducerViewModel GetProducerById(int producerId) {
			return _beatDAL.GetProducerById(producerId);
		}

		public List<ProducerViewModel> GetAllProducers() {
			return _beatDAL.GetAllProducers();
		}

		public BeatViewModel GetBeatByBeatId(int beatId) {
			return _beatDAL.GetBeatByBeatId(beatId);
		}

		public List<BeatViewModel> GetAllBeatsByProducerId(int producerId) {
			return _beatDAL.GetAllBeatsByProducerId(producerId);
		}

		public ProducerViewModel GenerateProducerSettings(int producerId)
		{
			ProducerViewModel producer = new ProducerViewModel();

			switch (producerId)
			{
				case 1:
					producer = new ProducerViewModel()
					{
						producerId = producerId,
						name = "Heaser",
						subtitle = "Not Your Grandma's Beats",
						primaryColor = "#493a61",
						secondaryColor = "#d8d8d8",
						textColor = "black"
					};
					break;
				case 2:
					producer = new ProducerViewModel()
					{
						producerId = producerId,
						name = "Ashland Summit",
						subtitle = "Your Girl's Favorite Website",
						primaryColor = "#996666",
						secondaryColor = "#cec9ac",
						textColor = "black"
					};
					break;
				case 3:
					producer = new ProducerViewModel()
					{
						producerId = producerId,
						name = "Yousef",
						subtitle = "Yousef Type Beats Archive",
						primaryColor = "#3b5377",
						secondaryColor = "#acc7af",
						textColor = "black"
					};
					break;
			}
			return producer;
		}

		public List<BeatViewModel> GenerateTestBeats(int producerId)
		{
			List<BeatViewModel> beats = new List<BeatViewModel>();
			string name = "";

			switch (producerId)
			{
				case 1:
					name = "Heaser";
					break;
				case 2:
					name = "Ashland Summit";
					break;
				case 3:
					name = "Yousef";
					break;
			}

			int id = 0;
			Random rnd = new Random();

			for (var i = 0; i < 3; i++)
			{
				beats.Add(item: new BeatViewModel() { beatId = id++, title = "Ultimate Fire", artist = name, price = 124.99, picName = "beat.png" });
				beats.Add(item: new BeatViewModel() { beatId = id++, title = "Insane beat 47", artist = name, price = 124.99, picName = "beat.png" });
				beats.Add(item: new BeatViewModel() { beatId = id++, title = "Literally Award Winning", artist = name, price = 99.99, picName = "beat.png" });
				beats.Add(item: new BeatViewModel() { beatId = id++, title = "Best beat of the 21st Century", artist = name, price = 24.99, picName = "beat.png" });
				beats.Add(item: new BeatViewModel() { beatId = id++, title = "Mindblowing Beat", artist = name, price = 9.99, picName = "beat.png" });
				beats.Add(item: new BeatViewModel() { beatId = id++, title = "Destructively Good Beat", artist = name, price = 149.99, picName = "beat.png" });
			}
			return beats;
		}


	}
}