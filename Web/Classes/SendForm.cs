using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace SkyInsurance.SkyPortal.Classes
{
    public static class HttpSender
    {
        public class BasicAuth
        {
            public string Username { get; set; }
            public string Password { get; set; }

            public BasicAuth(string username, string password)
            {
                Username = username;
                Password = password;
            }
        }

        public class Response
        {
            public bool Success { get; set; } = false;
            public string Message { get; set; }
            public Exception Exception { get; set; }
        }

        public static Response SendXML(string url, string message, BasicAuth authorisation = null)
        {
            // Create a web request
            var req = WebRequest.Create(url);
            req.Method = "POST";
            if (authorisation != null)
            {
                req.Headers.Add("Authorization", $"Basic {ToBase64(authorisation)}");
            }

            byte[] byteData = new byte[message.Length];
            for (int i = 0; i < message.Length; i++)
                byteData[i] = (byte)message[i];
            req.ContentLength = byteData.Length;

            Stream wData = req.GetRequestStream();
            wData.Write(byteData, 0, byteData.Length);
            wData.Close();

            var response = new Response();
            // Get the response and read into a string
            try
            {
                var webResponse = req.GetResponse();
                StreamReader sr = new StreamReader(webResponse.GetResponseStream());
                string reply = sr.ReadToEnd();
                sr.Close();

                response.Success = true;
                response.Message = reply;

                return response;
            }
            catch (Exception ex)
            {
                response.Exception = ex;
                return response;
            }
        }

        public static Response SendForm(string url, Dictionary<string, string> formData, BasicAuth authorisation = null)
        {
            // Create a web request
            var req = WebRequest.Create(url);
            req.Method = "POST";
            if (authorisation != null)
            {
                req.Headers.Add("Authorization", $"Basic {ToBase64(authorisation)}");
            }

            string message = "";
            foreach (string key in formData.Keys)
            {
                message += (message != "" ? "&" : "") + key + "=" + formData[key];
            }

            byte[] byteData = new byte[message.Length];
            for (int i = 0; i < message.Length; i++)
                byteData[i] = (byte)message[i];
            req.ContentLength = byteData.Length;
            req.ContentType = "application/x-www-form-urlencoded";

            Stream wData = req.GetRequestStream();
            wData.Write(byteData, 0, byteData.Length);
            wData.Close();

            var response = new Response();
            // Get the response and read into a string
            try
            {
                var webResponse = req.GetResponse();
                StreamReader sr = new StreamReader(webResponse.GetResponseStream());
                string reply = sr.ReadToEnd();
                sr.Close();

                response.Success = true;
                response.Message = reply;

                return response;
            }
            catch (Exception ex)
            {
                response.Exception = ex;
                return response;
            }
        }

        private static string ToBase64(BasicAuth authorisation)
        {
            //string username = "skyinsurance";
            //string password = "rAn1859mOrE";

            string username = authorisation.Username;
            string password = authorisation.Password;

            string toEncode = $"{username}:{password}";

            var bytes = Encoding.UTF8.GetBytes(toEncode);
            var result = Convert.ToBase64String(bytes);

            return result;
        }

    }

}