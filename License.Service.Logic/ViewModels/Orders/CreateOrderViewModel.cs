using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace License.Service.Logic.ViewModels.Orders
{
    public class CreateOrderViewModel
    {
        [Display(Name = "First Name")]
        [Required]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        [Required]
        public string LastName { get; set; }
        [Display(Name = "Card Number")]
        [Required]
        public string CardNumber { get; set; }
        [Display(Name = "Expiration Date")]
        [Required]
        public string ExpirationDate { get; set; }
        [Display(Name = "Security Code")]
        [Required]
        [RegularExpression(@"^(\d{3})$", ErrorMessage = "Security Code needs to have 3 digits")]
        public int SecurityCode { get; set; }
        [Required]
        [MinLength(100, ErrorMessage = "Requirements must have at least 100 characters")]
        public string Requirements { get; set; }
        public Guid ServiceId { get; set; }
    }
}
