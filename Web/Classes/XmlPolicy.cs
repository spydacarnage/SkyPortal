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
                return "Insurance Policy => Policy Reference";
            }

            try
            {
                policy.Underwriter = xml.SelectSingleNode("./policyUnderwriter").InnerText;
            }
            catch
            {
                return "Insurance Policy => Policy Underwriter";
            }

            try
            {
                policy.Mileage = xml.SelectSingleNode("./policyMileage").InnerText;
            }
            catch
            {
                return "Insurance Policy => Policy Mileage";
            }

            try
            {
                policy.StartDate = DateTime.Parse(xml.SelectSingleNode("./policyStartDate").InnerText);
            }
            catch
            {
                return "Insurance Policy => Policy Start Date";
            }

            try
            {
                policy.EndDate = DateTime.Parse(xml.SelectSingleNode("./policyEndDate").InnerText);
            }
            catch
            {
                return "Insurance Policy => Policy End Date";
            }

            try
            {
                policy.EffectiveDate = DateTime.Parse(xml.SelectSingleNode("./policyEffectiveDate").InnerText);
            }
            catch
            {
                return "Insurance Policy => Policy Effective Date";
            }

            try
            {
                policy.BusinessType = xml.SelectSingleNode("./businessType").InnerText;
            }
            catch
            {
                return "Insurance Policy => Business Type";
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