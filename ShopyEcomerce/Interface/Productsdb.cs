using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopyEcomerce;
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
            return _db.Products.Where(r => string.IsNullOrEmpty(r.ProductName) || r.ProductName.StartsWith(product))
                .OrderBy(r => r.ProductName);
        }

        public IEnumerable<Product> GetProductsByCatergory(int CategoryEnum)
        {
            return _db.Products.Where(r => (int)(r.Category) == CategoryEnum).OrderBy(r => r.ProductName);
        }

        public Product GetProduct(int id)
        {
            return _db.Products.Find(id);
        }

        public Product DeleteProduct(Product product)
        {
            _db.Products.Remove(product);
            return product;
        }

        public Product UpdateProduct(Product product)
        {
            _db.Products.Attach(product);
            _db.Entry(product).State = EntityState.Modified;
            return product;
        }

        public IEnumerable<Product> GetAllProducts()
        {
           
           var content =  _db.Products.OrderBy(r => r.ProductName).ToList();
           foreach (var VARIABLE in content)
           {
               VARIABLE.Photos = BusinessLogic.GetImageFromByteArray(VARIABLE.Photos);
           }

           return content;
        }

        public void AddProduct(Product product)
        {
            _db.Products.Add(product);
        }

        public bool Commit()
        {
            return _db.SaveChanges() > 0;
        }

       
    }
}
