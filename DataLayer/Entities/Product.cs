using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class Product : BaseEntity
    {
        public Product()
        {
            this.CategoryProducts = new HashSet<CategoryProduct>();
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal Stock { get; set; }

        public ICollection<CategoryProduct> CategoryProducts { get; set; }
    }
}
