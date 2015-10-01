using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace QueueVisualizer.SoapService.Models
{
  [DataContract]
  public class QueueEntity
  {
    [DataMember]
    public string QueueName { get; set; }
    [DataMember]
    public int QtyMsg { get; set; }
  }
}