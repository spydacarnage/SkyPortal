using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SkyInsurance.SkyPortal.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            string output = $"Hello there. The clock is {DateTime.UtcNow}";
            output += "<br/><br/>";
            output += "<a href=\"/TCAS/Temp\">Temp Input</a>";

            return Content(output);
        }
    }
}
