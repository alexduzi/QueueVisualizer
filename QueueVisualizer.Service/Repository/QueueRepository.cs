using QueueVisualizer.Service.Models;
using QueueVisualizer.Service.Repository.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Web;

namespace QueueVisualizer.Service.Repository
{
  public class QueueRepository : IRepository<QueueEntity>
  {

    public QueueRepository()
    {
      this.DbQueue = new MessageQueue(".");
    }

    private MessageQueue DbQueue { get; set; }

    public IEnumerable<QueueEntity> GetAll(bool isPublic)
    {
      MessageQueue[] queues;
      if (!isPublic)
        queues = MessageQueue.GetPrivateQueuesByMachine(".");
      else
        queues = MessageQueue.GetPublicQueues();

      foreach (MessageQueue queue in queues)
      {
        yield return new QueueEntity()
        {
          QtyMsg = queue.CanRead ? queue.GetAllMessages().ToList().Count() : 0,
          QueueName = queue.QueueName
        };
      }
    }

    public QueueEntity FindById(QueueEntity entity)
    {
      throw new NotImplementedException();
    }

    public void Update(QueueEntity entity)
    {
      throw new NotImplementedException();
    }

    public void Insert(QueueEntity entity)
    {
      throw new NotImplementedException();
    }

    public void Delete(string queueName, bool isPublic)
    {
      MessageQueue[] queues;
      if (!isPublic)
        queues = MessageQueue.GetPrivateQueuesByMachine(".");
      else
        queues = MessageQueue.GetPublicQueues();

      var queue = queues.FirstOrDefault(q => q.QueueName.ToUpper().Equals(queueName.ToUpper()));
      if (queue != null)
        queue.Purge();
    }
  }
}