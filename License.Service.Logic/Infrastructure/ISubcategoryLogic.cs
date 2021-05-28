using License.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace License.Service.Logic.Infrastructure
{
    public interface ISubcategoryLogic
    {
        IEnumerable<SubcategoryModel> Get();
        IEnumerable<SubcategoryModel> Get(Guid categoryId);
        SubcategoryModel GetById(Guid subcategoryId);
        void Post(Guid id, string subcategoryName, string subcategoryDescription);
        void Update(Guid subcategoryId, string subcategoryName, string subcategoryDescription);
        void Block(Guid subcategoryId);
        void Unblock(Guid subcategoryId);
    }
}
