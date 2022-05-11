using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Repositories
{
    public class CategoryRepository : CrudRepository<Category>
    {
        public CategoryRepository(ProductContext dbContext) 
            : base(dbContext, dbContext.Categories)
        {
        }

        public ICollection<Product> GetAllProducts(Category category)
        {
            return
                category
                    .CategoryProducts
                    .Select(cp => cp.Product)
                    .ToList();
        }
    }
}
