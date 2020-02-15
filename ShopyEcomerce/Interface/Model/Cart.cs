using ShopyLibrary.Model;

namespace ShopyLibrary.Ef
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Cart
    {
        public int Id { get; set; }

        public int Quantity { get; set; }

        public string ProductName { get; set; }

        public string Description { get; set; }

        public int Category { get; set; }

        public decimal Price { get; set; }

        [StringLength(128)]
        public string Users_Id { get; set; }

        public virtual Users User { get; set; }
    }
}
