using System;
using System.Collections.Generic;
using System.Text;
using License.Models.Models;

namespace License.DataAccess.Infrastructure
{
    public interface ICategoryRepository : IBaseRepository<CategoryModel>
    {
        IEnumerable<CategoryModel> Get();
        CategoryModel Get(Guid categoryId);
        CategoryModel GetCategoryFromSubcategoryId(Guid subcategoryId);
    }
}
