using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopyLibrary.Ef;

namespace ShopyLibrary.Interface
{
  public  interface IOrders
  {
      Order AddOrder(Order order);
      Order GetOrder(int id);
      IEnumerable<Order> GetAllOrder(string userId);
      Order cancelOrder(bool cancelConfirmation, int id);
      Order UpdateOrder(Order order);

  }
}
