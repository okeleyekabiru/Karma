using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopyEcomerce;
using ShopyEcomerce.ef;


namespace ShopyLibrary
{
  public  class OrdersDb:IOrders
    {
        private readonly EcommerceDb _db;

        public OrdersDb(EcommerceDb db)
        {
            _db = db;
        }
        public IEnumerable<Order> AddOrder(IEnumerable<Order> order)
        {
            _db.Orders.AddRange(order);
            return order;
        }

        public Order GetOrder(int id)
        {
           return  _db.Orders.Find(id);
          
        }

        public IEnumerable<Order> GetAllOrder(string userId)
        {
            return  _db.Orders.Where(r => r.User_Id == userId).ToList();

        }

        public void cancelOrder( IEnumerable<Order> order)
        {
            _db.Orders.RemoveRange(order);

        }

        public Order UpdateOrder(Order order)
        {
            var entry = _db.Entry(order);
            entry.State = EntityState.Modified;
            return order;
        }

        public bool Commit()
        {
           return _db.SaveChanges() > 0;
        }
    }
}
