using SkyInsurance.SkyPortal.Enums;
using SkyInsurance.SkyPortal.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml;

namespace SkyInsurance.SkyPortal.Classes
{
    public class XmlMessage
    {
        public class Result
        {
            public IncomingMessage IncomingMessage { get; set; }
            public XmlMessage Message { get; set; }
        }

        public string MessageType { get; set; }

        public XmlPolicy Policy { get; set; }

        public XmlCustomer Customer { get; set; }

        public XmlVehicle Vehicle { get; set; }

        public XmlAppointment Appointment { get; set; }

        public int IncomingMessageID { get; set; }

        public static Result Create(Stream inputStream)
        {
            var result = ExtractXML(inputStream);
            if (result.Message != null)
            {
                result.Message.IncomingMessageID = result.IncomingMessage.ID;
            }

            return result;
        }

        private static Result ExtractXML(Stream inputStream)
        {
            StreamReader sr = new StreamReader(inputStream);
            string input = sr.ReadToEnd().Trim();
            var result = new Result();
            result.IncomingMessage = new IncomingMessage(input);

            var xml = new XmlDocument();
            try
            {
                xml.LoadXml(input);
            }
            catch (Exception ex)
            {
                result.IncomingMessage.Code = IncomingResponseCode.InvalidXml;
                result.IncomingMessage.Response = $"{ex.ToString()}";
                return result;
            }

            if (xml.DocumentElement.Name != "message")
            {
                result.IncomingMessage.Code = IncomingResponseCode.InvalidXml;
                result.IncomingMessage.Response = "Message not found";
                return result;
            }

            var message = new XmlMessage();

            try
            {
                message.MessageType = xml.SelectSingleNode("//messageType").InnerText;
            }
            catch
            {
                result.IncomingMessage.Code = IncomingResponseCode.InvalidData;
                result.IncomingMessage.Response = "Message Type";
                return result;
            }

            var customerResult = XmlCustomer.Create(xml.SelectSingleNode("//customer"));
            if (customerResult is string)
            {
                result.IncomingMessage.Code = IncomingResponseCode.InvalidData;
                result.IncomingMessage.Response = customerResult.ToString();
                return result;
            }
            message.Customer = customerResult as XmlCustomer;

            var policyResult = XmlPolicy.Create(xml.SelectSingleNode("//insurancePolicy"));
            if (policyResult is string)
            {
                result.IncomingMessage.Code = IncomingResponseCode.InvalidData;
                result.IncomingMessage.Response = policyResult.ToString();
                return result;
            }
            message.Policy = policyResult as XmlPolicy;

            var vehicleResult = XmlVehicle.Create(xml.SelectSingleNode("//vehicle"));
            if (vehicleResult is string)
            {
                result.IncomingMessage.Code = IncomingResponseCode.InvalidData;
                result.IncomingMessage.Response = vehicleResult.ToString();
                return result;
            }
            message.Vehicle = vehicleResult as XmlVehicle;

            var appointmentResult = XmlAppointment.Create(xml.SelectSingleNode("//appointmentRequest"));
            if (appointmentResult is string)
            {
                result.IncomingMessage.Code = IncomingResponseCode.InvalidData;
                result.IncomingMessage.Response = appointmentResult.ToString();
                return result;
            }
            message.Appointment = appointmentResult as XmlAppointment;

            result.IncomingMessage.Code = IncomingResponseCode.OK;
            result.IncomingMessage.Response = "OK";
            result.Message = message;
            return result;
        }
    }

}