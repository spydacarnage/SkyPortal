using SkyInsurance.SkyPortal.Classes;
using SkyInsurance.SkyPortal.Enums;
using SkyInsurance.SkyPortal.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Xml;

namespace SkyInsurance.SkyPortal.Controllers
{
    public class TCASController : Controller
    {

        [HttpPost]
        public ActionResult Policy()
        {
            XmlMessage.Result messageResult = null;
            try
            {
            	messageResult = XmlMessage.Create(Request.InputStream);
            }
            catch (Exception ex)
            {
                return Content($"<response><code>{(int)IncomingResponseCode.GeneralFailure}</code><message>{ex.ToString()}</message></response>");
            }

            return Content(messageResult.IncomingMessage.ToXML());
        }

        public ActionResult Temp()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Temp(string message)
        {
            var response = HttpSender.SendXML($"http://skyportal.apphb.com/TCAS/Policy", message);
            if (response.Exception == null)
            {
                return Content($"<code>{response.Message.Replace("<", "&lt;").Replace(">", "&gt;")}</code>");
            }
            else
            {
                var webEx = response.Exception as WebException;
                if (webEx != null)
                {
                    return new HttpStatusCodeResult(((HttpWebResponse)webEx.Response).StatusCode);
                }
                else
                {
                    return Content(response.Exception.ToString());
                }
            }
            
        }

        // Get Client IP skipping Proxy
        private string GetClientIP()
        {
            // Look for a proxy address first
            string ip = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            // If there is no proxy, get the standard remote address
            if (ip == null || ip.ToLower() == "unknown")
            {
                ip = Request.ServerVariables["REMOTE_ADDR"];
            }

            return ip;
        }

    }

}