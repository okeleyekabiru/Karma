using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopyEcomerce.ef;

namespace ShopyLibrary.Interface
{
  public  interface IOrders
  {
      Order AddOrder(Order order);
      Order GetOrder(int id);
      IEnumerable<Order> GetAllOrder(string userId);
      void cancelOrder(IEnumerable<Order> order);
      Order UpdateOrder(Order order);
      bool Commit();
    }
}
