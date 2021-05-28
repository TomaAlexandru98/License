using License.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace License.Service.Logic.ViewModels.Services
{
    public class ServicesViewModel
    {
        public string CategoryName { get; set; }
        public Guid CategoryId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool ShouldDisplayData { get; set; }
        public IEnumerable<CategoryModel> Categories { get; set; }
        public IEnumerable<ServiceModel> Services { get; set; }
        public int NumberOfResult { get; set; }
    }
}
