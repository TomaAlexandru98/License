using License.Models.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace License.Models.Poco
{
    public class SubcategorySubclassification : IPoco
    {
        public Subcategory Subcategory { get; set; }
        
        public string SubcategoryName { get; set; }

        public Subclassification Subclassification { get; set; }

        public string SubclassificationName { get; set; }
    }
}
