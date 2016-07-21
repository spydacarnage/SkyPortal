using SkyInsurance.SkyPortal.Classes;
using SkyInsurance.SkyPortal.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Xml;

namespace SkyInsurance.SkyPortal.Models
{
    public class Policy : BaseEntity
    {
        [Display(Name = "Policy Reference")]
        public string PolicyReference { get; set; }

        public PolicyStatus Status { get; set; }

        public string Underwriter { get; set; }

        public string Mileage { get; set; }

        [Display(Name = "Start Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}")]
        public DateTime StartDate { get; set; }

        [Display(Name = "End Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}")]
        public DateTime EndDate { get; set; }

        public DateTime EffectiveDate { get; set; }

        public string BusinessType { get; set; }

        public VehicleCollection Vehicles { get; set; }

        //Navigation Properties
        public virtual Customer Customer { get; set; }

        public static Policy Create(XmlPolicy xml)
        {
            var policy = new Policy();
            policy.PolicyReference = xml.PolicyReference;
            policy.Status = PolicyStatus.New;
            policy.Underwriter = xml.Underwriter;
            policy.Mileage = xml.Mileage;
            policy.StartDate = xml.StartDate;
            policy.EndDate = xml.EndDate;
            policy.EffectiveDate = xml.EffectiveDate;
            policy.BusinessType = xml.BusinessType;
            policy.Vehicles = new VehicleCollection();

            return policy;
        }

        public ChangeCollection DetectChanges(XmlPolicy newPolicy, XmlVehicle newVehicle, ChangeCollection changes = null)
        {
            if (changes == null)
            {
                changes = new ChangeCollection();
            }

            if (Underwriter != newPolicy.Underwriter)
            {
                changes.Add("\\policy\\policyUnderwriter");
                Underwriter = newPolicy.Underwriter;
            }

            if (Mileage != newPolicy.Mileage)
            {
                changes.Add("\\policy\\policyMileage");
                Mileage = newPolicy.Mileage;
            }

            if (StartDate != newPolicy.StartDate)
            {
                changes.Add("\\policy\\policyStartDate");
                StartDate = newPolicy.StartDate;
            }

            if (EndDate != newPolicy.EndDate)
            {
                changes.Add("\\policy\\policyEndDate");
                EndDate = newPolicy.EndDate;
            }

            if (EffectiveDate != newPolicy.EffectiveDate)
            {
                changes.Add("\\policy\\policyEffectiveDate");
                EffectiveDate = newPolicy.EffectiveDate;
            }

            var vehicle = Vehicles.SingleOrDefault(v => v.VIN == newVehicle.VIN);
            if (vehicle == null)
            {
                changes.Add("\\vehicle");
                Vehicles.Add(Vehicle.Create(newVehicle));
            }
            else
            {
                changes = vehicle.DetectChanges(newVehicle, changes);
            }

            return changes;
        }

        public string ToXML()
        {
            string output = "";
            output += $"<policyReference>{PolicyReference}</policyReference>";
            output += $"<insuranceCompanyName>Sky Insurance</insuranceCompanyName>";
            output += $"<policyUnderwriter>{Underwriter}</policyUnderwriter>";
            output += $"<policyMileage>{Mileage}</policyMileage>";
            output += $"<policyStartDate>{StartDate.ToString("yyyy-MM-dd")}</policyStartDate>";
            output += $"<policyEffectiveDate>{EffectiveDate.ToString("yyyy-MM-dd")}</policyEffectiveDate>";
            output += $"<policyEndDate>{EndDate.ToString("yyyy-MM-dd")}</policyEndDate>";

            return output;
        }

    }
}