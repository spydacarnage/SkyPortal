using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Xml;

namespace SkyInsurance.SkyPortal.Classes
{
    public class XmlCustomer
    {
        public string CustomerRef { get; set; }

        public string Title { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Mobile { get; set; }

        public string DayPhone { get; set; }

        public string EveningPhone { get; set; }

        public string Email { get; set; }

        public DateTime DoB { get; set; }

        public XmlAddress Address { get; set; }

        public bool HasPassword { get; set; }


        public static object Create(XmlNode xml)
        {
            var customer = new XmlCustomer();
            try
            {
                customer.CustomerRef = xml.SelectSingleNode("./customerReference").InnerText;
            }
            catch
            {
                return "Customer => Customer Reference";

            }

            try
            {
                customer.Title = xml.SelectSingleNode("./title").InnerText;
            }
            catch
            {
                return "Customer => Title";

            }

            try
            {
                customer.FirstName = xml.SelectSingleNode("./firstName").InnerText;
            }
            catch
            {
                return "Customer => First Name";

            }

            try
            {
                customer.LastName = xml.SelectSingleNode("./lastName").InnerText;
            }
            catch
            {
                return "Customer => Last Name";

            }

            try
            {
                customer.Mobile = xml.SelectSingleNode("./mobilePhone").InnerText;
            }
            catch
            {
                return "Customer => Mobile Phone";

            }

            try
            {
                customer.DayPhone = xml.SelectSingleNode("./dayTimePhone").InnerText;
            }
            catch
            {
                return "Customer => Day Time Phone";

            }

            try
            {
                customer.EveningPhone = xml.SelectSingleNode("./eveningPhone").InnerText;
            }
            catch
            {
                return "Customer => Evening Phone";

            }

            try
            {
                customer.Email = xml.SelectSingleNode("./email").InnerText;
            }
            catch
            {
                return "Customer => Email";

            }

            try
            {
                customer.DoB = DateTime.Parse(xml.SelectSingleNode("./birthDate").InnerText);
            }
            catch
            {
                return "Customer => Birth Date";

            }

            try
            {
                customer.HasPassword = bool.Parse(xml.SelectSingleNode("./hasPassword").InnerText);
            }
            catch
            {
                customer.HasPassword = false;

            }

            var addressResult = XmlAddress.Create(xml.SelectSingleNode("./address"));
            if (addressResult is string)
            {
                return addressResult.ToString();
            }
            customer.Address = addressResult as XmlAddress;

            return customer;
        }

    }

}