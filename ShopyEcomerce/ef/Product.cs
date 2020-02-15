namespace ShopyEcomerce.ef
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Product
    {
        public int Id { get; set; }

        public string ProductName { get; set; }

        public string Description { get; set; }

        public int Category { get; set; }

        public decimal Price { get; set; }

        public byte[] Photos { get; set; }
    }
}
