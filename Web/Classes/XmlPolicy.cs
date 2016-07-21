using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Xml;

namespace SkyInsurance.SkyPortal.Classes
{
    [ComplexType]
    public class XmlPolicy
    {
        public string PolicyReference { get; set; }

        public string Underwriter { get; set; }

        public string Mileage { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public DateTime EffectiveDate { get; set; }

        public string BusinessType { get; set; }

        public static object Create(XmlNode xml)
        {
            var policy = new XmlPolicy();
            try
            {
                policy.PolicyReference = xml.SelectSingleNode("./policyReference").InnerText;
            }
            catch
            {
                return $"Invalid Entry - /insurancePolicy/policyReference";
            }

            try
            {
                policy.Underwriter = xml.SelectSingleNode("./policyUnderwriter").InnerText;
            }
            catch
            {
                return $"Invalid Entry - /insurancePolicy/policyUnderwriter";
            }

            try
            {
                policy.Mileage = xml.SelectSingleNode("./policyMileage").InnerText;
            }
            catch
            {
                return $"Invalid Entry - /insurancePolicy/policyMileage";
            }

            try
            {
                policy.StartDate = DateTime.Parse(xml.SelectSingleNode("./policyStartDate").InnerText);
            }
            catch
            {
                return $"Invalid Entry - /insurancePolicy/policyStartDate";
            }

            try
            {
                policy.EndDate = DateTime.Parse(xml.SelectSingleNode("./policyEndDate").InnerText);
            }
            catch
            {
                return $"Invalid Entry - /insurancePolicy/policyEndDate";
            }

            try
            {
                policy.EffectiveDate = DateTime.Parse(xml.SelectSingleNode("./policyEffectiveDate").InnerText);
            }
            catch
            {
                return $"Invalid Entry - /insurancePolicy/policyEffectiveDate";
            }

            try
            {
                policy.BusinessType = xml.SelectSingleNode("./businessType").InnerText;
            }
            catch
            {
                return $"Invalid Entry - /insurancePolicy/businessType";
            }


            return policy;
        }

        public string ToXML()
        {
            string output = "";
            output += $"<policyReference>{PolicyReference}</policyReference>";
            output += $"<insuranceCompanyName>Sky Insurance</insuranceCompanyName>";
            output += $"<policyMileage>{Mileage}</policyMileage>";

            return output;
        }

    }
}