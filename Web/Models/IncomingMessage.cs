using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace SkyInsurance.SkyPortal.Models
{
    public class IncomingMessage : DatedEntity
    {
        public string MessageXML { get; set; }

        public string Response { get; set; }

        public IncomingMessage() { }
        public IncomingMessage(string messageXML)
        {
            MessageXML = messageXML;
        }

        // Display Properties
        [Display(Name = "Message Received")]
        public string DisplayDate => DateCreated.ToString("dd-MMM-yy HH:mm:ss");

        [Display(Name = "Message Type")]
        public string MessageType => Regex.Match(MessageXML, "<messageType>(.*)</messageType>").Groups[1].Value;

        [Display(Name = "Customer Ref")]
        public string CustomerRef => Regex.Match(MessageXML, "<customerReference>(.*)</customerReference>").Groups[1].Value;

        [Display(Name = "Policy Number")]
        public string PolicyNo => Regex.Match(MessageXML, "<policyReference>(.*)</policyReference>").Groups[1].Value;
    }
}