using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BeginApp.Services
{
    public class SMSService
    {
        public string Send(string phone, string text)
        {
            string reports = "";

            string apiKey = "ua6e68580ab06ebf20ef30f5ab3ed666f1e0acd313d52d4dfdb92b695a69ba60ec691c";
            string url = $"https://api.mobizon.ua/service/message/sendsmsmessage?recipient={phone}&text={text}&apiKey={apiKey}";
            WebRequest request = WebRequest.Create(url);
            request.Credentials = CredentialCache.DefaultCredentials;
            WebResponse response = request.GetResponse();
            reports += ((HttpWebResponse)response).StatusDescription;
            reports += "\r\n";
            using (Stream dataStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(dataStream);
                string responseFromServer = reader.ReadToEnd();
                reports += responseFromServer;
            }
            response.Close();

            return reports;
        }
    }
}
