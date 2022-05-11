using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class Category : BaseEntity
    {
        public Category()
        {
            this.CategoryProducts = new HashSet<CategoryProduct>();
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<CategoryProduct> CategoryProducts { get; set; }
    }
}
