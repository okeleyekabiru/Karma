using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopyEcomerce.ef;



namespace ShopyLibrary.Interface
{
  public  interface ICarts
  {
      Cart AddCart(Cart cart);
      IEnumerable<Cart> GetAllCarts();
      Cart GetCart( int id);
      void Delete(Cart cart);
      Cart Update(Cart cart);
      bool Commit();

  }
}
