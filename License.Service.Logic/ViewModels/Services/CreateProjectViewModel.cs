using License.Models.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace License.Service.Logic.ViewModels.Services
{
    public class CreateProjectViewModel
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Preview { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public Guid CategoryId { get; set; }
        [Required]
        public Guid SubcategoryId { get; set; }
        [Required]
        public DeliveryTime DeliveryTime { get; set; }
        public IFormFile Image { get; set; }
    }
}
