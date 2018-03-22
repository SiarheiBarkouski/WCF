using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using Infrastructure;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            var address = new Uri(@"http://127.0.0.1:60001/IProcessInformation");
            var binding = new BasicHttpBinding();
            var contract = typeof(IProcessInformation);

            var host = new ServiceHost(typeof(ProcessInformation));
            host.AddServiceEndpoint(contract, binding, address);
            host.Open();
            Console.ReadKey();
        }
    }
}
