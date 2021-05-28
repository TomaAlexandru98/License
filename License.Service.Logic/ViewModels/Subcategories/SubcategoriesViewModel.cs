using License.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace License.Service.Logic.ViewModels.Subcategories
{
    public class SubcategoriesViewModel
    {
        public IEnumerable<SubcategoryModel> Subcategories { get; set; }
        public CategoryModel Category { get; set; }
    }
}
