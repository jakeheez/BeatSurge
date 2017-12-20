using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Heaserbeats.Models
{
	public class NewsViewModel
	{
		public int NewsId { get; set; }
		public string Title { get; set; }
		public string ArticleText { get; set; }
		public bool ActiveStatus { get; set; }
	}
}