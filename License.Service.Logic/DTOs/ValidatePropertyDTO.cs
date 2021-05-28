using System;
using System.Collections.Generic;
using System.Text;

namespace License.Service.Logic.DTOs
{
    public class ValidatePropertyDTO
    {
        public string Property { get; set; }
        public string PropertyValue { get; set; }
        public List<string> Errors { get; set; }
    }
}
