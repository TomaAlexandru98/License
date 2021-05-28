using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using License.DataAccess.Infrastructure;
using License.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace License.DataAccess.Repositories
{
    public class SubcategoryRepository : BaseRepository<SubcategoryModel>, ISubcategoryRepository
    {
        public SubcategoryRepository(LicenseDbContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<SubcategoryModel> Get()
        {
            return _dbContext.Subcategories.AsEnumerable();
        }

        public IEnumerable<SubcategoryModel> Get(Guid categoryId)
        {
            return _dbContext.Subcategories.Where(s => s.CategoryId == categoryId);
        }

        public SubcategoryModel GetById(Guid subcategoryId)
        {
            return _dbContext.Subcategories.FirstOrDefault(s => s.Id == subcategoryId);
        }
    }
}
