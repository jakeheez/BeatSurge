using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Heaserbeats.Models
{
	public class BeatViewModel
	{
		public int BeatId{ get; set; }
		public string Title { get; set; }
		public int LeasePrice { get; set; }
		public int BuyPrice { get; set; }
		public bool ActiveStatus { get; set; }
	}
}