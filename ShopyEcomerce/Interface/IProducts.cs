using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopyEcomerce.ef;


namespace ShopyLibrary.Interface
{
  public  interface IProducts
  {
      IEnumerable<Product> GetProductsByName(string product);
      IEnumerable<Product> GetProductsByCatergory(int CategoryEnum);
      Product GetProduct(int id);
      Product DeleteProduct(Product product);
      Product UpdateProduct(Product product);
      IEnumerable<Product> GetAllProducts();
      bool Commit();
    }
}
