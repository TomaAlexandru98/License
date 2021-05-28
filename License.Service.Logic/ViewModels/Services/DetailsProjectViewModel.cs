using System;
using System.Collections.Generic;
using System.Text;
using License.Models.Models;

namespace License.Service.Logic.ViewModels.Services
{
    public class DetailsProjectViewModel
    {
        public Guid Id { get; set; }

        public string Preview { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string DeliveryTime { get; set; }

        public CategoryModel Category { get; set; }

        public SubcategoryModel Subcategory { get; set; }
        public IEnumerable<CategoryModel> Categories { get; set; }
        public string CategoryName { get; set; }
        public Guid CategoryId { get; set; }
        public string SubcategoryName { get; set; }
        public Guid SubcategoryId { get; set; }
        public string SellerCountry { get; set; }
        public string SellerLastDelivery { get; set; }
        public string SellerMemberSince { get; set; }
        public string SellerLastActiveOn { get; set; }
        public string SellerPreview { get; set; }
        public string SellerDescription { get; set; }
        public string SellerEmail { get; set; }
    }
}
