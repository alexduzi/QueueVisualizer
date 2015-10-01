using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace QueueVisualizer.HostConsole
{
  class Program
  {
    static void Main(string[] args)
    {
      ServiceHost svcHost = null;
      try
      {
        svcHost = new ServiceHost(typeof(QueueVisualizer.SoapService.QueueService));
        svcHost.Open(); 
        Console.WriteLine("Service is Running  at following address");
        Console.WriteLine("http://localhost:9001/QueueVisualizer");
        Console.WriteLine("net.tcp://localhost:9002/QueueVisualizer");
      }
      catch (Exception ex)
      {
        svcHost = null;
        Console.WriteLine("Service can not be started \n\nError Message [{0}]", ex.Message);
      } if (svcHost != null)
      {
        Console.WriteLine("Press any key to close the Service");
        Console.ReadKey();
        svcHost.Close();
        svcHost = null;
      }       

    }
  }
}
