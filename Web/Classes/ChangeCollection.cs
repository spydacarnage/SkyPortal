using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SkyInsurance.SkyPortal.Classes
{
    public class ChangeCollection : List<string>
    {
        public string ToXML()
        {
            string output = "";

            if (Count > 0) {
                output += "<messageChanges>";
                foreach (string change in this)
                {
                    output += $"<change>{change}</change>";
                }
                output += "</messageChanges>";
            }

            return output;
        }
    }
}