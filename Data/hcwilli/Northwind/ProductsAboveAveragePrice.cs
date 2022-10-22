using System;
using System.Collections.Generic;

namespace App.Data.hcwilli.Northwind
{
    public partial class ProductsAboveAveragePrice
    {
        public string ProductName { get; set; } = null!;
        public decimal? UnitPrice { get; set; }
    }
}
