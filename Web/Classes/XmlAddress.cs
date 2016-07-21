using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Xml;

namespace SkyInsurance.SkyPortal.Classes
{
    [ComplexType]
    public class XmlAddress
    {
        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string AddressLine3 { get; set; }

        public string AddressLine4 { get; set; }

        public string AddressLine5 { get; set; }

        public string Postcode { get; set; }

        public string Country { get; set; }

        public static object Create(XmlNode xml)
        {
            var address = new XmlAddress();
            var node = $"{xml.ParentNode.Name}/{xml.Name}";
            try
            {
                address.AddressLine1 = xml.SelectSingleNode("./firstAddressLine").InnerText;
            }
            catch
            {
                return $"Invalid Entry - /{node}/firstAddressLine";
            }

            try
            {
                address.AddressLine2 = xml.SelectSingleNode("./secondAddressLine")?.InnerText;
            }
            catch
            {
                return $"Invalid Entry - /{node}/secondAddressLine";
            }

            try
            {
                address.AddressLine3 = xml.SelectSingleNode("./thirdAddressLine")?.InnerText;
            }
            catch
            {
                return $"Invalid Entry - /{node}/thirdAddressLine";
            }

            try
            {
                address.AddressLine4 = xml.SelectSingleNode("./fourthAddressLine")?.InnerText;
            }
            catch
            {
                return $"Invalid Entry - /{node}/fourthAddressLine";
            }

            try
            {
                address.AddressLine5 = xml.SelectSingleNode("./fifthAddressLine")?.InnerText;
            }
            catch
            {
                return $"Invalid Entry - /{node}/fifthAddressLine";
            }

            try
            {
                address.Postcode = xml.SelectSingleNode("./postcode").InnerText;
            }
            catch
            {
                return $"Invalid Entry - /{node}/postcode";
            }

            try
            {
                address.Country = xml.SelectSingleNode("./country").InnerText;
            }
            catch
            {
                return $"Invalid Entry - /{node}/postcode";
            }

            return address;
        }

        public string ToXML()
        {
            string output = "";
            output += $"<firstAddressLine>{AddressLine1}</firstAddressLine>";
            output += $"<secondAddressLine>{AddressLine2}</secondAddressLine>";
            output += $"<thirdAddressLine>{AddressLine3}</thirdAddressLine>";
            output += $"<fourthAddressLine>{AddressLine4}</fourthAddressLine>";
            output += $"<fifthAddressLine>{AddressLine5}</fifthAddressLine>";
            output += $"<postcode>{Postcode}</postcode>";
            output += $"<country>{Country}</country>";

            return output;
        }

    }
}