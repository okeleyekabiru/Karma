using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopyEcomerce.ef;
using Order = ShopyLibrary.Ef.Order;

namespace ShopyLibrary.Interface
{
  public  class OrdersDb:IOrders
    {
        private readonly EcommerceDb _db;

        public OrdersDb(EcommerceDb db)
        {
            _db = db;
        }
        public Order AddOrder(Order order)
        {
            throw new NotImplementedException();
        }

        public Order GetOrder(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> GetAllOrder(string userId)
        {
            throw new NotImplementedException();
        }

        public Order cancelOrder(bool cancelConfirmation, int id)
        {
            throw new NotImplementedException();
        }

        public Order UpdateOrder(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
