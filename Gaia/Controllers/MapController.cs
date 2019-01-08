using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PusherServer;
using System.Web.Mvc;

namespace Gaia.Controllers
{
    public class MapController : Controller
    {
        private Pusher pusher;

        public MapController() 
        {

			var options = new PusherOptions();
			options.Cluster = "ap2";

            pusher = new Pusher(
                "670586",
                "27e5a77520e224c79adc",
                "ab819829e553524f6871",
                options);
        }

        [HttpPost]
        public JsonResult Index()
        {
            var latitude    = Request.Form["lat"];
            var longitude = Request.Form["lng"];

            var location = new
            {
                latitude = latitude,
                longitude = longitude
            };

            pusher.TriggerAsync("location_channel", "new_location", location);

            return Json( new { status = "success", data = location } );
        }
    }
}
