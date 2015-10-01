using QueueVisualizer.ClientConsole.Inspectors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueVisualizer.ClientConsole
{
  class Program
  {
    static void Main(string[] args)
    {
      QueueService.QueueServiceContractClient client =
        new QueueService.QueueServiceContractClient();
      client.Endpoint.EndpointBehaviors.Add(new QueueVisualizerInspectorBehavior());
      client.GetAll(new SoapService.Models.QueueOperationRequest()
      {
        IsPublic = false,
        QueueName = string.Empty
      });
    }
  }
}
