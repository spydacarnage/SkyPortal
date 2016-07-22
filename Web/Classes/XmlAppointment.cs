using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Xml;

namespace SkyInsurance.SkyPortal.Classes
{
    [ComplexType]
    public class XmlAppointment
    {
        public DateTime Date { get; set; }

        public XmlAddress InstallationAddress { get; set; }

        public static object Create(XmlNode xml)
        {
            if (xml == null)
            {
                return null;
            }

            var appointment = new XmlAppointment();
            try
            {
                appointment.Date = DateTime.Parse(xml.SelectSingleNode("./date").InnerText);
            }
            catch
            {
                return "Appointment Request => Date";

            }

            var addressResult = XmlAddress.Create(xml.SelectSingleNode("./deviceInstallationAddress"));
            if (addressResult is string)
            {
                return addressResult.ToString();
            }
            appointment.InstallationAddress = addressResult as XmlAddress;

            return appointment;
        }

        public string ToXML()
        {
            string output = "";
            output += $"<date>{Date.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ")}</date>";
            output += $"<deviceInstallationAddress>{InstallationAddress.ToXML()}</deviceInstallationAddress>";

            return output;
        }

    }
}