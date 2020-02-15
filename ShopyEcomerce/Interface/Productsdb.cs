using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopyEcomerce.ef;

namespace ShopyLibrary.Interface
{
  public  class Productsdb:IProducts
    {
        private readonly EcommerceDb _db;

        public Productsdb(EcommerceDb db)
        {
            _db = db;
        }
        public IEnumerable<Product> GetProductsByName(string product)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetProductsByCatergory(string CategoryEnum)
        {
            throw new NotImplementedException();
        }

        public Product GetProduct(int id)
        {
            throw new NotImplementedException();
        }

        public Product DeleteProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public Product UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetAllProducts()
        {
            throw new NotImplementedException();
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
