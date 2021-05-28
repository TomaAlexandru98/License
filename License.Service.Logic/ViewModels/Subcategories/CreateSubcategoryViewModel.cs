using License.Models.Models;
using License.Service.Logic.CustomValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace License.Service.Logic.ViewModels.Subcategories
{
    public class CreateSubcategoryViewModel
    {
        [Required]
        [Display(Name = "Subcategory")]
        public string SubcategoryName { get; set; }
        [Required]
        [Display(Name = "Subcategory Description")]
        public string SubcategoryDescription { get; set; }
        public Guid SubcategoryId { get; set; }
        public string CategoryName { get; set; }
        public Guid CategoryId { get; set; }
    }
}
