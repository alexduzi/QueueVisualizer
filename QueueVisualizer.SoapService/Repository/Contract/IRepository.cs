using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QueueVisualizer.SoapService.Contract
{
  public interface IRepository<T, U> 
  {
    T GetAll(U entity);
    T FindById(U entity);
    void Update(U entity);
    void Insert(U entity);
    void Delete(U entity);
  }
}