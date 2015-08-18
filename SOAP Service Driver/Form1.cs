using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ServiceModel;
using System.Net;
using System.Xml;
using System.IO;

namespace SOAP_Service_Driver
{
    public partial class Form1 : Form
    {
        public ServiceHost serviceHost;

        public Form1()
        {
            InitializeComponent();
            AppDomain.CurrentDomain.ProcessExit += new EventHandler(Form1_Closing);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Starting the basichttp service
            BasicHttpBinding binding = new BasicHttpBinding();

            binding.Name = "Basic_Binding";
            binding.HostNameComparisonMode = HostNameComparisonMode.WeakWildcard;
            binding.Security.Mode = BasicHttpSecurityMode.None;

            Uri baseAddress = new Uri("http://localhost:8733/Design_Time_Addresses/WcfServiceLibrary/BasicService/");
            Uri address = new Uri("http://localhost:8733/Design_Time_Addresses/WcfServiceLibrary/BasicService/mex");

            serviceHost = new ServiceHost(typeof(WcfServiceLibrary.BasicService), baseAddress);

            serviceHost.AddServiceEndpoint(typeof(WcfServiceLibrary.IBasicService), binding, "");

            // Open the ServiceHostBase to create listeners and start listening for messages.
            //serviceHost.Open();
        }

        private void BasicHttpBindingButtonHTTPBinding_Click(object sender, EventArgs e)
        {
            var _url = "http://localhost:8733/Design_Time_Addresses/WcfServiceLibrary/BasicService";
            var _action = "http://localhost:8733/Design_Time_Addresses/WcfServiceLibrary/BasicService?op=GetData";

            XmlDocument soapEnvelopeXml = CreateSoapEnvelope();
            HttpWebRequest webRequest = CreateWebRequest(_url, "");
            InsertSoapEnvelopeIntoWebRequest(soapEnvelopeXml, webRequest);

            // begin async call to web request.
            IAsyncResult asyncResult = webRequest.BeginGetResponse(null, null);

            // suspend this thread until call is complete. You might want to
            // do something usefull here like update your UI.
            asyncResult.AsyncWaitHandle.WaitOne();

            // get the response from the completed web request.
            string soapResult;
            using (WebResponse webResponse = webRequest.EndGetResponse(asyncResult))
            {
                using (StreamReader rd = new StreamReader(webResponse.GetResponseStream()))
                {
                    soapResult = rd.ReadToEnd();
                }
                ReturnValue.Text = soapResult;
            }

        }

        private void WSHTTPBindingButton_Click(object sender, EventArgs e)
        {

        }

        public HttpWebRequest CreateWebRequest(string url, string soapAction)
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
            webRequest.ContentType = "text/xml; charset=utf-8;";// action =\""+soapAction + "\"";
            webRequest.Method = "POST";
            return webRequest;
        }

        private static XmlDocument CreateSoapEnvelope()
        {
            XmlDocument soapEnvelop = new XmlDocument();
            soapEnvelop.LoadXml(@"<?xml version=""1.0"" encoding=""utf-8""?>
                <soap:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"">
                  <soap:Body>
                    <GetData xmlns=""http://tempuri.org/"">
                        <Value>""Hi""</Value>
                    </GetData>
                  </soap:Body>
                </soap:Envelope>");
            return soapEnvelop;
        }

        private static void InsertSoapEnvelopeIntoWebRequest(XmlDocument soapEnvelopeXml, HttpWebRequest webRequest)
        {
            using (Stream stream = webRequest.GetRequestStream())
            {
                soapEnvelopeXml.Save(stream);
            }
        }

        private void Form1_Closing(object sender, EventArgs e)
        {
            // Close the ServiceHostBase to shutdown the service.
            serviceHost.Close();
        }

    }
}
