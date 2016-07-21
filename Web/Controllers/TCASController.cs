using SkyInsurance.SkyPortal.Classes;
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
        //ICustomerService sCustomer;
        //IApplicationUserService sAppUser;
        //IAdditionalInfoService sUser;
        //IServiceCR<IncomingMessage> sIncoming;
        //IServiceCRU<OutgoingMessage> sOutgoing;
        //IAllowedIPService sAllowedIPs;
        //IRevaleeService sRevalee;

        //public TCASController() : this(
        //    new CustomerService(), 
        //    new ApplicationUserService(), 
        //    new AdditionalInfoService(), 
        //    new IncomingMessageService(), 
        //    new OutgoingMessageService(),
        //    new AllowedIPService(),
        //    new RevaleeService()) { }

        //public TCASController(
        //    ICustomerService customerService, 
        //    IApplicationUserService appUserService, 
        //    IAdditionalInfoService userService, 
        //    IServiceCR<IncomingMessage> incomingMessageService, 
        //    IServiceCRU<OutgoingMessage> outgoingMessageService,
        //    IAllowedIPService allowedIPService,
        //    IRevaleeService revaleeService) : base()
        //{
        //    sCustomer = customerService;
        //    sAppUser = appUserService;
        //    sUser = userService;
        //    sIncoming = incomingMessageService;
        //    sOutgoing = outgoingMessageService;
        //    sAllowedIPs = allowedIPService;
        //    sRevalee = revaleeService;
        //}

        [HttpPost]
        public ActionResult Policy()
        {
            //if (!sAllowedIPs.CheckIP(GetClientIP()))
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            //}

            var messageResult = XmlMessage.Create(Request.InputStream);

            //if (messageResult.Message != null)
            //{
            //    HostingEnvironment.QueueBackgroundWorkItem(cancellationToken =>
            //    {
            //        ProcessMessage(messageResult.Message);
            //    });
            //}

            return Content($"<response>{messageResult.IncomingMessage.Response}</response>");
        }

        public ActionResult Temp()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Temp(string message)
        {
            var server = Request.Url.AbsoluteUri.Replace(Request.Url.AbsolutePath, "");
            var response = HttpSender.SendXML($"{server}/TCAS/Policy", message);
            if (response.Exception == null)
            {
                return Content(response.Message);
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