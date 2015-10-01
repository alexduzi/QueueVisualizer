using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QueueVisualizer.Service.Repository.Contract
{
  public interface IRepository<T> where T: class
  {
    IEnumerable<T> GetAll(bool isPublic);
    T FindById(T entity);
    void Update(T entity);
    void Insert(T entity);
    void Delete(string queueName, bool isPublic);
  }
}