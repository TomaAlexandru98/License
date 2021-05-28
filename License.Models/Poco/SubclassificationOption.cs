using License.Models.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace License.Models.Poco
{
    public class SubclassificationOption : IPoco
    {
        public Subclassification Subclassification { get; set; }
        
        public string SubclassificationName { get; set; }

        public Option OptionService { get; set; }

        public string OptionName { get; set; }
    }
}
