using License.Models.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace License.Models.Poco
{
    public class Category : IPoco
    {
        public string Name { get; set; }

        public List<Subcategory> SubcategoryServices { get; set; }
    }
}
