using System;
using System.Collections.Generic;
using System.Text;

namespace License.Models.Models
{
    public class CategoryModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsBlocked { get; set; }
        public string Description { get; set; }
        public List<SubcategoryModel> Subcategories { get; set; }
    }
}
