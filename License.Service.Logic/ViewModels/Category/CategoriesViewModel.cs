using System;
using System.Collections.Generic;
using System.Text;
using License.Models.Models;

namespace License.Service.Logic.ViewModels.Category
{
    public class CategoriesViewModel
    {
        public IEnumerable<CategoryModel> Categories { get; set; }
    }
}
