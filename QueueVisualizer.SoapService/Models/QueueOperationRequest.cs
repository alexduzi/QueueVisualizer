using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace QueueVisualizer.SoapService.Models
{
  [DataContract]
  public class QueueOperationRequest
  {
    [DataMember]
    public bool IsPublic { get; set; }

    [DataMember]
    public string QueueName { get; set; }
  }
}
