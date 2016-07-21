using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SkyInsurance.SkyPortal.Enums
{
    public enum MessageStatus
    {
        Pending = 0,
        OK = 1,
        Retry1 = 2,
        Retry2 = 3,
        Failure = 4
    }

    public class MessageStatusDefinition : EnumString<MessageStatus> { }
}