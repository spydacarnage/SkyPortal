using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SkyInsurance.SkyPortal.Enums
{
    public enum PolicyStatus
    {
        New = 1,
        Active = 2,
        Lapsed = 3,
        Cancelled = 4,
        PendingLapse = 5,
        PendingCancel = 6
    }

    public class PolicyStatusDefinition : EnumString<PolicyStatus> { }
}