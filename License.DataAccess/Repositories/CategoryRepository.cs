using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using License.DataAccess.Infrastructure;
using License.Models.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace License.DataAccess.Repositories
{
    public class CategoryRepository : BaseRepository<CategoryModel>, ICategoryRepository
    {
        public CategoryRepository(LicenseDbContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<CategoryModel> Get()
        {
            return _dbContext.Categories.Include(c => c.Subcategories).AsEnumerable();
        }

        public CategoryModel Get(Guid categoryId)
        {
            return _dbContext.Categories.Include(c => c.Subcategories).FirstOrDefault(c => c.Id == categoryId);
        }

        public CategoryModel GetCategoryFromSubcategoryId(Guid subcategoryId)
        {
            return _dbContext.Subcategories.Include(sc => sc.Category)
                .FirstOrDefault(sc => sc.Id == subcategoryId)?.Category;
        }
    }
}
