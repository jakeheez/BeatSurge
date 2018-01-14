using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Heaserbeats.Models
{
	public class TransactionViewModel
	{
		public BeatViewModel Beat { get; set; }
		public ProducerViewModel Producer { get; set; }
		public string Order { get; set; }
	}
}