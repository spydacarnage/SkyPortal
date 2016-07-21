using SkyInsurance.SkyPortal.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Xml;

namespace SkyInsurance.SkyPortal.Models
{
    public class Vehicle : BaseEntity
    {
        public string Make { get; set; }

        public string Model { get; set; }

        public string Type { get; set; }

        public string VIN { get; set; }

        public string Color { get; set; }

        public string EngineSize { get; set; }

        public string FuelType { get; set; }

        [Display(Name = "Reg Number")]
        public string LicensePlateNumber { get; set; }

        public DateTime ManufactureDate { get; set; }

        public bool Active { get; set; }


        //Navigation Properties
        public virtual Policy Policy { get; set; }

        public static Vehicle Create(XmlVehicle xml)
        {
            var vehicle = new Vehicle();
            vehicle.Make = xml.Make;
            vehicle.Model = xml.Model;
            vehicle.Type = xml.Type;
            vehicle.VIN = xml.VIN;
            vehicle.Color = xml.Color;
            vehicle.EngineSize = xml.EngineSize;
            vehicle.FuelType = xml.FuelType;
            vehicle.LicensePlateNumber = xml.LicensePlateNumber;
            vehicle.ManufactureDate = xml.ManufactureDate;
            vehicle.Active = true;

            return vehicle;
        }

        public ChangeCollection DetectChanges(XmlVehicle newVehicle, ChangeCollection changes = null)
        {
            if (changes == null)
            {
                changes = new ChangeCollection();
            }

            if (Make != newVehicle.Make)
            {
                changes.Add("\\vehicle\\make");
                Make = newVehicle.Make;
            }

            if (Model != newVehicle.Model)
            {
                changes.Add("\\vehicle\\model");
                Model = newVehicle.Model;
            }

            if (Type != newVehicle.Type)
            {
                changes.Add("\\vehicle\\type");
                Type = newVehicle.Type;
            }

            if (Color != newVehicle.Color)
            {
                changes.Add("\\vehicle\\color");
                Color = newVehicle.Color;
            }

            if (EngineSize != newVehicle.EngineSize)
            {
                changes.Add("\\vehicle\\engineSize");
                EngineSize = newVehicle.EngineSize;
            }

            if (FuelType != newVehicle.FuelType)
            {
                changes.Add("\\vehicle\\fuelType");
                FuelType = newVehicle.FuelType;
            }

            if (LicensePlateNumber != newVehicle.LicensePlateNumber)
            {
                changes.Add("\\vehicle\\licensePlateNumber");
                LicensePlateNumber = newVehicle.LicensePlateNumber;
            }

            if (ManufactureDate != newVehicle.ManufactureDate)
            {
                changes.Add("\\vehicle\\manufactureDate");
                ManufactureDate = newVehicle.ManufactureDate;
            }

            return changes;
        }

        public string ToXML()
        {
            string output = "";
            output += $"<make>{Make}</make>";
            output += $"<model>{Model}</model>";
            output += $"<type>{Type}</type>";
            output += $"<vin>{VIN}</vin>";
            output += $"<color>{Color}</color>";
            output += $"<engineSize>{EngineSize}</engineSize>";
            output += $"<fuelType>{FuelType}</fuelType>";
            output += $"<licensePlateNumber>{LicensePlateNumber}</licensePlateNumber>";
            output += $"<manufactureDate>{ManufactureDate.ToString("yyyy-MM-dd")}</manufactureDate>";

            return output;
        }

    }
}