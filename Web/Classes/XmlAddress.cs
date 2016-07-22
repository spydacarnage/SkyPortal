using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.RegularExpressions;
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
            var camelToFirstLetterUpper = new Func<string, string>(value =>
            {
                string result = Regex.Replace(value, "\\b[a-z]", f => f.Value.ToUpper());
                result = Regex.Replace(result, "([a-z])([A-Z])", f => $"{f.Groups[1].Value} {f.Groups[2].Value.ToUpper()}");

                return result;
            });

            var address = new XmlAddress();
            var node = camelToFirstLetterUpper($"{xml.ParentNode.Name} => {xml.Name}");
            try
            {
                address.AddressLine1 = xml.SelectSingleNode("./firstAddressLine").InnerText;
            }
            catch
            {
                return $"{node} => First Address Line";
            }

            try
            {
                address.AddressLine2 = xml.SelectSingleNode("./secondAddressLine")?.InnerText;
            }
            catch
            {
                return $"{node} => Second Address Line";
            }

            try
            {
                address.AddressLine3 = xml.SelectSingleNode("./thirdAddressLine")?.InnerText;
            }
            catch
            {
                return $"{node} => Third Address Line";
            }

            try
            {
                address.AddressLine4 = xml.SelectSingleNode("./fourthAddressLine")?.InnerText;
            }
            catch
            {
                return $"{node} => Fourth Address Line";
            }

            try
            {
                address.AddressLine5 = xml.SelectSingleNode("./fifthAddressLine")?.InnerText;
            }
            catch
            {
                return $"{node} => Fifth Address Line";
            }

            try
            {
                address.Postcode = xml.SelectSingleNode("./postcode").InnerText;
            }
            catch
            {
                return $"{node} => Postcode";
            }

            try
            {
                address.Country = xml.SelectSingleNode("./country").InnerText;
            }
            catch
            {
                return $"{node} => Country";
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