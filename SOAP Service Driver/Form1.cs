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
            Uri address = new Uri("http://localhost:8733/Design_Time_Addresses/WcfServiceLibrary/BasicService/basic");

            serviceHost = new ServiceHost(typeof(WcfServiceLibrary.BasicService), baseAddress);

            serviceHost.AddServiceEndpoint(typeof(WcfServiceLibrary.IBasicService), binding, address);

            // Open the ServiceHostBase to create listeners and start listening for messages.
            //serviceHost.Open();
        }

        private void BasicHttpBindingButtonHTTPBinding_Click(object sender, EventArgs e)
        {
            var _url = "http://localhost:8733/Design_Time_Addresses/WcfServiceLibrary/BasicService";
            var _action = "http://localhost:8733/Design_Time_Addresses/WcfServiceLibrary/BasicService?op=GetData";

        }

        private void WSHTTPBindingButton_Click(object sender, EventArgs e)
        {

        }

        private static HttpWebRequest CreateWebRequest(string url, string action)
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
            webRequest.Headers.Add("SOAPAction", action);
            webRequest.ContentType = "text/xml;charset=\"utf-8\"";
            webRequest.Accept = "text/xml";
            webRequest.Method = "POST";
            return webRequest;
        }

        private static XmlDocument CreateSoapEnvelope()
        {
            XmlDocument soapEnvelop = new XmlDocument();
            soapEnvelop.LoadXml(@"<SOAP-ENV:Envelope xmlns:SOAP-ENV=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:xsi=""http://www.w3.org/1999/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/1999/XMLSchema"">
            <SOAP-ENV:Body>
                <GetData xmlns=""http://tempuri.org/"" SOAP-ENV:encodingStyle=""http://schemas.xmlsoap.org/soap/encoding/"">
                    <Value></Value>
                </GetData>
            </SOAP-ENV:Body></SOAP-ENV:Envelope>");
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
