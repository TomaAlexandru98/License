using System;
using System.Collections.Generic;
using System.Text;

namespace License.Service.Logic.ViewModels.Services
{
    public class ContactSellerViewModel
    {
        public Guid ServiceId { get; set; }
        public string SellerEmail { get; set; }
        public string Message { get; set; }
    }
}
