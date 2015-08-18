using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace BasicServiceConsoleHost
{
    [ServiceContract]
    public interface IBasicService
    {
        [OperationContract]
        string GetData(string value);
    }

    public class BasicService : IBasicService
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
            Uri baseAddress = new Uri("http://localhost:8773/BasicService");

            BasicHttpBinding binding = new BasicHttpBinding();

            binding.Name = "Basic_Binding";
            binding.HostNameComparisonMode = HostNameComparisonMode.WeakWildcard;
            binding.Security.Mode = BasicHttpSecurityMode.None;

            using (ServiceHost host = new ServiceHost(typeof(BasicService), baseAddress))
            {
                host.AddServiceEndpoint(typeof(IBasicService), binding, "http://localhost:8773/BasicService/mex");
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
