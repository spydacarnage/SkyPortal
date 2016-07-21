using SkyInsurance.SkyPortal.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Xml;

namespace SkyInsurance.SkyPortal.Models
{
    [ComplexType]
    public class Appointment
    {
        public DateTime Date { get; set; }

        public Address InstallationAddress { get; set; }

        public static Appointment Create(XmlAppointment xml)
        {
            var appointment = new Appointment();
            appointment.Date = xml.Date;
            appointment.InstallationAddress = Address.Create(xml.InstallationAddress);

            return appointment;
        }

        public override string ToString()
        {
            return $"{Date:dd-MMM-yy} at {Date:HH:mm} - {InstallationAddress.ToString()}";
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