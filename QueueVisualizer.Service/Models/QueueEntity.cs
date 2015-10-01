using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QueueVisualizer.Service.Models
{
  public class QueueEntity
  {
    public string QueueName { get; set; }
    public int QtyMsg { get; set; }
  }
}