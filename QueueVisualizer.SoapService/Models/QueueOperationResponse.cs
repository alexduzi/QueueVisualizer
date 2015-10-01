using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace QueueVisualizer.SoapService.Models
{
  [DataContract]
  public class QueueOperationResponse
  {

    public QueueOperationResponse()
    {
      this.Queues = new List<QueueEntity>();
    }

    [DataMember]
    public List<QueueEntity> Queues { get; set; }
  }
}
