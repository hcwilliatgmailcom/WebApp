﻿using System;
using System.Collections.Generic;

namespace App.Data.hcwilli.Northwind
{
    public partial class SummaryOfSalesByYear
    {
        public DateTime? ShippedDate { get; set; }
        public int OrderId { get; set; }
        public decimal? Subtotal { get; set; }
    }
}
