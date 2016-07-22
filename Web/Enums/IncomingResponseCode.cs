using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SkyInsurance.SkyPortal.Enums
{
    public enum IncomingResponseCode
    {
        OK = 100,
        GeneralFailure = 200,
        InvalidXml = 201,
        InvalidData = 202
    }
}