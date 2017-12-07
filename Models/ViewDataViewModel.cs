using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Heaserbeats.Models
{
	public class ViewDataViewModel
	{
		public List<BeatViewModel> Beats { get; set; }
		public ProducerViewModel Producer { get; set; }
	}
}