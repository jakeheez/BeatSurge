using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Heaserbeats.Models
{
	public class HomePageDataViewModel
	{
		public List<NewsViewModel> News { get; set; }
		public List<ProducerViewModel> Producers { get; set; }
	}
}