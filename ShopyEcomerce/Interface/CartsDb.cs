using System;
using System.Collections.Generic;
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
            _db.Carts.Add(cart);
            return cart;
        }

        public IEnumerable<Cart> GetAllCarts()
        {
            throw new NotImplementedException();
        }

        public Cart GetCart(int id)
        {
            throw new NotImplementedException();
        }

        public Cart Delete(Cart cart)
        {
            throw new NotImplementedException();
        }

        public Cart Update(Cart cart)
        {
            throw new NotImplementedException();
        }
    }
}
