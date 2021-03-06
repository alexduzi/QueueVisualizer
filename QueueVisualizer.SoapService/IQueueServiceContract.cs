﻿using QueueVisualizer.SoapService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace QueueVisualizer.SoapService
{
  // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
  [ServiceContract]
  public interface IQueueServiceContract
  {
    [OperationContract]
    QueueOperationResponse GetAll(QueueOperationRequest entity);

    [OperationContract]
    QueueOperationResponse Purge(QueueOperationRequest entity);

    [OperationContract]
    QueueOperationResponse PopulateData(Models.QueueOperationRequest entity);
  }


}
