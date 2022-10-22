using System;
using System.Collections.Generic;

namespace App.Data.hcwilli.Northwind
{
    public partial class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        /// <summary>
        /// TestComment
        /// </summary>
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = null!;
        /// <summary>
        /// Testcomment
        /// </summary>
        public string? Description { get; set; }
        public byte[]? Picture { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
