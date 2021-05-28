using License.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace License.Service.Logic.Helpers
{
    public static class FilterServiceHelper
    {
        public static Guid CategoryId { get; set; }
        public static Guid SubcategoryId { get; set; }
        public static int MinPrice { get; set; }
        public static int MaxPrice { get; set; }
        public static DeliveryTime DeliveryTime { get; set; }
    }
}
