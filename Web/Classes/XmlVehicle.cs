using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Xml;

namespace SkyInsurance.SkyPortal.Classes
{
    [ComplexType]
    public class XmlVehicle
    {
        public string Make { get; set; }

        public string Model { get; set; }

        public string Type { get; set; }

        public string VIN { get; set; }

        public string Color { get; set; }

        public string EngineSize { get; set; }

        public string FuelType { get; set; }

        public string LicensePlateNumber { get; set; }

        public DateTime ManufactureDate { get; set; }

        public static object Create(XmlNode xml)
        {
            var vehicle = new XmlVehicle();
            var node = $"{xml.ParentNode.Name}/{xml.Name}";
            try
            {
                vehicle.Make = xml.SelectSingleNode("./make").InnerText;
            }
            catch
            {
                return $"Invalid Entry - /vehicle/make";
            }

            try
            {
                vehicle.Model = xml.SelectSingleNode("./model")?.InnerText;
            }
            catch
            {
                return $"Invalid Entry - /vehicle/model";
            }

            try
            {
                vehicle.Type = xml.SelectSingleNode("./type")?.InnerText;
            }
            catch
            {
                return $"Invalid Entry - /vehicle/type";
            }

            try
            {
                vehicle.VIN = xml.SelectSingleNode("./vin")?.InnerText;
            }
            catch
            {
                return $"Invalid Entry - /vehicle/vin";
            }

            try
            {
                vehicle.Color = xml.SelectSingleNode("./color")?.InnerText;
            }
            catch
            {
                return $"Invalid Entry - /vehicle/color";
            }

            try
            {
                vehicle.EngineSize = xml.SelectSingleNode("./engineSize").InnerText;
            }
            catch
            {
                return $"Invalid Entry - /vehicle/engineSize";
            }

            try
            {
                vehicle.FuelType = xml.SelectSingleNode("./fuelType").InnerText;
            }
            catch
            {
                return $"Invalid Entry - /vehicle/fuelType";
            }

            try
            {
                vehicle.LicensePlateNumber = xml.SelectSingleNode("./licensePlateNumber").InnerText;
            }
            catch
            {
                return $"Invalid Entry - /vehicle/licensePlateNumber";
            }

            try
            {
                vehicle.ManufactureDate = DateTime.Parse(xml.SelectSingleNode("./manufactureDate").InnerText);
            }
            catch
            {
                return $"Invalid Entry - /vehicle/manufactureDate";
            }

            return vehicle;
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