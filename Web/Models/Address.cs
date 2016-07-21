using SkyInsurance.SkyPortal.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Xml;

namespace SkyInsurance.SkyPortal.Models
{
    [ComplexType]
    public class Address
    {
        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string AddressLine3 { get; set; }

        public string AddressLine4 { get; set; }

        public string AddressLine5 { get; set; }

        public string Postcode { get; set; }

        public string Country { get; set; }

        public static Address Create(XmlAddress xml)
        {
            var address = new Address();
            address.AddressLine1 = xml.AddressLine1;
            address.AddressLine2 = xml.AddressLine2;
            address.AddressLine3 = xml.AddressLine3;
            address.AddressLine4 = xml.AddressLine4;
            address.AddressLine5 = xml.AddressLine5;
            address.Postcode = xml.Postcode;
            address.Country = xml.Country;

            return address;
        }

        public ChangeCollection DetectChanges(XmlAddress newAddress, string prefix, ChangeCollection changes = null)
        {
            if (changes == null)
            {
                changes = new ChangeCollection();
            }

            if (AddressLine1 != newAddress.AddressLine1)
            {
                changes.Add(prefix + "\\firstAddressLine");
                AddressLine1 = newAddress.AddressLine1;
            }
            if (AddressLine2 != newAddress.AddressLine2)
            {
                changes.Add(prefix + "\\secondAddressLine");
                AddressLine2 = newAddress.AddressLine2;
            }
            if (AddressLine3 != newAddress.AddressLine3)
            {
                changes.Add(prefix + "\\thirdAddressLine");
                AddressLine3 = newAddress.AddressLine3;
            }
            if (AddressLine4 != newAddress.AddressLine4)
            {
                changes.Add(prefix + "\\fourthAddressLine");
                AddressLine4 = newAddress.AddressLine4;
            }
            if (AddressLine5 != newAddress.AddressLine5)
            {
                changes.Add(prefix + "\\fifthAddressLine");
                AddressLine5 = newAddress.AddressLine5;
            }
            if (Postcode != newAddress.Postcode)
            {
                changes.Add(prefix + "\\Postcode");
                Postcode = newAddress.Postcode;
            }
            if (Country != newAddress.Country)
            {
                changes.Add(prefix + "\\Country");
                Country = newAddress.Country;
            }

            return changes;
        }

        public override string ToString()
        {
            string output = "";
            if (AddressLine1 != null) output += $"{AddressLine1}, ";
            if (AddressLine2 != null) output += $"{AddressLine2}, ";
            if (AddressLine3 != null) output += $"{AddressLine3}, ";
            if (AddressLine4 != null) output += $"{AddressLine4}, ";
            if (AddressLine5 != null) output += $"{AddressLine5}, ";
            if (Postcode != null) output += $"{Postcode}, ";
            if (Country != null) output += $"{Country}, ";

            output = Regex.Replace(output, "(, )$", "");

            return output;
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