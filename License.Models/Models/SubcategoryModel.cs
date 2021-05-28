using System;
using System.Collections.Generic;
using System.Text;

namespace License.Models.Models
{
    public class SubcategoryModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsBlocked { get; set; }
        public string Description { get; set; }
        public CategoryModel Category { get; set; }
        public Guid CategoryId { get; set; }
    }
}
