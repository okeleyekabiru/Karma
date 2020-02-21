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
  public  class Productsdb:IProducts
    {
        private readonly EcommerceDb _db;

        public Productsdb(EcommerceDb db)
        {
            _db = db;
        }
        public IEnumerable<Product> GetProductsByName(string product,int category)
        {
            
            var  content =  _db.Products.Where(r => string.IsNullOrEmpty(r.ProductName)  || r.ProductName.StartsWith(product) &&(int) r.Category == category).OrderBy(r => r.ProductName)
                .OrderBy(r => r.ProductName);
          

            return content;
        }
        public IEnumerable<Product> GetProductsByName(string product)
        {

            var content = _db.Products.Where(r => string.IsNullOrEmpty(r.ProductName) || r.ProductName.StartsWith(product)).OrderBy(r => r.ProductName)
                .OrderBy(r => r.ProductName);
          
            return content;
        }
        public IEnumerable<Product> GetProductsByCatergory(int CategoryEnum)
        {
           var  content = _db.Products.Where(r => (int)(r.Category) == CategoryEnum).OrderBy(r => r.ProductName);
   

           return content;
        }

        public Product GetProduct(int id)
        {
           var content=_db.Products.Find(id);
        
           return content;
        }

        public Product DeleteProduct(Product product)
        {

            _db.Products.Remove(product);
            return product;
        }

        public Product UpdateProduct(Product product)
        {

            var entry = _db.Entry(product);
            entry.State = EntityState.Modified;
            return product;
        }

        public IEnumerable<Product> GetAllProducts()
        {
           
           var content =  _db.Products.OrderBy(r => r.ProductName).ToList();
    

           return content;
        }

        public void AddProduct(Product product)
        {
            _db.Products.Add(product);
        }

        public IEnumerable<Product> SortedProducts(string sorted)
        {
            if (sorted.Equals("price"))
            {
              return  _db.Products.OrderBy(r => r.ProductName);
            }

            return _db.Products.OrderBy(r => r.Price);

        }

        public bool Commit()
        {
            return _db.SaveChanges() > 0;
        }

       
    }
}
