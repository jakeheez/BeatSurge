using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Heaserbeats.Models
{
	public class ProducerViewModel
	{
		public int producerId { get; set; }
		public string name { get; set; }
		public string subtitle { get; set; }
		public string primaryColor { get; set; }
		public string secondaryColor { get; set; }
		public string textColor { get; set; }

	}
}