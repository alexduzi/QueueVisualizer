using QueueVisualizer.SoapService.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace QueueVisualizer.SoapService
{
  // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
  public class QueueService : IQueueServiceContract
  {
    public QueueService()
    {
      this.QueueRepository = new QueueRepository();
    }

    private QueueRepository QueueRepository { get; set; }

    public Models.QueueOperationResponse GetAll(Models.QueueOperationRequest entity)
    {
      return this.QueueRepository.GetAll(entity);
    }

    public Models.QueueOperationResponse Purge(Models.QueueOperationRequest entity)
    {
      this.QueueRepository.Delete(entity);
      return new Models.QueueOperationResponse();
    }
  }
}
