namespace ShopyEcomerce.ef
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class EcommerceDb : DbContext
    {
   
        public EcommerceDb()
            : base(@"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=GoodLifeEcommerce;Integrated Security=True")
        {
        }

        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
