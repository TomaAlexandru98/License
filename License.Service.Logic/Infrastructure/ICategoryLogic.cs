using System;
using System.Collections.Generic;
using System.Text;
using License.Models.Models;
using License.Service.Logic.ViewModels.Category;

namespace License.Service.Logic.Infrastructure
{
    public interface ICategoryLogic
    {
        IEnumerable<CategoryModel> Get();
        CategoryModel Get(Guid categoryId);
        void Post(string name, string description);
        void Update(Guid id, string name, string description);
        void Block(Guid categoryId);
        void Unblock(Guid categoryId);
        CategoryModel GetCategoryFromSubcategoryId(Guid subcategoryId);
    }
}
