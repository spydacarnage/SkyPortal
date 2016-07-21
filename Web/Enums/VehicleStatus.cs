using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SkyInsurance.SkyPortal.Enums
{
    public enum VehicleStatus
    {
        Active = 1,
        Expired = 2
    }

    public class VehicleStatusDefinition : EnumString<VehicleStatus> { }
}