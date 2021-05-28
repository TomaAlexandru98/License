using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace License.Service.Logic.CustomValidation
{
    public class UniqueCategoryNameValidation
    {
        public static ValidationResult Validate(string x)
        {
            return new ValidationResult("Wrogn");
        }
    }
}
