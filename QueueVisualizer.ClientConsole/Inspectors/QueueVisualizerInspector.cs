using QueueVisualizer.SoapService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading.Tasks;

namespace QueueVisualizer.ClientConsole.Inspectors
{
  public class QueueVisualizerInspector : IClientMessageInspector
  {
    public void AfterReceiveReply(ref System.ServiceModel.Channels.Message reply, object correlationState)
    {
    }

    public object BeforeSendRequest(ref System.ServiceModel.Channels.Message request, System.ServiceModel.IClientChannel channel)
    {
      //Console.WriteLine(request.GetReaderAtBodyContents());
      return request;
    }
  }
}
