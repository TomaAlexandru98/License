using System;
using System.Collections.Generic;
using System.Text;
using License.Models.Models;

namespace License.DataAccess.Infrastructure
{
    public interface ISubcategoryRepository : IBaseRepository<SubcategoryModel>
    {
        IEnumerable<SubcategoryModel> Get();
        IEnumerable<SubcategoryModel> Get(Guid categoryId);
        SubcategoryModel GetById(Guid subcategoryId);
    }
}
