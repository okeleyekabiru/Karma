namespace ShopyEcomerce.ef
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Order
    {
        public int Id { get; set; }

        public string ProductsName { get; set; }

        public decimal ProductPrice { get; set; }

        public DateTime DatePurchaced { get; set; }

        public int Category { get; set; }

        public int Quantity { get; set; }

        [StringLength(128)]
        public string User_Id { get; set; }
    }
}
