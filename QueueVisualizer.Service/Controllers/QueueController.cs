using QueueVisualizer.Service.Models;
using QueueVisualizer.Service.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Helpers;
using System.Web.Http;

namespace QueueVisualizer.Service.Controllers
{
    public class QueueController : ApiController
    {
      public QueueController()
      {
        repository = new QueueRepository();
      }

      private QueueRepository repository;


      public QueueEntity[] Get([FromBody]bool isPublic)
      {
        return repository.GetAll(isPublic).ToArray();
      }

      public QueueEntity GetQueue([FromBody]string queueName)
      {
        return repository.FindById(new QueueEntity(){ QueueName = queueName });
      }

      
      public void PurgeQueue([FromBody]string queueName, [FromBody]bool isPublic)
      {
        repository.Delete(queueName, isPublic);
      }
    }
}
