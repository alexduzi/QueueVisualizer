using QueueVisualizer.SoapService.Contract;
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

      if(!string.IsNullOrEmpty(entity.QueueName))
      {
        var queuesFilter = queues
                                .Where(q => q.QueueName.ToUpper().Contains(entity.QueueName.ToUpper()))
                                .Select(x =>
                                            new QueueEntity() 
                                            { 
                                              QtyMsg = x.CanRead ? x.GetAllMessages().ToList().Count() : 0, 
                                              QueueName = x.QueueName
                                            }).ToList();
        if(queuesFilter != null)
          response.Queues.AddRange(queuesFilter);
      }
      else
      {
        foreach (MessageQueue queue in queues)
        {
          response.Queues.Add(new QueueEntity()
          {
            QtyMsg = queue.CanRead ? queue.GetAllMessages().ToList().Count() : 0,
            QueueName = queue.QueueName
          });
        }
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
      try
      {
        var msg = new List<System.Messaging.Message>();
        using (MessageQueue mq = new MessageQueue(string.Format("FormatName:Direct=OS:.\\private$\\{0}", entity.QueueName)))
        {
          entity.Message.ForEach(x => msg.Add(new System.Messaging.Message() { Body = x.Value }));
          msg.ForEach(m => mq.Send(m, MessageQueueTransactionType.Single));
        }
      }
      catch (Exception)
      {
      }
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