using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopyEcomerce.ef;



namespace ShopyLibrary.Interface
{
 public   class CartsDb:ICarts
    {
        private readonly EcommerceDb _db;

        public CartsDb(EcommerceDb db)
        {
            _db = db;
        }
        public Cart AddCart(Cart cart)
        {
            Cart cart1 = _db.Carts.Add(cart);
            return cart;
        }

        public IEnumerable<Cart> GetAllCarts()
        {
            return _db.Carts.OrderBy(cart =>cart.ProductName).ToList();
        }

        public Cart GetCart(int id)
        {
            return _db.Carts.Find(id);
        }

        public void Delete(Cart cart)
        {
            _db.Carts.Remove(cart);
        }

        public Cart Update(Cart cart)
        {
            _db.Carts.Attach(cart);
            _db.Entry(cart).State = EntityState.Modified;
            return cart;
        }

        public bool Commit()
        {
          return  _db.SaveChanges() > 0;
        }
    }
}
