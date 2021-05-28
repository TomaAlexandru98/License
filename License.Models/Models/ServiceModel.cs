using License.Models.Infrastructure;
using License.Models.Poco;
using System;
using System.Collections.Generic;
using System.Text;

namespace License.Models.Models
{
    public enum DeliveryTime
    {
        LessThanADay,
        OneDay,
        ThreeDays,
        SevenDays
    };
    public class ServiceModel 
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Preview { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
        public DeliveryTime DeliveryTime { get; set; }
        public SubcategoryModel Subcategory { get; set; }
        public Guid SubcategoryId { get; set; }
        public UserModel User { get; set; }
        public Guid UserId { get; set; }
    }
}
