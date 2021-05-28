using System;
using System.Collections.Generic;
using System.Text;
using License.Models.Models;

namespace License.Service.Logic.ViewModels.Services
{
    public class UserServicesViewModel
    {
        public IEnumerable<ServiceModel> Services { get; set; }
    }
}
