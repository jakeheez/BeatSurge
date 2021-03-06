﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Heaserbeats
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			routes.MapRoute(
				name: "Buy or Lease",
				url: "{producerId}/{orderId}/{beatId}/{action}",
				defaults: new { controller = "BuyPage", action = "Buy" }
			);

			routes.MapRoute(
				name: "Upload",
				url: "UploadFireBeats/{action}",
				defaults: new { controller = "UploadPage", action = "Upload" }
			);

			routes.MapRoute(
                name: "Index",
                url: "{producerId}/{action}",
				defaults: new { controller = "BeatPage", action = "Index" }
			);

			routes.MapRoute(
				name: "Home",
				url: "{action}",
				defaults: new { controller = "HomePage", action = "Home" }
			);

		}
	}
}
