using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SkyInsurance.SkyPortal.Models
{
    public class VehicleCollection : Collection<Vehicle>
    {
        public override Vehicle Add(Vehicle item)
        {
            var vehicle = this.SingleOrDefault(v => v.Active);
            if (vehicle != null)
            {
                vehicle.Active = false;
            }

            return base.Add(item);
        }

        public Vehicle ActiveVehicle => this.Last(v => v.Active);

        public string ToXML()
        {
            if (this.Count == 0)
            {
                return "";
            }

            return $"<vehicle>{ActiveVehicle.ToXML()}</vehicle>";
        }
    }
}