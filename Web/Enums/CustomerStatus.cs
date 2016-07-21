using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SkyInsurance.SkyPortal.Enums
{
    public enum CustomerStatus
    {
        New = 1,
        Active = 2
    }

    public class CustomerStatusDefinition : EnumString<CustomerStatus> { }
}