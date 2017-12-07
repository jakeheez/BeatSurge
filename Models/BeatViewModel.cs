using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Heaserbeats.Models
{
	public class BeatViewModel
	{
		public int beatId{ get; set; }
		public string title { get; set; }
		public string artist { get; set; }
		public double price { get; set; }
		public string picName { get; set; }
		public int producerId { get; set; }
	}
}