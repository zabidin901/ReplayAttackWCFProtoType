using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;

namespace WSHttpServiceConsoleHost
{
    [ServiceContract]
    public interface IWSHttpService
    {
        [OperationContract]
        string GetData(string value);
    }

    public class WSHttpService : IWSHttpService
    {
        public string GetData(string value)
        {
            return string.Format("You entered: {0}", value);
        }
    }
     
    public class Program
    {
        static void Main(string[] args)
        {
            Uri baseAddress = new Uri("http://localhost:8773/WSHttpService");

            WSHttpBinding binding = new WSHttpBinding();

            binding.Name = "WSHttp_Binding";
            binding.HostNameComparisonMode = HostNameComparisonMode.WeakWildcard;
            CustomBinding customBinding = new CustomBinding(binding);
            SymmetricSecurityBindingElement securityBinding = (SymmetricSecurityBindingElement)customBinding.Elements.Find<SecurityBindingElement>();

            /// Change the MaxClockSkew to 2 minutes on both service and client settings.
            TimeSpan newClockSkew = new TimeSpan(0, 2, 0);

            securityBinding.LocalServiceSettings.MaxClockSkew = newClockSkew;
            securityBinding.LocalClientSettings.MaxClockSkew = newClockSkew;

            using (ServiceHost host = new ServiceHost(typeof(WSHttpService), baseAddress))
            {
                host.AddServiceEndpoint(typeof(IWSHttpService), customBinding, "http://localhost:8773/WSHttpService/mex");
                // Enable metadata publishing.
                ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                smb.HttpGetEnabled = true;
                smb.MetadataExporter.PolicyVersion = PolicyVersion.Policy15;
                host.Description.Behaviors.Add(smb);
                host.Open();

                Console.WriteLine("The service is ready at {0}", baseAddress);
                Console.WriteLine("Press <Enter> to stop the service.");
                Console.ReadLine();

                // Close the ServiceHost.
                host.Close();
            }
        }
    }
}
