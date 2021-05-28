using License.Models.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace License.Models.Poco
{
    public class Subcategory : IPoco
    {
        public string Name { get; set; }

        public List<SubcategorySubclassification> SubcategorySubclassificationServices { get; set; }
    }
}
