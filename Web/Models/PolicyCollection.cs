using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SkyInsurance.SkyPortal.Models
{
    public class PolicyCollection : Collection<Policy>
    {
        public string ToXML(string policyNumber = null)
        {
            if (Count == 0)
            {
                return "";
            }

            var policy = (policyNumber == null ? this.Last() : this.Single(p => p.PolicyReference == policyNumber));

            return $"<insurancePolicy>{policy.ToXML()}</insurancePolicy>";
        }

        public string VehicleXML(string policyNumber = null)
        {
            if (Count == 0)
            {
                return "";
            }

            var policy = (policyNumber == null ? this.Last() : this.Single(p => p.PolicyReference == policyNumber));

            return policy.Vehicles.ToXML();
        }
    }
}