﻿using QueueVisualizer.SoapService.Contract;
using QueueVisualizer.SoapService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Web;

namespace QueueVisualizer.SoapService.Repository
{
  public class QueueRepository : IRepository<QueueOperationResponse, QueueOperationRequest>
  {

    public QueueRepository()
    {
      this.DbQueue = new MessageQueue(".");
    }

    private MessageQueue DbQueue { get; set; }

    public QueueOperationResponse GetAll(QueueOperationRequest entity)
    {
      MessageQueue[] queues;
      QueueOperationResponse response = new QueueOperationResponse();

      if (!entity.IsPublic)
        queues = MessageQueue.GetPrivateQueuesByMachine(".");
      else
        queues = MessageQueue.GetPublicQueues();

      foreach (MessageQueue queue in queues)
      {
        response.Queues.Add(new QueueEntity()
        {
          QtyMsg = queue.CanRead ? queue.GetAllMessages().ToList().Count() : 0,
          QueueName = queue.QueueName
        });
      }

      return response;
    }

    public QueueOperationResponse FindById(QueueOperationRequest entity)
    {
      throw new NotImplementedException();
    }

    public void Update(QueueOperationRequest entity)
    {
      throw new NotImplementedException();
    }

    public void Insert(QueueOperationRequest entity)
    {
      throw new NotImplementedException();
    }

    public void Delete(QueueOperationRequest entity)
    {
      MessageQueue[] queues;
      if (!entity.IsPublic)
        queues = MessageQueue.GetPrivateQueuesByMachine(".");
      else
        queues = MessageQueue.GetPublicQueues();

      var queue = queues.FirstOrDefault(q => q.QueueName.ToUpper().Equals(entity.QueueName.ToUpper()));
      if (queue != null)
        queue.Purge();
    }
  }
}