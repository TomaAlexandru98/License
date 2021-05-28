using License.Models.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace License.Models.Poco
{
    public class Service : IPoco
    {
        public int Id { get; set; }

        public User User { get; set; }
        
        public string UserId { get; set; }

        public string Preview { get; set; }
        
        public string Description { get; set; }

        public decimal Price { get; set; }

        public string DeliveryTime { get; set; }

        public Category Category { get; set; }

        public string CategoryName { get; set; }

        public Subcategory Subcategory { get; set; }

        public string SubcategoryName { get; set; }

        public Subclassification Subclassification{ get; set; }

        public List<ServiceOption> ServiceOptions { get; set; }
    }
}
