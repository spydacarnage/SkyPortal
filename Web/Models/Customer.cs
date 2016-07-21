using SkyInsurance.SkyPortal.Classes;
using SkyInsurance.SkyPortal.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Xml;

namespace SkyInsurance.SkyPortal.Models
{
    public class Customer : BaseEntity
    {
        [Display(Name = "Customer Reference")]
        public string CustomerRef { get; set; }

        public CustomerStatus Status { get; set; }

        public string Title { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Mobile { get; set; }

        public string DayPhone { get; set; }

        public string EveningPhone { get; set; }

        public string Email { get; set; }

        public DateTime DoB { get; set; }

        public Address Address { get; set; }

        public bool HasPassword { get; set; }

        public PolicyCollection Policies { get; set; }

        public Appointment Appointment { get; set; }

        public string DeviceContractReference { get; set; }

        public Policy LastPolicy
        {
            get
            {
                if (Policies == null || Policies.Count == 0)
                {
                    return null;
                }

                return Policies.Last();
            }
        }


        // Display Properties
        [Display(Name = "Name")]
        public string Name => $"{FirstName} {LastName}";

        public static Customer Create(XmlCustomer xml)
        {
            var customer = new Customer();
            customer.CustomerRef = xml.CustomerRef;
            customer.Status = CustomerStatus.New;
            customer.Title = xml.Title;
            customer.FirstName = xml.FirstName;
            customer.LastName = xml.LastName;
            customer.Mobile = xml.Mobile;
            customer.DayPhone = xml.DayPhone;
            customer.EveningPhone = xml.EveningPhone;
            customer.Email = xml.Email;
            customer.DoB = xml.DoB;
            customer.HasPassword = xml.HasPassword;
            customer.Address = Address.Create(xml.Address);
            customer.Policies = new PolicyCollection();

            return customer;
        }

        public ChangeCollection DetectChanges(XmlCustomer newCustomer, ChangeCollection changes = null)
        {
            if (changes == null)
            {
                changes = new ChangeCollection();
            }

            if (Title != newCustomer.Title)
            {
                changes.Add("\\customer\\title");
                Title = newCustomer.Title;
            }
            if (FirstName != newCustomer.FirstName)
            {
                changes.Add("\\customer\\firstName");
                FirstName = newCustomer.FirstName;
            }
            if (LastName != newCustomer.LastName)
            {
                changes.Add("\\customer\\lastName");
                LastName = newCustomer.LastName;
            }
            if (Mobile != newCustomer.Mobile)
            {
                changes.Add("\\customer\\mobilePhone");
                Mobile = newCustomer.Mobile;
            }
            if (DayPhone != newCustomer.DayPhone)
            {
                changes.Add("\\customer\\dayTimePhone");
                DayPhone = newCustomer.DayPhone;
            }
            if (EveningPhone != newCustomer.EveningPhone)
            {
                changes.Add("\\customer\\eveningPhone");
                EveningPhone = newCustomer.EveningPhone;
            }
            if (Email != newCustomer.Email)
            {
                changes.Add("\\customer\\email");
                Email = newCustomer.Email;
            }
            changes = Address.DetectChanges(newCustomer.Address, "\\customer\\address", changes);

            return changes;
        }

        public string ToXML()
        {
            string output = "";
            output += $"<title>{Title}</title>";
            output += $"<firstName>{FirstName}</firstName>";
            output += $"<lastName>{LastName}</lastName>";
            output += $"<mobilePhone>{Mobile}</mobilePhone>";
            output += $"<dayTimePhone>{DayPhone}</dayTimePhone>";
            output += $"<eveningPhone>{EveningPhone}</eveningPhone>";
            output += $"<email>{Email}</email>";
            output += $"<birthDate>{DoB.ToString("yyyy-MM-dd")}</birthDate>";
            output += $"<address>{Address.ToXML()}</address>";

            return output;
        }
    }

}