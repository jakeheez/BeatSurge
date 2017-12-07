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

	}
}