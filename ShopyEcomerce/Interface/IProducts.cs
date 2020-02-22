using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopyEcomerce;
using ShopyEcomerce.ef;


namespace ShopyLibrary
{
  public  interface IProducts
  {
      IEnumerable<Product> GetProductsByName(string product, int category);
      IEnumerable<Product> GetProductsByName(string product);
        IEnumerable<Product> GetProductsByCatergory(int CategoryEnum);
      Product GetProduct(int id);
      Product DeleteProduct(Product product);
      Product UpdateProduct(Product product);
      IEnumerable<Product> GetAllProducts();
      void AddProduct(Product product);
      IEnumerable<Product> SortedProducts(string sorted);
      int CountDb();
      IEnumerable<Product> Pagination(int page,int numberview);
      IEnumerable<Product> ProductByCategory(int catergory);
      bool Commit();
    }
}
