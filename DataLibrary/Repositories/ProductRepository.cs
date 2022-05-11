using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Repositories
{
    public class ProductRepository : CrudRepository<Product>
    {
        public ProductRepository(ProductContext dbContext) 
            : base(dbContext, dbContext.Products)
        {
        }

        public ICollection<Category> GetAllCategories(Product product)
        {
            return product
                .CategoryProducts
                .Select(cp => cp.Category)
                .ToList();
        }

    }
}
